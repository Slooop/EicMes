using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using MES.Server.Model;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.Data;
using System.ComponentModel;
using System.Windows.Data;
using ZhuifengLib;
using System.Windows;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MES.ModuleBPM
{

    /// <summary>
    /// 控制界面中对应的DataGrid的宽度
    /// </summary>
    public class WidthView : ViewModelBase
    {

        private Visibility isVisibilityWorkHours = Visibility.Hidden;

        public Visibility IsVisibilityWorkHours
        {
            get { return isVisibilityWorkHours; }
            set
            {
                isVisibilityWorkHours = value;
                this.RaisePropertyChanged("IsVisibilityWorkHours");
            }
        }

        private Visibility isVisibilityUser = Visibility.Hidden;

        public Visibility IsVisibilityUser
        {
            get { return isVisibilityUser; }
            set
            {
                isVisibilityUser = value;
                this.RaisePropertyChanged("IsVisibilityUser");
            }
        }




        #region 宽度属性

        private int? column0 = null;

        public int? Column0
        {
            get { return column0; }
            set
            {
                column0 = value;
                this.RaisePropertyChanged("Column0");
            }
        }

        private int? column1 = 0;

        public int? Column1
        {
            get { return column1; }
            set
            {
                column1 = value;
                this.RaisePropertyChanged("Column1");
            }
        }


        private int? column2 = 0;

        public int? Column2
        {
            get { return column2; }
            set
            {
                column2 = value;
                this.RaisePropertyChanged("Column2");
            }
        }

        private int? column3 = 0;

        public int? Column3
        {
            get { return column3; }
            set
            {
                column3 = value;
                this.RaisePropertyChanged("Column3");
            }
        }

        private int? column4 = 0;

        public int? Column4
        {
            get { return column4; }
            set
            {
                column4 = value;
                this.RaisePropertyChanged("Column4");
            }
        }

        #endregion

        #region 控制事件
        /**********************************   委托事件与   **************************************************/

        public delegate void OrderOnChangedHandler();        //委托定义
        public event OrderOnChangedHandler Order_Changed;      //事件定义 



        /// <summary>
        /// 触发修改_Order
        /// </summary>                          
        public virtual void onOrderChanged()
        {
            if (Order_Changed != null) { IsVisibilityWorkHours = Visibility.Hidden; IsVisibilityUser = Visibility.Hidden; Order_Changed(); }
        }

        public delegate void WorkHoursOnChangedHandler();        //委托定义
        public event WorkHoursOnChangedHandler WorkHours_Changed;      //事件定义 获取3D数据

        /// <summary>
        /// 触发修改_WorkHours
        /// </summary>                          
        public virtual void onWorkHours_Changed()
        {
            if (WorkHours_Changed != null) { IsVisibilityWorkHours = Visibility.Visible; WorkHours_Changed(); }
        }

        public delegate void UserOnChangedHandler();        //委托定义
        public event UserOnChangedHandler User_Changed;      //事件定义 获取3D数据

        /// <summary>
        /// 触发修改_WorkHours
        /// </summary>                          
        public virtual void onUser_Changed()
        {
            if (User_Changed != null) { IsVisibilityUser = Visibility.Visible; User_Changed(); }
        }

        #endregion


    }

    /// <summary>
    /// OrderOverViewViewModule 基类 存放用于与界面进行交互的基类
    /// </summary>
    public class OrderOverViewViewModelBase : ViewModelBase
    {
        protected List<BPM_Daily> lsAllDaily = new List<BPM_Daily>();


        protected ObservableCollection<BPM_Daily> lsDailyOrder = new ObservableCollection<BPM_Daily>();

        public ICollectionView LsDailyOrder
        {
            get { return CollectionViewSource.GetDefaultView(lsDailyOrder); }
        }




        //private List<BPM_Daily> lsDailyOrder = new List<BPM_Daily>();
        ///// <summary>
        ///// 工单总览结构体
        ///// </summary>
        //public List<BPM_Daily> LsDailyOrder
        //{
        //    get { return lsDailyOrder; }
        //    set
        //    {
        //        lsDailyOrder = value;
        //        this.RaisePropertyChanged("LsDailyOrder");
        //    }
        //}

        //private List<BPM_Daily> lsDailyWorkHours = new List<BPM_Daily>();
        ///// <summary>
        ///// 工单中各工序中工时汇总表
        ///// </summary>
        //public List<BPM_Daily> LsDailyWorkHours
        //{
        //    get { return lsDailyWorkHours; }
        //    set
        //    {
        //        lsDailyWorkHours = value;
        //        this.RaisePropertyChanged("LsDailyWorkHours");
        //    }
        //}

        public ObservableCollection<BPM_Daily> lsDailyWorkHours = new ObservableCollection<BPM_Daily>();

        public ICollectionView LsDailyWorkHours
        {
            get { return CollectionViewSource.GetDefaultView(lsDailyWorkHours); }

        }


        //private List<BPM_Daily> lsDailyUser = new List<BPM_Daily>();
        ///// <summary>
        ///// 工序中各人员生产工时明细
        ///// </summary>
        //public List<BPM_Daily> LsDailyUser 
        //{
        //    get { return lsDailyUser; }
        //    set
        //    {
        //        lsDailyUser = value;
        //        this.RaisePropertyChanged("LsDailyUser");
        //    }
        //}

        public ObservableCollection<BPM_Daily> lsDailyUser = new ObservableCollection<BPM_Daily>();

        public ICollectionView LsDailyUser
        {
            get { return CollectionViewSource.GetDefaultView(lsDailyUser); }

        }


        /// <summary>
        /// 工单状态
        /// </summary>
        private List<string> orderStateList = Business.SysHelper.TypeList.lsType(Server.BLL.TypeList.OrderState);
        public List<string> OrderStateList
        {
            get { return orderStateList; }
            set
            {
                orderStateList = value;
                this.RaisePropertyChanged("OrderStateList");
            }
        }

        private string state;
        /// <summary>
        /// 工单状态
        /// </summary>
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                this.RaisePropertyChanged("State");
            }
        }

        private DateTime startDate = DateTime.Now;
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                this.RaisePropertyChanged("StartDate");
            }
        }

        private DateTime endDate = DateTime.Now;
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                this.RaisePropertyChanged("EndDate");
            }
        }

        private string orderID;

        public string OrderID
        {
            get { return orderID; }
            set
            {
                orderID = value;
                this.RaisePropertyChanged("OrderID");
            }
        }



        WidthView widthView = new WidthView();
        /// <summary>
        /// 控制界面各宽度
        /// </summary>
        public WidthView WidthView
        {
            get { return widthView; }
            set
            {
                widthView = value;
                this.RaisePropertyChanged("WidthView");
            }
        }

    }


    /// <summary>
    /// 数据控制类——继承自OrderOverViewViewModule
    /// </summary>
    public class OrderOverViewViewModel : OrderOverViewViewModelBase
    {

        public OrderOverViewViewModel()
        {
            WidthView.Order_Changed += WidthView_Order_Changed;
            WidthView.User_Changed += WidthView_User_Changed;
            WidthView.WorkHours_Changed += WidthView_WorkHours_Changed;
        }

        private void WidthView_WorkHours_Changed()
        {
            WidthView.Column0 = 180;
            WidthView.Column1 = 8;
            WidthView.Column2 = null;
            WidthView.Column3 = 0;
            WidthView.Column4 = 0;
        }

        private void WidthView_User_Changed()
        {
            WidthView.Column0 = 180;
            WidthView.Column1 = 8;
            WidthView.Column2 = 250;
            WidthView.Column3 = 8;
            WidthView.Column4 = null;
        }

        private void WidthView_Order_Changed()
        {
            WidthView.Column0 = null;
            WidthView.Column1 = 0;
            WidthView.Column2 = 0;
            WidthView.Column3 = 0;
            WidthView.Column4 = 0;
        }

        /// <summary>
        /// 点击工单时更改界面宽度
        /// </summary>
        public ICommand ChageWithOrderCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    WidthView.onOrderChanged();
                });
            }
        }

        /// <summary>
        /// 点击工时时的界面宽度
        /// </summary>
        public ICommand ChageWithWorkHoursCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    WidthView.onWorkHours_Changed();
                });
            }
        }

        /// <summary>
        /// 点击详情时的界面宽度
        /// </summary>
        public ICommand ChageWithUserCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    WidthView.onUser_Changed();
                });
            }
        }


        /// <summary>
        /// 获取工单日报列表
        /// </summary>
        public ICommand GetDailyOrderList
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Com.MyUserControl.Landing td = new Com.MyUserControl.Landing(() =>
                    {
                        lsAllDaily.Clear();
                        lsDailyOrder.Clear();
                        if (!OrderID.IsNullOrEmpty())  //如果输入工单单号
                            lsAllDaily = Business.BpmHelper.Daily.GetModelList(" OrderID='" + OrderID + "'");
                        else if (State == "已完工")   //如果状态为已完工
                            lsAllDaily =  MES.Business.BpmHelper.Daily.GetModelList(MES.Business.BpmHelper.Order.GetModelList(" State = '已完工' AND (ActualEndDate >= '" + StartDate.ToString("yyyyMMdd") + "') AND (ActualEndDate <= '" + EndDate.ToString("yyyyMMdd") + "')")).OrderBy(p => p.OrderID).ToList();
                        else
                            lsAllDaily = Business.BpmHelper.Daily.GetModelList(" (State <> '已完工') ").OrderBy(p => p.OrderID).ToList();

                        CeeateLsDailyOrder();
                        lsDailyWorkHours.Clear();
                        lsDailyUser.Clear();
                        WidthView.onOrderChanged();
                    });
                    td.Start();
                });
            }
        }

        //要复制的实例必须可序列化，包括实例引用的其它实例都必须在类定义时加[Serializable]特性。  
        public static T Copy<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制     
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }


        private void CeeateLsDailyOrder()
        {
            var temAllDaily = Copy(lsAllDaily);
            foreach (var daily in temAllDaily)
            {
                if (lsDailyOrder.FirstOrDefault(x => x.OrderID == daily.OrderID) == null)
                {
                    //计算累计产出 = 工单中结束站的总和
                    daily.Qty = lsAllDaily.Where(p => p.OrderID == daily.OrderID && p.ProcessSign== "结束站").Sum(p => p.Qty);
                    //累计标准工时 = 求和每道工序的累计标准工时
                    daily.TotalWorkHoursStandard = decimal.Parse(lsAllDaily.Where(p => p.OrderID == daily.OrderID).Sum(p => p.TotalWorkHoursStandard).Value.ToString("F2"));
                    //累计生产工时 = 求和每道工序的累计生产工时工时
                    daily.WorkHours = lsAllDaily.Where(p => p.OrderID == daily.OrderID).Sum(p => p.WorkHours);
                    //差值计算 标准工时 - 实际使用工时
                    daily.Difference_StandardAndWork = Convert.ToDouble((daily.TotalWorkHoursStandard - daily.WorkHours).Value.ToString("F2"));
                    lsDailyOrder.Add(daily);
                }
            }

        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        public ICommand ExportToExcel
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    lsAllDaily.ExportToExcel(true, 1);
                });
            }
        }

        /// <summary>
        /// 选择工单=>获取该工单中的每道工序的工时
        /// </summary>
        BPM_Daily selectOrderDaily = new BPM_Daily();
        public BPM_Daily SelectOrderDaily
        {
            get { return selectOrderDaily; }
            set
            {
                selectOrderDaily = value;
                this.RaisePropertyChanged("SelectOrderDaily");
               
                if (value != null)
                {
                    var temOrderDailyList = lsAllDaily.Where(x => x.OrderID == value.OrderID).ToList();
                    lsDailyWorkHours.Clear();
                   var ptList = MES.Business.BpmHelper.Order.GetModel(value.OrderID).Product.ProcessList;
                    foreach (var process in ptList)
                    {
                        lsDailyWorkHours.Add(new BPM_Daily
                        { 
                            OrderID = value.OrderID,
                            ProcessID = process.ProcessID,
                            ProcessName = process.ProcessName,
                            Qty = temOrderDailyList.Where(x => x.ProcessID == process.ProcessID).Sum(x => x.Qty),
                            WorkHours = temOrderDailyList.Where(x => x.ProcessID == process.ProcessID).Sum(x => x.WorkHours),
                        });
                    }
                    lsDailyWorkHours.OrderBy(x => x.ProcessNum);
                }
            }
        }

        /// <summary>
        /// 选择工序=>获取该工序中所有做过的员工的日报
        /// </summary>
        BPM_Daily selectProcessDaily = new BPM_Daily();
        public BPM_Daily SelectProcessDaily
        {
            get { return selectProcessDaily; }
            set
            {
                if (value != null)
                {
                    lsDailyUser.Clear();
                    var tem = lsAllDaily.Where(x => x.OrderID == value.OrderID && x.ProcessID == value.ProcessID).OrderBy(x => x.JobNum);
                    foreach (var tt in tem) lsDailyUser.Add(tt);
                }
                selectProcessDaily = value;
                this.RaisePropertyChanged("SelectProcessDaily");
            }
        }
    }





}
