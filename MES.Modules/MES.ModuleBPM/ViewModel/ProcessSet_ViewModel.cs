using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using ZhuifengLib;

namespace MES.ModuleBPM
{
    /****************************************
     * VM层 
     * 功能：提供对工序设置操作
     * 日期：2015-10-13 11:20 V0.0.1
     ***************************************/
    class ProcessSetViewModel : ViewModelBase 
    {
        MES.Server.BLL.BPM_Process bll = new Server.BLL.BPM_Process();
        
        public ProcessSetViewModel()
        {
            //var value=(from v in db.tbl select v.name).Distinct().ToList();
            LsProcess = bll.GetModelList("");
        }

        private List<MES.Server.Model.BPM_Process> lsProcess = new List<Server.Model.BPM_Process>();
        public List<MES.Server.Model.BPM_Process> LsProcess                           //工序列表
        {
            get { return lsProcess; }
            set
            {
                lsProcess = value;
                this.RaisePropertyChanged("LsProcess");
            }
        }

        private MES.Server.Model.BPM_Process model = new Server.Model.BPM_Process();
        public MES.Server.Model.BPM_Process SelModel                                    //选择的项
        {
            get { return model; }
            set
            {
                model = value;
                this.RaisePropertyChanged("SelModel");
            }
        }

        private int editHeigh = 0; 
        public int EditHeigh
        {
            get { return editHeigh; }
            set
            {
                editHeigh = value;
                this.RaisePropertyChanged("EditHeigh");
            }
        }

        private bool isedit = false;
        public bool IsEdit
        {
            get { return isedit; }
            set
            {
                isedit = value;
                this.RaisePropertyChanged("IsEdit");
            }
        }
        


        public ICommand Search                                                        //搜索
        {
            get
            {
                return new DelegateCommand<string>((str) =>
                {
                    LsProcess = bll.GetModelList("Name Like '%"+str+"%'");
                });
            }
        }



        public ICommand ShowEdit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    EditHeigh = 110;
                });
            }
        }

        


        public ICommand Add
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    SelModel = new Server.Model.BPM_Process();
                    IsEdit = true;
                });
            }
        }



        public ICommand Edit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsEdit = true;
                });
            }
        }



        public ICommand Delete
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (model != null)
                    {
                        bll.Delete(model.ProcessID);
                        LsProcess.Remove(model);
                    }
                    ZhuifengLib.MessageShow.Message.MessageInfo("删除成功！");
                });
            }
        }

        public ICommand Sava
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    bll.Add(model);
                    EditHeigh = 0;
                    IsEdit = false;
                  //  LsProcess.Add(model);
                    ZhuifengLib.MessageShow.Message.MessageInfo("保存成功！");
                });
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public RelayCommand ExportToExcel => new RelayCommand(() =>
        {
            lsProcess.ExportToExcel(true, 1);
        });



        /// <summary>
        /// 
        /// </summary>
        public RelayCommand InputForExcel => new RelayCommand(() =>
        {
            //临时
            Thread th = new Thread(()=> {
                try
                {
                    var temAllDailList = MES.Business.BpmHelper.Daily.GetModelList("OrderID = '512-1511370'");
                    var pdList = MES.Business.BpmHelper.Product.GetModelList("");
                    var ptList = MES.Business.BpmHelper.ProductTemplate.GetModelList("");
                    foreach (var daily in temAllDailList)
                    {
                        try
                        {
                            daily.ProcessSign = ptList.FirstOrDefault(p => p.PtID == pdList.FirstOrDefault(t => t.ProductID == daily.ProductID).PtID && p.ProcessID == daily.ProcessID).ProcessSign;
                            MES.Business.BpmHelper.Daily.Update(daily);
                        }
                        catch (Exception ex) { }
                    }

                    ZhuifengLib.MessageShow.Message.MessageInfo("完成！");
                }
                catch (Exception ex) { }

            });

            th.IsBackground = true;
            th.Start();
            
        });





        public  void SynchronousMethod()
        {
          

        }







    }

    /*
     * 
     *  去重复比较器  使用 // LsAliasName = LsProcess.Distinct(new BPM_ProcessComparer()).ToList();
     *   
     * 
    /// <summary>
    /// 去"重复"时候的比较器(只要Alias相同，即认为是相同记录)
    /// </summary>
    class BPM_ProcessComparer : IEqualityComparer<MES.Server.Model.BPM_Process> 
    {
        public bool Equals(MES.Server.Model.BPM_Process p1, MES.Server.Model.BPM_Process p2)
        {
            if (p1 == null)
                return p2 == null;
            return p1.Alias == p2.Alias;
        }

        public int GetHashCode(MES.Server.Model.BPM_Process p)
        {
            if (p == null)
                return 0;
            return p.Alias.GetHashCode();
        }
    }
     */

}
