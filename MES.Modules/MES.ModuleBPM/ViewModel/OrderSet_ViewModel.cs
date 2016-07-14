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
      //  public OrderRelevanceViewModel OrderRelevanceVm = new OrderRelevanceViewModel();

        private OrderRelevanceViewModel orderRelevanceVm = new OrderRelevanceViewModel(); 
        public OrderRelevanceViewModel OrderRelevanceVm
        {
            get { return orderRelevanceVm; }
            set
            {
                orderRelevanceVm = value;
                this.RaisePropertyChanged("OrderRelevanceVm");
            }
        }


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
        /// 控制键盘 按下Tab键
        /// </summary>
        public RelayCommand KeyTabCommand => new RelayCommand(() => { ZhuifengLib.Keyboard.Press(Key.Tab); });

    }


    /**
    * 功 能：对工单中的附加工单进行操作
    * 类 名：OrderRelevanceViewModel 
    *
    * Ver    变更日期          负责人  变更内容
    * ───────────────────────────────────
    * V0.01  2015-12-3 11:43    大熊    初版
    *
    * Copyright (c) 2015 LightMaster Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
    *└──────────────────────────────────┘
    **/
    class OrderRelevanceViewModel : ViewModelBase
    {

        private BPM_Order order = null;
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
                if (order != null)
                    OrderRelevanceList =
                        new ObservableCollection<BPM_OrderRelevance>(BpmHelper.OrderRelevance.GetModelList("MainOrder = '" + order.OrderID + "'"));
            }
        }

        private BPM_OrderRelevance orderRelevance = new BPM_OrderRelevance();
        /// <summary>
        /// 附加工单
        /// </summary>
        public BPM_OrderRelevance OrderRelevance
        {
            get { return orderRelevance; }
            set
            {
                orderRelevance = value;
                this.RaisePropertyChanged("OrderRelevance");
            }
        }

        
        /// <summary>
        ///  选择附加工单
        /// </summary>
        public BPM_OrderRelevance SelectOrderRelevance { get; set; }
         

        private ObservableCollection<BPM_OrderRelevance> orderRelevanceList = new ObservableCollection<BPM_OrderRelevance>();
       
        /// <summary>
        /// 附加工单列表
        /// </summary>
        public ObservableCollection<BPM_OrderRelevance> OrderRelevanceList
        {
            get { return orderRelevanceList; }
            set
            {
                orderRelevanceList = value;
                this.RaisePropertyChanged("OrderRelevanceList");
            }
        }



        /// <summary>
        /// 添加附加工单
        /// </summary>
        public RelayCommand AddCommand => new RelayCommand(() =>
        {
            if (order == null) { MyMessage.MessageInfo("主工单不能为空！"); return; }
            if (OrderRelevance.AdditionalOrder.IsNullOrEmpty() || OrderRelevance.AdditionalOrder.Length < 10)
            {
                MyMessage.MessageInfo("附加工单为空或小于10位，请检查后重新输入!"); return;
            }
            var temOrderRelevance = BpmHelper.Order.GetModel(OrderRelevance.AdditionalOrder);
            if (temOrderRelevance == null) { MyMessage.MessageInfo("未找到附加工单的任何信息，请确认输入是否正确!"); return; }
            //对附加工单的 主工单，品名，规格 进行赋值 
            OrderRelevance.MainOrder = Order.OrderID;
            OrderRelevance.ProductName = temOrderRelevance.ProductName;
            OrderRelevance.Spec = temOrderRelevance.Spec;
            //添加工单到数据库 并添加到附加工单列表中
            if (BpmHelper.OrderRelevance.Add(OrderRelevance))
                OrderRelevanceList.Add(OrderRelevance);
            else MyMessage.MessageInfo("添加失败！");

        });


        /// <summary>
        ///  删除附加工单
        /// </summary>
        public RelayCommand DeleteCommand => new RelayCommand(() =>
        {
            if (SelectOrderRelevance ==null)
                return;

            if (BpmHelper.OrderRelevance.Delete(SelectOrderRelevance.AdditionalOrder))
            {
                OrderRelevanceList.Remove(SelectOrderRelevance);
            }
            else MyMessage.MessageInfo("附件工单删除失败，导致此失败的原因可能是工单中不存在此工单的任何信息！");
        });

    }
}
