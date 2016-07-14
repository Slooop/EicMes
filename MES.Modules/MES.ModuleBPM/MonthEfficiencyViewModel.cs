using GalaSoft.MvvmLight;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZhuifengLib;
using MES.Server.Model;
using GalaSoft.MvvmLight.Command;
using msg = ZhuifengLib.MessageShow.Message;
using System.Threading;

namespace MES.ModuleBPM
{
    class MonthEfficiencyViewModel : ViewModelBase
    {

        /// <summary>
        /// 列表基类 
        /// </summary>
        public class ModelList_obs : ObservableCollection<BPM_Daily>
        {
            public ModelList_obs() { }
            public ModelList_obs(List<BPM_Daily> list) : base(list) { }
        }

        List<BPM_Daily> allList = new List<BPM_Daily>();

        private ModelList_obs monthEfficiencyList = new ModelList_obs();
        /// <summary>
        /// 
        /// </summary>
        public ModelList_obs MonthEfficiencyList
        {
            get { return monthEfficiencyList; }
            set
            {
                monthEfficiencyList = value;
                this.RaisePropertyChanged("MonthEfficiencyList");
            }
        }


        /// <summary>
        /// 获取效率
        /// </summary>
        public RelayCommand<string> GetMonthEfficiencyList => new RelayCommand<string>((str) =>
        {
            allList = Business.BpmHelper.Daily.GetModelList("Month = '" + str + "'");
            var tem = allList.Distinct(new DailyUserComparer()).ToList();
            var ttt = TotalProcess(tem);
            foreach (var te in tem)
            {
                if (monthEfficiencyList.FirstOrDefault(m => m.JobNum == te.JobNum) == null)
                {
                    var temModel = new BPM_Daily();
                    temModel.JobNum = te.JobNum;
                    temModel.Name = te.Name;
                    temModel.Workstation = te.Workstation;
                    temModel.ProcessID = ttt.Where(m => m.JobNum == te.JobNum).OrderBy(m => m.WorkHours).ToList()[0].ProcessID;
                    temModel.ProcessName = ttt.Where(m => m.JobNum == te.JobNum).OrderBy(m => m.WorkHours).ToList()[0].ProcessName;
                    temModel.TotalWorkHoursStandard = allList.Where(m => m.JobNum == te.JobNum).Sum(m => m.TotalWorkHoursStandard);
                    temModel.TotalWorkHoursNotRelax = allList.Where(m => m.JobNum == te.JobNum).Sum(m => m.TotalWorkHoursNotRelax);
                    temModel.WorkHours = allList.Where(m => m.JobNum == te.JobNum).Sum(m => m.WorkHours);
                    temModel.Efficiency = Convert.ToDouble(temModel.TotalWorkHoursStandard / temModel.WorkHours);
                    temModel.StandardHours = Convert.ToDecimal(temModel.TotalWorkHoursNotRelax / temModel.WorkHours);
                    


                    MonthEfficiencyList.Add(temModel);
                }

            }
        });


