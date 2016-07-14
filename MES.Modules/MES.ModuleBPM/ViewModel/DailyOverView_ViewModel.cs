using GalaSoft.MvvmLight;
using MES.Server.Model;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using ZhuifengLib;

namespace MES.ModuleBPM
{
    class DailyOverViewViewModel : ViewModelBase
    {
        private Server.BLL.SYS.ListSource lsSources = null;
        /// <summary>
        /// 下拉列表数据源=》部门，站别，班别，列表
        /// </summary>
        public Server.BLL.SYS.ListSource LsSources => lsSources = lsSources = (lsSources == null ? new Server.BLL.SYS.ListSource() : lsSources);

        private DateTime dailyDate = DateTime.Now;

        bool IsConnecton = true;   //是否为跳线 默认为跳线

        List<BPM_Daily> allDailyList = new List<BPM_Daily>();


        public DateTime DailyDate
        {
            get { return dailyDate; }
            set
            {
                dailyDate = value;
                this.RaisePropertyChanged("DailyDate");
            }
        }

        private string classType;

        public string ClassType
        {
            get { return classType; }
            set
            {
                classType = value;
                this.RaisePropertyChanged("ClassType");
            }
        }


        /***************************************************
        *临时使用  区分散件和跳线的日报
        ***************************************************/
        public List<string> DailyWorkShopList => new List<string>() { "散件", "跳线" };
        public string DailyWorkShop
        {
            set
            {
                IsConnecton = value == "跳线" ? true : false;
            }
        }

        private List<DayReport.Model.DayReportModel> lsDaily;

        public List<DayReport.Model.DayReportModel> LsDaily
        {
            get { return lsDaily; }
            set
            {
                lsDaily = value;
                this.RaisePropertyChanged("LsDaily");
            }
        }

