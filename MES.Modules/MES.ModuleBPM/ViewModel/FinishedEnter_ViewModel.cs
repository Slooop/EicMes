using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MES.ModuleBPM
{
    class FinishedEnterViewModel : ViewModelBase
    {
        public FinishedEnterViewModel(){
           User = ((MES.Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo);}

        private MES.Server.BLL.HR_User bll_user = new Server.BLL.HR_User();
        MES.Server.BLL.BPM_Order order_bll = new Server.BLL.BPM_Order();
        MES.Server.BLL.BPM_ProductionRecords productionrecords_bll = new Server.BLL.BPM_ProductionRecords();


        #region Property

        private MES.Server.Model.HR_User user = new Server.Model.HR_User();
       
        public string JobNum                                                                      //工号
        {
            get { if (user != null) return User.Job_Num; else return null; }
            set
            {
                this.RaisePropertyChanged("JobNum");
                User = bll_user.GetModel(value);
                if (user == null)
                    ZhuifengLib.MessageShow.Message.MessageInfo("未找到用户！");
            }
        }
      
        public MES.Server.Model.HR_User User                                                        //用户
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged("User");
            }
        }

        private string orderid;
        public string OrderID                                                                      //工单单号
        {
            get { return orderid; }
            set
            {
                orderid = value;
                this.RaisePropertyChanged("OrderID");
                GetOrder(value);
                if (order.State == "已完工")
                    ZhuifengLib.MyMessage.MessageInfo("该工单状态为：”已完工“\r\n确定要继续操作么！");
            }
        }

        private MES.Server.Model.BPM_Order order;
        public MES.Server.Model.BPM_Order Order                                                    //工单
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }

        private List<MES.Server.Model.BPM_ProductTemplate> lsV_Processtemplate                    
            = new List<Server.Model.BPM_ProductTemplate>();
        public List<MES.Server.Model.BPM_ProductTemplate> LsV_ProcessTemplate                       //工序列表
        {
            get { return lsV_Processtemplate; }
            set { lsV_Processtemplate = value; this.RaisePropertyChanged("LsV_ProcessTemplate"); }
        }
        
        private bool isSava = false;
        public bool IsSava                                                                         //保存按钮是否启用
        {
            get { return isSava; }
            set {isSava = value;this.RaisePropertyChanged("IsSava"); }
        }

        private bool popIsOpen =false;
        public bool PopIsOpen                                                                     //验证Pop是否打开
        {
            get { return popIsOpen; }
            set{ popIsOpen = value; this.RaisePropertyChanged("PopIsOpen");}
        }

      

        private MES.Server.Model.BPM_ProductionRecords model 
            = new Server.Model.BPM_ProductionRecords();
        public MES.Server.Model.BPM_ProductionRecords Model                                       //一条记录
        {
            get { return model; }
            set { model = value; this.RaisePropertyChanged("Model"); }
        }

        private List<MES.Server.Model.BPM_ProductionRecords> lsProduction
            = new List<Server.Model.BPM_ProductionRecords>();
        public List<MES.Server.Model.BPM_ProductionRecords> LsProduction                         //工序的已录入记录
        {
            get { return lsProduction; }
            set { lsProduction = new List<Server.Model.BPM_ProductionRecords>(value.OrderByDescending(p=>p.DateTime)); this.RaisePropertyChanged("LsProduction"); }
        }

        private decimal sum;
        public decimal Sum                                                                     //已录入的接头总数
        {
            get { return sum; }
            set { sum = value; this.RaisePropertyChanged("Sum"); }
        }

        private int orderQty;
        public int OrderQty                                                                    //工单总批量（以接头为单位所以要计算）
        {
            get { return orderQty; }
            set
            {
                orderQty = value;
                this.RaisePropertyChanged("OrderQty");
            }
        }

        private decimal qty;
        public decimal Qty                                                                     //录入数量
        {
            get { return qty; }
            set
            {
                qty = value;
                this.RaisePropertyChanged("Qty");
                LsVer = LsProduction.Take(3).ToList();
            }
        }

      
       
        private List<MES.Server.Model.BPM_ProductionRecords> lsVer 
            = new List<Server.Model.BPM_ProductionRecords>();
        public List<MES.Server.Model.BPM_ProductionRecords> LsVer                              //最近的三次录入
        {
            get { return lsVer; }
            set { lsVer = value; this.RaisePropertyChanged("LsVer"); IsSava = Verification(); }
        }

        private MES.Server.Model.BPM_ProductTemplate selectprocess;
        public MES.Server.Model.BPM_ProductTemplate SelectProcess                             //要录入的工序
        {
            get { return selectprocess; }
            set
            {
                if (value != null)
                {
                    selectprocess = value;
                    this.RaisePropertyChanged("SelectProcess");
                    LoadProductionRecords();

                }

            }
        }

        private void LoadProductionRecords()
        {
            if (selectprocess != null && order != null)
            {
                //获取记录 并计算已生产的数量
                LsProduction = productionrecords_bll.GetModelList("OrderID='" + order.OrderID + "' AND ProcessID='" + selectprocess.ProcessID + "'");
                var sum = (from temp in LsProduction select temp).Sum(t => t.Qty_OK);
                Sum = decimal.Parse(sum.ToString());

                CreateReLsWork();


            }
        }

        private void CreateReLsWork()
        {
            //获取重工工序列表
            if (selectprocess.ReWorkProcess != null)
            {
                string[] ReWorkProcessID = selectprocess.ReWorkProcess.Split(',');
                List<MES.Server.Model.BPM_ReWork> temLsRework = new List<Server.Model.BPM_ReWork>();
                foreach (string tem in ReWorkProcessID)
                {
                    List<MES.Server.Model.BPM_ProductTemplate> tePt = (from s in LsV_ProcessTemplate where s.ProcessID == tem select s).ToList();
                    if (tePt.Count > 0)
                    {
                        MES.Server.Model.BPM_ProductTemplate teProcess =
                      (MES.Server.Model.BPM_ProductTemplate)tePt[0];

                        temLsRework.Add(new Server.Model.BPM_ReWork()
                        {
                            OrderID = order.OrderID,
                            DispositonJobNum = user.Job_Num,
                            DispositonUser = user.Name,
                            WK_Receive = teProcess.ProcessID,
                            Disposition = teProcess.ProcessName
                        });
                    }
                }
                LsReWork = temLsRework;
            }
        }


        private List<MES.Server.Model.BPM_ReWork> lsReWork = new List<Server.Model.BPM_ReWork>();
        public List<MES.Server.Model.BPM_ReWork> LsReWork                                    //重工记录（进行WIP计算）
        {
            get { return lsReWork; }
            set
            {
                lsReWork = value;
                this.RaisePropertyChanged("LsReWork");
            }
        }

        MES.Server.BLL.BPM_WIP wip_bll = new Server.BLL.BPM_WIP();



        private MES.Server.Model.BPM_ProductionRecords selectPR;
        public MES.Server.Model.BPM_ProductionRecords SelectPR               //选择的已录入记录  可用于删除
        {
            get { return selectPR; }
            set
            {
                selectPR = value;
                this.RaisePropertyChanged("SelectPR");
            }
        }
        

        #endregion


        #region Method        

        /// <summary>
        /// 获取工单信息
        /// </summary>
        /// <param name="value"></param>
        private void GetOrder(string value)                                                           
        {
            Order = order_bll.GetModel(value);

            if (Order != null)  //查找工单是否存在
            {
                if (Order.Product != null)  //检查产品是否为空
                {
                    if (SelectProcess != null) //检查选择的工序是否为空
                    {
                        MES.Server.Model.BPM_ProductTemplate resultPt = Order.Product.ControlProcessList.ToList().Find(
                 delegate(MES.Server.Model.BPM_ProductTemplate pt) { return pt.ProcessID == SelectProcess.ProcessID; }); //检查已选择的工序是否此工单也有
                        if (resultPt == null) //如果没有
                        {
                            LsV_ProcessTemplate = Order.Product.ControlProcessList.ToList();
                            SelectProcess = new Server.Model.BPM_ProductTemplate();
                        }
                        else
                        {
                            //获取记录 并计算已生产的数量
                            LsProduction = productionrecords_bll.GetModelList("OrderID='" + order.OrderID + "' AND ProcessID='" + SelectProcess.ProcessID + "'");
                            var sum = (from temp in LsProduction select temp).Sum(t => t.Qty);
                            Sum = decimal.Parse(sum.ToString());
                        }
                    }
                    else
                    {

                        LsV_ProcessTemplate = Order.Product.ControlProcessList.ToList();
                        SelectProcess = new Server.Model.BPM_ProductTemplate();
                    }

                    if (order.Relax != null) //接头总数=接头数量 x 总批量 x 款放比例
                        OrderQty = int.Parse(( order.Count * double.Parse(order.Relax.ToString()) * double.Parse(order.Product.ConnectorQty.ToString())).ToString());
                    else
                    {
                        OrderQty = int.Parse(( order.Count * double.Parse(order.Product.ConnectorQty.ToString())).ToString());
                        ZhuifengLib.MessageShow.Message.MessageInfo("工单未设置宽放比例；请联系助理进行设置！");
                    }
                }
                else
                {
                    LsV_ProcessTemplate = null;
                    SelectProcess = new Server.Model.BPM_ProductTemplate();
                }

            }
            else
            {
                LsV_ProcessTemplate = null;
                SelectProcess = new Server.Model.BPM_ProductTemplate();
            }
        }


        /// <summary>
        /// 验证是否可以保存
        /// </summary>
        private bool Verification()
        {
            if (order != null && selectprocess.ProcessID != null && User != null && Qty > 1)
                if ((Qty + Sum) > decimal.Parse(OrderQty.ToString()))
                {
                    ZhuifengLib.MessageShow.Message.MessageInfo("录入数量不能大于工单总批量！");
                    return false;
                }
                else if (Qty > selectprocess.OnceQty)
                {
                    ZhuifengLib.MessageShow.Message.MessageInfo("录入数量不能大于单次录入限制数" + selectprocess.OnceQty);
                    return false;
                }
                else return true;
            else
                return false;
        }

