using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MES.Server.Model;
using ZhuifengLib;
using MES.Business;
using msg = ZhuifengLib.MessageShow.Message;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.Generic;

namespace MES.ModuleBPM
{

    /**
    * 功 能： 工单设置ViewModel类
    * 类 名： OrderSetViewModel
    *
    * Ver    变更日期                     负责人  变更内容
    * ───────────────────────────────────
    * V0.01  2015-12-3 11:45    大熊    初版
    *
    * Copyright (c) 2015 LightMaster Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
    *└──────────────────────────────────┘
    **/
    class OrderSetViewModel : ViewModelBase
    {

        private Server.BLL.SYS.ListSource lsSources = null;
        /// <summary>
        /// 下拉列表数据源=》部门，站别，班别，列表
        /// </summary>
        public Server.BLL.SYS.ListSource LsSources => lsSources = lsSources = (lsSources == null ? new Server.BLL.SYS.ListSource() : lsSources);
     

       


        private BPM_Order order = new BPM_Order();
        /// <summary>
        /// 工单
        /// </summary>
        public BPM_Order Order                                    
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
                OrderRelevanceVm.Order = value;
            }
        }

        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID
        {
            get { return Order.OrderID; }
            set
            {
                Order.OrderID = value;
                this.RaisePropertyChanged("OrderID");
                if ((Order = BpmHelper.Order.GetModel(Order.OrderID))  == null)
                    Order = new BPM_Order();
            }
        }

        /// <summary>
        ///  保存工单
        /// </summary>
        public RelayCommand SaveOrderCommand => new RelayCommand(() =>
        {
            if (!Business.BpmHelper.Order.Add(Order)) return;
            Order = new BPM_Order();
            msg.MessageInfo("添加成功！");
        });


        /// <summary>
        /// 
        /// </summary>
        public RelayCommand OverrideOrderCommand => new RelayCommand(() =>
        {
            if (OrderID.IsNullOrEmpty()) return;
            BpmHelper.Order.Delete(OrderID); //清除工单信息
            BpmHelper.Wip.Delete(OrderID);   //清除WIP信息
            if ((Order = BpmHelper.Order.GetModel(Order.OrderID)) == null)
                Order = new BPM_Order();
        });

        /// <summary>
        /// 控制键盘 按下Tab键
        /// </summary>
        public RelayCommand KeyTabCommand => new RelayCommand(() => { ZhuifengLib.Keyboard.Press(Key.Tab); });


        /******************************************************  部件  ***********************************************************/

        private OrderRelevanceViewModel orderRelevanceVm = new OrderRelevanceViewModel();
        /// <summary>
        /// 附加工单操作
        /// </summary>
        public OrderRelevanceViewModel OrderRelevanceVm
        {
            get { return orderRelevanceVm; }
            set
            {
                orderRelevanceVm = value;
                this.RaisePropertyChanged("OrderRelevanceVm");
            }
        }

     

      
       
    }


   


}