        public RelayCommand<string> ExportMonthMasterList => new RelayCommand<string>((str) =>
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Thread td = new Thread(() =>
            {
                var AllProcessTemplate = Business.BpmHelper.ProductTemplate.GetModelList("");
                var AllProduct = Business.BpmHelper.Product.GetModelList("");
                var MasterList = new List<MonthMaster>();
                foreach (var te in allList)
                {
                    if (MasterList.FirstOrDefault(m => m.OrderID == te.OrderID) == null)
                    {
                        var temModel = new MonthMaster();
                        temModel.OrderID = te.OrderID;            //工单
                            temModel.ClientName = te.ClientName;      //客户
                            temModel.ProductName = te.ProductName;    //品名
                            temModel.Spec = te.Spec;                  //规格
                            temModel.OrderCount = te.OrderCount;      //批量
                            var temProduct = AllProduct.FirstOrDefault(m => m.ProductID.Trim() == te.ProductID.Trim());
                        temModel.StandardHours = AllProcessTemplate.Where(m => m.PtID == temProduct?.PtID)?.Sum(x => x.StandardHours);
                        temModel.MonthInputQty = allList.Where(m => m.OrderID == te.OrderID && m.ProcessSign == "起始站").Sum(x => x.Qty);
                        temModel.MonthQty = allList.Where(m => m.OrderID == te.OrderID && m.ProcessSign == "结束站").Sum(x => x.Qty);
                        temModel.MonthQtyNg = allList.Where(m => m.OrderID == te.OrderID).Sum(x => x.Qty);
                        temModel.MonthInputWorkHours = allList.Where(m => m.OrderID == te.OrderID).Sum(x => x.WorkHours);
                        temModel.MonthWorkHours = allList.Where(m => m.OrderID == te.OrderID).Sum(x => x.WorkHours);
                        temModel.MonthGetWorkHours = allList.Where(m => m.OrderID == te.OrderID).Sum(x => x.TotalWorkHoursStandard);

                        var OrderDailyList = Business.BpmHelper.Daily.GetModelList($"OrderID='{te.OrderID}'");
                        temModel.OrderInputQty = OrderDailyList.Where(m => m.ProcessSign == "起始站")?.Sum(x => x.Qty);
                        temModel.OrderQty = OrderDailyList.Where(m => m.ProcessSign == "结束站")?.Sum(x => x.Qty);
                        temModel.OrderWorkHours = OrderDailyList?.Sum(x => x.WorkHours);

                        var OrderErp = Business.BpmHelper.Order_ERP.GetModel(te.OrderID);
                        temModel.OrderInStorage = OrderErp?.InStorageCount;
                        temModel.OrderState = OrderErp?.State;

                        MasterList.Add(temModel);
                    }
                }



                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                    File.Copy(@"\\192.168.0.65\Templates\DailyReports\月汇总模板.xlsx", localFilePath, true);
                IWorkbook wk = WorkbookFactory.Create(localFilePath);

                    //导出汇总
                    ISheet tb = wk.GetSheet(wk.GetSheetName(0));
                int RowIndex = 2;
                foreach (var temmodul in MasterList)        //导出制六课日报
                    {
                    IRow row = tb.CreateRow(RowIndex);
                    row.CreateCell(0).SetCellValue(temmodul.OrderID);
                    row.CreateCell(1).SetCellValue(temmodul.ClientName);
                    row.CreateCell(2).SetCellValue(temmodul.ProductName);
                    row.CreateCell(3).SetCellValue(temmodul.Spec);
                    row.CreateCell(4).SetCellValue(Convert.ToDouble(temmodul.OrderCount));
                    row.CreateCell(5).SetCellValue(Convert.ToDouble(temmodul.StandardHours));
                    row.CreateCell(8).SetCellValue(Convert.ToDouble(temmodul.MonthInputQty));
                    row.CreateCell(10).SetCellValue(Convert.ToDouble(temmodul.MonthQty));
                    row.CreateCell(13).SetCellValue(Convert.ToDouble(temmodul.MonthQtyNg));
                    row.CreateCell(16).SetCellValue(Convert.ToDouble(temmodul.MonthInputWorkHours));
                    row.CreateCell(17).SetCellValue(Convert.ToDouble(temmodul.MonthWorkHours));
                    row.CreateCell(19).SetCellValue(Convert.ToDouble(temmodul.MonthGetWorkHours));
                    row.CreateCell(25).SetCellValue(Convert.ToDouble(temmodul.OrderPlanQty));
                    row.CreateCell(26).SetCellValue(Convert.ToDouble(temmodul.OrderQty));
                    row.CreateCell(27).SetCellValue(Convert.ToDouble(temmodul.OrderInputQty));
                    row.CreateCell(28).SetCellValue(Convert.ToDouble(temmodul.OrderInStorage));
                    row.CreateCell(29).SetCellValue(Convert.ToDouble(temmodul.OrderWorkHours));
                    row.CreateCell(30).SetCellValue(temmodul.OrderState);


                    RowIndex++;
                }
                FileStream fs2 = File.Create(localFilePath);
                wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
                    msg.MessageInfo("导出成功！");
            });

                td.IsBackground = true;
                td.Start();
            }







        });


        List<BPM_Daily> TotalProcess(List<BPM_Daily> DailyList)
        {
            var totalDailyProcessList = new List<BPM_Daily>();
            foreach (var daily in DailyList)
            {
                //工序汇总 总览表
                if (totalDailyProcessList.FirstOrDefault(p => p.ProcessID == daily.ProcessID && p.JobNum == daily.JobNum) == null)
                {
                    totalDailyProcessList.Add(new BPM_Daily()
                    {
                        JobNum = daily.JobNum,
                        Name = daily.Name,
                        Workstation = daily.Workstation,
                        ProcessID = daily.ProcessID,
                        ProcessName = daily.ProcessName,
                        TotalWorkHoursStandard = DailyList.Where(m => m.JobNum == daily.JobNum && m.ProcessID == daily.ProcessID).Sum(x => x.TotalWorkHoursStandard),
                        TotalWorkHoursNotRelax = DailyList.Where(m => m.JobNum == daily.JobNum && m.ProcessID == daily.ProcessID).Sum(x => x.TotalWorkHoursNotRelax),
                        WorkHours = DailyList.Where(m => m.JobNum == daily.JobNum && m.ProcessID == daily.ProcessID).Sum(x => x.WorkHours),
                    });
                }
            }
            return totalDailyProcessList;

        }


        /// <summary>
        /// 
        /// </summary>
        public RelayCommand ExportToExcel => new RelayCommand(() =>
        {
            DailyExportToExcel();
            // monthEfficiencyList.ToList().ExportToExcel_forModule(@"\\qqqqqq-ms2\\Templates\MonthEfficiency.xlsx", 2);
            allList.ToList().ExportToExcel(true, 1);
        });

        /// <summary>
        /// 生成有公式的单元格
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="Formula">公式</param>
        /// <param name="cellStyle">样式 PS：如果不设置格式 请设置为Null</param>
        void CreateFormulaCell(ICell cell, string Formula, ICellStyle cellStyle)
        {
            cell.CellFormula = Formula;                       //本日累计达成率 = 实际产出累计/计划产出累计
            if (cellStyle == null)
                return;
            cell.CellStyle = cellStyle;
        }

        /// <summary>
        /// 导出至Excel
        /// </summary>
        public void DailyExportToExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                File.Copy(@"\\qqqqqq-ms2\\Templates\MonthEfficiency.xlsx", localFilePath, true);
                IWorkbook wk = WorkbookFactory.Create(localFilePath);

                //导出汇总
                ISheet tb = wk.GetSheet(wk.GetSheetName(0));
                int t = 2;
                foreach (var temmodul in monthEfficiencyList)
                {
                    //制令单号	工号	姓名	日期	班别	b25	工序	标准工时	生产工时	投入数量	良品数	不良数
                    IRow row = tb.CreateRow(t);
                    row.CreateCell(0).SetCellValue(temmodul.JobNum);           
                    row.CreateCell(1).SetCellValue(temmodul.Name);
                    row.CreateCell(2).SetCellValue(temmodul.Workstation);
                    row.CreateCell(3).SetCellValue(temmodul.ProcessID);
                    row.CreateCell(4).SetCellValue(temmodul.ProcessName);

                    row.CreateCell(5).SetCellValue(Convert.ToDouble(temmodul.WorkHours));
                    row.CreateCell(6).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursNotRelax));
                    row.CreateCell(7).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursStandard));           
                    //row.CreateCell(7).SetCellValue(Convert.ToDouble(temmodul.Efficiency));                 
                    
                    CreateFormulaCell(row.CreateCell(8), $"G{t + 1}/F{t + 1}", null);
                    CreateFormulaCell(row.CreateCell(9), $"H{t + 1}/F{t + 1}", null);
                    CreateFormulaCell(row.CreateCell(10), $"G{t + 1}-F{t + 1}", null);
                    CreateFormulaCell(row.CreateCell(11), $"H{t + 1}-F{t + 1}", null);
                    CreateFormulaCell(row.CreateCell(12), $" G{t + 1} * 1650 / 22 / 8 / 60", null);
                    CreateFormulaCell(row.CreateCell(13), $" H{t + 1} * 1650 / 22 / 8 / 60", null);


                    t++;
                }
                FileStream fs2 = File.Create(localFilePath);
                wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
                ZhuifengLib.MessageShow.Message.MessageInfo("导出成功！");
            }
        }

    }



    /// <summary>
    /// 去"重复"时候的比较器(只要工号相同，即认为是相同记录)
    /// </summary>
    class DailyUserComparer : IEqualityComparer<BPM_Daily>
    {
        public bool Equals(BPM_Daily x, BPM_Daily y)
        {
            if (x == null)

                return y == null;

            return x.JobNum == y.JobNum;
        }

        public int GetHashCode(BPM_Daily obj)
        {
            if (obj == null)
                return 0;
            return obj.JobNum.GetHashCode();
        }
    }


    class MonthMaster
    {
        public string OrderID { get; set; }
        public string ClientName { get; set; }

        public string ProductName { get; set; }
        public string Spec { get; set; }
        public int? OrderCount { get; set; }

        public decimal? StandardHours { get; set; }

        public int? MonthInputQty { get; set; }
        public int? MonthQty { get; set; }

        public int? MonthQtyNg { get; set; }

        public decimal? MonthInputWorkHours { get; set; }
        public decimal? MonthWorkHours { get; set; }

        public decimal? MonthGetWorkHours { get; set; }

        public int? OrderPlanQty { get; set; }
        public int? OrderQty { get; set; }
        public int? OrderInputQty { get; set; }
        public double? OrderInStorage { get; set; }
        public decimal? OrderWorkHours { get; set; }
        public string OrderState { get; set; }

    }
}
