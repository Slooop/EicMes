using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using ZhuifengLib;
using System.Windows.Media;
using System;
using System.Windows;

namespace MES.ModuleBPM
{
    class OrderFormShowViewModule : ViewModelBase
    {
        public OrderFormShowViewModule()
        {
          
        }
        #region 下拉菜单数据源
        MES.Server.BLL.SYS_TypeList tp_bll = new Server.BLL.SYS_TypeList();

        //工单状态列表
        public List<string> LsOrderState { get { return tp_bll.lsType(Server.BLL.TypeList.OrderState); } }

        #endregion 


        private string orderstate = "生产中" ;

        public string OrderState
        {
            get { return orderstate ; }
            set
            {
                orderstate  = value;
                this.RaisePropertyChanged("OrderState");
            }
        }

        private string orderid;

        public string OrderID
        {
            get { return orderid; }
            set
            {
                orderid = value;
                this.RaisePropertyChanged("OrderID");
            }
        }

          

        


        private List<BPM_OrderState> lsOrderStates = new List<BPM_OrderState>();

        public List<BPM_OrderState> LsOrderStates
        {
            get { return lsOrderStates; }
            set
            {
                lsOrderStates = value;
                this.RaisePropertyChanged("LsOrderStates");
            }
        }
      
        

      
       
        public ICommand GetOrderStateList
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MES.Com.MyUserControl.Landing land = new Com.MyUserControl.Landing(() =>
                    {
                        MES.Server.BLL.BPM_Order bll_order = new Server.BLL.BPM_Order();
                        List<BPM_OrderState> temOrderStateList = new List<BPM_OrderState>(); 
                        List<MES.Server.Model.BPM_Order> lsorder =  !orderid.IsNullOrEmpty() ? bll_order.GetModelList("OrderID ='"+orderid+"'") : bll_order.GetModelList("State='"+orderstate+"'");
                        foreach(MES.Server.Model.BPM_Order temOrder in lsorder)
                        {
                            BPM_OrderState temorderstate = new BPM_OrderState();
                            temorderstate.Order = temOrder;
                            temOrderStateList.Add(temorderstate);
                        }
                        LsOrderStates = temOrderStateList;
                    });
                    land.Start();
                });
            }
        }




      
    }

    public partial class BPM_OrderState
    {
        private MES.Server.Model.BPM_Order order;

        public MES.Server.Model.BPM_Order Order
        {
            get { return order; }
            set
            {
                order = value;
                MES.Server.BLL.BPM_WIP bll_v = new Server.BLL.BPM_WIP();
                LsState = bll_v.GetModelList("OrderID = '" + order.OrderID + "'");
            }
        }

        private  List<MES.Server.Model.BPM_WIP> lsstate = new List<MES.Server.Model.BPM_WIP>();

        public  List<MES.Server.Model.BPM_WIP> LsState
        {
            get { return lsstate; }
            set
            {
                lsstate = value;
            }
        }

        public Visibility IsVisible                                 //是否显示提醒选择框
        {
            get
            {
                DateTime end = DateTime.ParseExact(order.EndDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                DateTime NowDate = MES.Common.GetDATime.GetTime();
                return order.IsRemind && end.Subtract(NowDate).Days < 3 ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public Brush OrderIDForeground                              //根据是否提醒 选择显示字体颜色
        {
            get
            {
                return IsVisible == Visibility.Visible ? new SolidColorBrush(Color.FromRgb(255, 0, 0)) : new SolidColorBrush(Color.FromRgb(78, 29, 76));
            }
        }


        private bool isRemind = new bool();
        public bool IsRemind         //CheckBox选择项 隐藏提醒
        {
            get { return isRemind; }
            set
            {
                isRemind = value;
                MES.Server.BLL.BPM_Order bll = new Server.BLL.BPM_Order();
                order.IsRemind = false;
                bll.Update(order);
            }
        }
        

      


     


      
    }
}