#endregion


        #region 命令


        /// <summary>
        /// 添加
        /// </summary>
        public ICommand Add
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    //总投入处理
                    model.UserID = User.Job_Num;
                    model.UserName = user.Name;
                    model.ProcessID = selectprocess.ProcessID;
                    model.ProcessName = selectprocess.ProcessName;
                    model.OrderID = order.OrderID;
                    model.Qty = Qty;
                    model.Num = selectprocess.Num;
                    int? temNgQty = 0;
                    foreach (MES.Server.Model.BPM_ReWork te in LsReWork)
                    {
                        if (te.IsCheck)
                            temNgQty = temNgQty + te.Qty;
                    }
                    model.Qty_NG = temNgQty;
                    model.Qty_OK = model.Qty - model.Qty_NG;
                    productionrecords_bll.Add(model);

                    int temPtIdx = LsV_ProcessTemplate.IndexOf(selectprocess);

                    //设置本工序的WIP
                    List<MES.Server.Model.BPM_ProductTemplate> tePt = (from s in LsV_ProcessTemplate where s.ProcessID == selectprocess.ProcessID select s).ToList();
                    if (tePt.Count > 0)
                    {
                        MES.Server.Model.BPM_ProductTemplate teProcess =
                      (MES.Server.Model.BPM_ProductTemplate)tePt[0];

                        MES.Server.Model.BPM_WIP teWIP = wip_bll.GetModel(order.OrderID, teProcess);
                        teWIP.Count +=  int.Parse(model.Qty.ToString());　　　 //投入数量
                        teWIP.QtyOK +=  int.Parse(model.Qty_OK.ToString()); 　 //良品数量
                        teWIP.QtyNG = teWIP.Count - teWIP.QtyOK;    　　　　　 //不良数量
                        if (temPtIdx != 0)//如果不是第一道工序 计算WIP
                            teWIP.WIP = teWIP.WIP - (int.Parse(model.Qty_OK.ToString()) + int.Parse(model.Qty_NG.ToString()));       
                        wip_bll.Update(teWIP); 

                        if(temPtIdx+1<LsV_ProcessTemplate.Count)
                        {
                            MES.Server.Model.BPM_WIP temwip = wip_bll.GetModel(order.OrderID, LsV_ProcessTemplate[temPtIdx + 1]); //下工序WIP
                            temwip.WIP = temwip.WIP + int.Parse(model.Qty_OK.ToString()); 
                            wip_bll.Update(temwip);
                        }
                       
                    }


                    //不良处理
                    MES.Server.BLL.BPM_ReWork rework_bll = new Server.BLL.BPM_ReWork();
                    foreach (MES.Server.Model.BPM_ReWork te in LsReWork)
                    {
                        te.WK_Send = model.ProcessID;
                        te.CauseNG = model.ProcessName;
                        if (te.IsCheck)
                        {
                            rework_bll.Add(te);

                            //得到一个WIP
                            List<MES.Server.Model.BPM_ProductTemplate> tePt_NG = (from s in LsV_ProcessTemplate where s.ProcessID == te.WK_Receive select s).ToList();
                            if (tePt.Count > 0)
                            {
                                MES.Server.Model.BPM_ProductTemplate teProcess =
                              (MES.Server.Model.BPM_ProductTemplate)tePt_NG[0];
                                MES.Server.Model.BPM_WIP teWIP = wip_bll.GetModel(order.OrderID, teProcess);
                                teWIP.WIP = teWIP.WIP + te.Qty;                          //将不良返回加入到WIP中
                                wip_bll.Update(teWIP);
                            }
                        }
                        te.IsCheck = false;
                        te.Qty = null;
                    }
                    Qty = 0;
                    PopIsOpen = false;
                    //获取记录 并计算已生产的数量
                    LsProduction = productionrecords_bll.GetModelList("OrderID='" + order.OrderID + "' AND ProcessID='" + selectprocess.ProcessID + "'");
                    var sum = (from temp in LsProduction select temp).Sum(t => t.Qty_OK);
                    Sum = decimal.Parse(sum.ToString());
                });
            }
        }



        public ICommand Delete
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (selectPR != null)
                    {
                        int temPtIdx = LsV_ProcessTemplate.IndexOf(selectprocess);
                        //更改WIP
                        //设置本工序的WIP
                        List<MES.Server.Model.BPM_ProductTemplate> tePt = (from s in LsV_ProcessTemplate where s.ProcessID == selectprocess.ProcessID select s).ToList();
                        if (tePt.Count > 0)
                        {
                            MES.Server.Model.BPM_ProductTemplate teProcess =
                          (MES.Server.Model.BPM_ProductTemplate)tePt[0];

                            MES.Server.Model.BPM_WIP teWIP = wip_bll.GetModel(order.OrderID, teProcess);
                            teWIP.Count -= Convert.ToInt32(selectPR.Qty);　　　 //投入数量
                            teWIP.QtyOK -= Convert.ToInt32(selectPR.Qty_OK); 　 //良品数量
                            teWIP.QtyNG = teWIP.Count - teWIP.QtyOK;    　　　　　 //不良数量
                            if (temPtIdx != 0)//如果不是第一道工序 计算WIP
                                teWIP.WIP = teWIP.WIP - (Convert.ToInt32(selectPR.Qty_OK) - Convert.ToInt32(selectPR.Qty_NG));
                            wip_bll.Update(teWIP);

                            if (temPtIdx + 1 < LsV_ProcessTemplate.Count)
                            {
                                MES.Server.Model.BPM_WIP temwip = wip_bll.GetModel(order.OrderID, LsV_ProcessTemplate[temPtIdx + 1]); //下工序WIP
                                temwip.WIP = temwip.WIP - Convert.ToInt32(selectPR.Qty_OK);
                                wip_bll.Update(temwip);
                            }

                        }

                        productionrecords_bll.Delete(selectPR.ID_Key);
                        LoadProductionRecords();  //重新载入此工序的关键工序采集记录
                        ZhuifengLib.MessageShow.Message.MessageInfo("删除成功！");


                    }
                });
            }
        }
        

        /// <summary>
        /// Tab键按下
        /// </summary>
        public ICommand KeyTab
        {
            //ZhuifengLib.Keyboard.Press(Key.Tab);
            get { return new DelegateCommand(() => { ZhuifengLib.Keyboard.Press(Key.Tab);}); }
        }

        public ICommand KeyTab_Qry
        {
            //ZhuifengLib.Keyboard.Press(Key.Tab);
            get { return new DelegateCommand(() => { ZhuifengLib.Keyboard.Press(Key.Tab); CreateReLsWork(); PopIsOpen = true; }); }
        }

        public ICommand ClosePop 
        {
            //ZhuifengLib.Keyboard.Press(Key.Tab);
            get { return new DelegateCommand(() => {  PopIsOpen = false; }); }
        }
        #endregion




    }
}