        public ICommand GetDailyList
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        DayReport.Manager.DayReportManager dailybll = new DayReport.Manager.DayReportManager();
                        LsDaily = dailybll.GetReportDataBy(DailyDate, ClassType, IsConnecton);
                        DailyDate.ToString();
                        //获取日报汇总信息
                        GetTotalInfo();
                        //获取未工作人员列表
                        GetNotWorkUserList();
                    }
                    catch (Exception ex) { ZhuifengLib.MessageShow.Message.MessageInfo(ex.Message); }

                });
            }
        }

        public ICommand ExportToExcel
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        // lsDaily.ExportToExcel(true,1);
                        lsDaily.ExportToExcel_forModule(@"\\qqqqqq-ms2\Templates\DailyView.xlsx", 5);
                        //导出明细
                        // allDailyList.ExportToExcel(true, 1);
                        DailyExportToExcel();
                    }
                    catch (Exception ex) { ZhuifengLib.MessageShow.Message.MessageInfo(ex.Message); }
                });
            }
        }

        public void DailyExportToExcel()
        {
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                File.Copy(@"\\qqqqqq-ms2\Templates\Daily.xlsx", localFilePath, true);
                IWorkbook wk = WorkbookFactory.Create(localFilePath);

                //导出明细
                ISheet tb = wk.GetSheet(wk.GetSheetName(0));
                int t = 1;
                foreach (BPM_Daily temmodul in allDailyList)
                {
                    //制令单号	工号	姓名	日期	班别	b25	工序	标准工时	生产工时	投入数量	良品数	不良数
                    IRow row = tb.CreateRow(t);
                    row.CreateCell(0).SetCellValue(temmodul.OrderID);           //工单单号
                    row.CreateCell(1).SetCellValue(temmodul.JobNum);            //工号
                    row.CreateCell(2).SetCellValue(temmodul.Name);              //姓名
                    row.CreateCell(3).SetCellValue(temmodul.Date.ToString());   //日期
                    row.CreateCell(4).SetCellValue(temmodul.ClassType);         //班别
                    row.CreateCell(5).SetCellValue(temmodul.ProcessID);         //工序ＩＤ  
                    row.CreateCell(6).SetCellValue(temmodul.ProcessName);       //工序名称
                    row.CreateCell(7).SetCellValue(Convert.ToDouble(temmodul.StandardHours.ToString()));        //标准工时
                    row.CreateCell(8).SetCellValue(Convert.ToDouble(temmodul.WorkHours.ToString()));            //生产工时
                    row.CreateCell(9).SetCellValue(Convert.ToDouble(temmodul.Qty.ToString()));                  //数量
                    row.CreateCell(10).SetCellValue(Convert.ToDouble(temmodul.QtyOK.ToString()));               //良品数量
                    row.CreateCell(11).SetCellValue(Convert.ToDouble(temmodul.QtyNG.ToString()));               //不良品数量
                    row.CreateCell(12).SetCellValue(temmodul.Workstation);                                      //站别
                    t++;
                }

                //导出未作业人员列表
                ISheet tb2 = wk.GetSheet(wk.GetSheetName(1));
                int t2 = 1;
                foreach (HR_User temmodul in NotWorkUserList)
                {
                    //制令单号	工号	姓名	日期	班别	b25	工序	标准工时	生产工时	投入数量	良品数	不良数
                    IRow row = tb2.CreateRow(t2);

                    row.CreateCell(0).SetCellValue(temmodul.Job_Num);           //工号
                    row.CreateCell(1).SetCellValue(temmodul.Name);              //姓名
                    row.CreateCell(2).SetCellValue(temmodul.Workstation);       //站别
                    t2++;
                }

                ////导出汇总信息
                //var totalDailyUserList = new List<BPM_Daily>();
                //foreach (var daily in allDailyList)
                //{
                //    //用户汇总 总览表
                //    if (totalDailyUserList.FirstOrDefault(x => x.JobNum == daily.JobNum) == null) //如果未找到了该作业元的汇总资料
                //    {
                //        totalDailyUserList.Add(new BPM_Daily()
                //        {
                //            JobNum = daily.JobNum,
                //            Name = daily.Name,
                //            WorkHours = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.WorkHours),
                //            NotWorkHours = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.NotWorkHours),
                //            QtyNG = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.QtyNG),
                //            QtyOK = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.QtyOK),
                //            Workstation = daily.Workstation

                //        });
                //    }
                //}

                //导出汇总信息
                var totalDailyUserList = new List<BPM_Daily>();
                foreach (var te in allDailyList)
                {
                    //用户汇总 总览表
                    if (totalDailyUserList.FirstOrDefault(m => m.JobNum == te.JobNum) == null)
                    {
                        var temModel = new Server.Model.BPM_Daily();
                        temModel.JobNum = te.JobNum;
                        temModel.Name = te.Name;
                        temModel.Workstation = te.Workstation;
                        temModel.WorkHours = allDailyList.Where(x => x.JobNum == te.JobNum).Sum(x => x.WorkHours);
                        temModel.NotWorkHours = allDailyList.Where(x => x.JobNum == te.JobNum).Sum(x => x.NotWorkHours);
                        temModel.QtyNG = allDailyList.Where(x => x.JobNum == te.JobNum).Sum(x => x.QtyNG);
                        temModel.QtyOK = allDailyList.Where(x => x.JobNum == te.JobNum).Sum(x => x.QtyOK);
                        temModel.TotalWorkHoursStandard = allDailyList.Where(m => m.JobNum == te.JobNum).Sum(m => m.TotalWorkHoursStandard);
                        temModel.TotalWorkHoursNotRelax = allDailyList.Where(m => m.JobNum == te.JobNum).Sum(m => m.TotalWorkHoursNotRelax);
                        temModel.WorkHours = allDailyList.Where(m => m.JobNum == te.JobNum).Sum(m => m.WorkHours);
                        temModel.Efficiency = Convert.ToDouble(temModel.TotalWorkHoursStandard / temModel.WorkHours);
                       // temModel.TotalWorkHoursNotRelax = Convert.ToDecimal(temModel.TotalWorkHoursNotRelax / temModel.WorkHours);
                        totalDailyUserList.Add(temModel);
                    }

                }

                ISheet tb3 = wk.GetSheet(wk.GetSheetName(2));
                int t3 = 1;
                foreach (BPM_Daily temmodul in totalDailyUserList)
                {
                    //制令单号	工号	姓名	日期	班别	b25	工序	标准工时	生产工时	投入数量	良品数	不良数
                    IRow row = tb3.CreateRow(t3);

                    row.CreateCell(1).SetCellValue(temmodul.JobNum);            //工号
                    row.CreateCell(2).SetCellValue(temmodul.Name);              //姓名
                    row.CreateCell(8).SetCellValue(Convert.ToDouble(temmodul.WorkHours.ToString()));            //生产工时
                    row.CreateCell(10).SetCellValue(Convert.ToDouble(temmodul.QtyOK.ToString()));               //良品数量
                    row.CreateCell(11).SetCellValue(Convert.ToDouble(temmodul.QtyNG.ToString()));               //不良品数量
                    row.CreateCell(12).SetCellValue(temmodul.Workstation);                                      //站别
                    row.CreateCell(13).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursNotRelax));         //得到工时
                    row.CreateCell(14).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursStandard));         //宽放后得到工时
                    row.CreateCell(15).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursNotRelax / temmodul.WorkHours));         //宽放后得到工时
                    row.CreateCell(16).SetCellValue(Convert.ToDouble(temmodul.TotalWorkHoursStandard / temmodul.WorkHours));         //宽放后得到工时
                    t3++;
                   
                }

                FileStream fs2 = File.Create(localFilePath);
                wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
                ZhuifengLib.MessageShow.Message.MessageInfo("提示：创建成功！");
            }
        }



        #region 显示汇总信息
        void GetTotalInfo()
        {
            MES.Com.MyUserControl.Landing td = new Com.MyUserControl.Landing(() =>
            {
                allDailyList = Business.BpmHelper.Daily.GetModelList(" Department = '制六部'  AND ClassType='" +
               ClassType + "'  AND  Date = '" +
               DailyDate.ToString("yyyy-MM-dd") + "'");
                allDailyList.OrderBy(p => p.Workstation).ToList();
                foreach (var daily in allDailyList)
                {
                    //用户汇总 总览表
                    if (TotalUserDailyList.FirstOrDefault(x => x.JobNum == daily.JobNum) == null) //如果未找到了该作业元的汇总资料
                    {
                        TotalUserDailyList.Add(new BPM_Daily()
                        {
                            JobNum = daily.JobNum,
                            Name = daily.Name,
                            ClassType = daily.ClassType,
                            WorkShop = daily.WorkShop,
                            Workstation = daily.Workstation,
                            Efficiency = double.Parse(allDailyList.Where(x => x.JobNum == daily.JobNum).Average(x => x.Efficiency).Value.ToString("F2")),
                            WorkHours = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.WorkHours),
                            NotWorkHours = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.NotWorkHours),
                            QtyNG = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.QtyNG),
                            QtyOK = allDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.QtyOK)
                        });
                    }
                }
                TotalUserDailyList = TotalUserDailyList.OrderBy(p => p.Workstation).ToList();
            });
            td.Start();
        }

        private string totalDailyInfo;
        /// <summary>
        /// 日报汇总信息
        /// </summary>
        public string TotalDailyInfo
        {
            get { return totalDailyInfo; }
            set
            {
                totalDailyInfo = value;
                this.RaisePropertyChanged("TotalDailyInfo");
            }
        }


        private List<BPM_Daily> totalUserDailyList = new List<BPM_Daily>();
        /// <summary>
        /// 
        /// </summary>
        public List<BPM_Daily> TotalUserDailyList
        {
            get { return totalUserDailyList; }
            set
            {
                totalUserDailyList = value;
                this.RaisePropertyChanged("TotalUserDailyList");
            }
        }
        #endregion


        #region 检验人员是否全部都写了日报
        /// <summary>
        /// 获取未工作人员列表
        /// </summary>
        void GetNotWorkUserList()
        {
            var userList = Business.HrHelper.User.GetModelList("(Department = '制六部') AND (ClassType = '" + ClassType + "') AND (Job_Title = '操作员') AND (Is_Job = '在职')");
            NotWorkUserList = (from u in userList where !TotalUserDailyList.Exists(d => d.JobNum == u.Job_Num) select u).ToList();
            //TotalDailyInfo += "总人数  未录日报：" + NotWorkUserList.Count() +"人";
            TotalDailyInfo = string.Format("总人数：{0}人 已录人数:{1}人 未录入：{2}", userList.Count, TotalUserDailyList.Count, NotWorkUserList.Count);
        }

        private List<HR_User> myVar;

        public List<HR_User> NotWorkUserList
        {
            get { return myVar; }
            set
            {
                myVar = value;
                this.RaisePropertyChanged("NotWorkUserList");
            }
        }


        #endregion



    }
}
