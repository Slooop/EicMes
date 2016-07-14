using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MES.Server.Model;
using Microsoft.Practices.Prism.Commands;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using ZhuifengLib;
using msg = ZhuifengLib.MessageShow.Message;

// ReSharper disable once CheckNamespace
namespace MES.ModuleBPM
{
    /// <summary>
    /// 日报录入 ViewModel基类
    /// </summary>
    internal class DailyViewModelBase : ViewModelBase
    {
        public DailyViewModelBase()
        {
            GetBasisDate("");
            lsSources = new Server.BLL.SYS.ListSource();
            lsSources.Workstation.Remove("办公室");
        }

        #region 列表

        /// <summary>
        /// 所有未完工的工单
        /// </summary>
        private List<BPM_Order> allNotOverOrder = new List<BPM_Order>();

        /// <summary>
        /// 所有工序列表
        /// </summary>
        private List<BPM_Process> allProcess = new List<BPM_Process>();

        /// <summary>
        /// 所有用户列表
        /// </summary>
        private List<HR_User> allUserList = new List<Server.Model.HR_User>();

        private List<BPM_WIP> orderWipList = new List<BPM_WIP>();
        ///// <summary>
        ///// 用户日报列表
        ///// </summary>
        //protected ObservableCollection<BPM_Daily> userDailyList = new ObservableCollection<BPM_Daily>();  //待自动分配工时的列表
        //public ICollectionView UserDailyList => CollectionViewSource.GetDefaultView(userDailyList);

        private ObservableCollection<BPM_Daily> userDailyList = new ObservableCollection<BPM_Daily>();

        public ObservableCollection<BPM_Daily> UserDailyList
        {
            get { return userDailyList; }
            set
            {
                userDailyList = value;
                this.RaisePropertyChanged("UserDailyList");
            }
        }

        /// <summary>
        /// 已录入数据列表
        /// </summary>
        protected ObservableCollection<BPM_Daily> savaDailyList = new ObservableCollection<BPM_Daily>();

        public ICollectionView SavaDailyList => CollectionViewSource.GetDefaultView(savaDailyList);

        /// <summary>
        /// 保存的汇总日报列表
        /// </summary>
        protected ObservableCollection<BPM_Daily> savaTotalDailyList = new ObservableCollection<BPM_Daily>();

        public ICollectionView SavaTotalDailyList => CollectionViewSource.GetDefaultView(savaTotalDailyList);

        /// <summary>
        ///  日报汇总 按人员
        /// </summary>
        protected ObservableCollection<BPM_Daily> totalDailyUserList = new ObservableCollection<BPM_Daily>();

        public ICollectionView TotalDailyUserList => CollectionViewSource.GetDefaultView(totalDailyUserList);

        /// <summary>
        /// 汇总日报 按工序
        /// </summary>
        private ObservableCollection<BPM_Daily> totalDailyProcessList = new ObservableCollection<BPM_Daily>();

        public ICollectionView TotalDailyProcessList => CollectionViewSource.GetDefaultView(totalDailyProcessList);

        #endregion 列表

        #region 属性

        private string errInfo = string.Empty;

        /// <summary>
        /// 警告提醒
        /// </summary>
        public string ErrInfo
        {
            get { return errInfo; }
            set
            {
                errInfo = value;
                this.RaisePropertyChanged("ErrInfo");
            }
        }

        private BPM_Order order = new BPM_Order();

        /// <summary>
        /// 工单信息
        /// </summary>
        public BPM_Order Order
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }

        private BPM_Daily daily = new BPM_Daily();

        /// <summary>
        /// 日报
        /// </summary>
        public BPM_Daily Daily
        {
            get { return daily; }
            set
            {
                daily = value;
                this.RaisePropertyChanged("Model");
            }
        }

        private BPM_WIP wip = new BPM_WIP();

        /// <summary>
        /// WIP
        /// </summary>
        public BPM_WIP WIP
        {
            get { return wip; }
            set
            {
                wip = value;
                this.RaisePropertyChanged("WIP");
            }
        }

        private decimal? _worksHours;

        /// <summary>
        /// 生产工时
        /// </summary>
        public decimal? WorksHours
        {
            get { return _worksHours; }
            set
            {
                _worksHours = value;
                daily.WorkHours = value;
                if (value != null)
                {
                    if (VF_Efficiency() == false) WorksHours = null;
                }
                this.RaisePropertyChanged("WorksHours");
            }
        }

        private BPM_Process process;

        /// <summary>
        /// 工序
        /// </summary>
        public BPM_Process Process         //工序
        {
            get { return process; }
            set
            {
                process = value;
                this.RaisePropertyChanged("Process");
            }
        }

        private Brush efficiencyForeground = new SolidColorBrush(Color.FromRgb(0, 90, 171));

        /// <summary>
        /// 字体颜色
        /// </summary>
        public Brush EfficiencyForeground
        {
            get { return efficiencyForeground; }
            set
            {
                efficiencyForeground = value;
                this.RaisePropertyChanged("EfficiencyForeground");
            }
        }

        private string efficiency;

        /// <summary>
        /// 效率
        /// </summary>
        public string Efficiency
        {
            get { return efficiency; }
            set
            {
                efficiency = value;
                this.RaisePropertyChanged("Efficiency");
            }
        }

        private string totalInfo = string.Empty;

        /// <summary>
        /// 报表汇总信息文字表述
        /// </summary>
        public string TotalInfo
        {
            get { return totalInfo; }
            set
            {
                totalInfo = value;
                this.RaisePropertyChanged("TotalInfo");
            }
        }

        private Server.BLL.SYS.ListSource lsSources;

        /// <summary>
        /// 下拉列表数据源=》部门，站别，班别，列表
        /// </summary>
        public Server.BLL.SYS.ListSource LsSources
        {
            get
            {
                return lsSources;
            }
            set
            {
                lsSources = value;
                this.RaisePropertyChanged("LsSources");
            }
        }

        /// <summary>
        /// 良品数量
        /// </summary>
        public int? QtyOK
        {
            get { return Daily.QtyOK; }
            set
            {
                Daily.QtyOK = value;
                if (QtyOK != null)
                {
                    if (VF_Efficiency() == false) { QtyOK = null; }
                }
                this.RaisePropertyChanged("QtyOK");
            }
        }

        private string _OrderId;

        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID                                 //工单单号
        {
            get { return _OrderId; }
            set
            {
                _OrderId = value;

                if (!value.IsNullOrEmpty()) //如果值不为空 进行验证
                {
                    if (VF_OrderID(value) == false)  //如果验证不通过 将工单单号赋值为空
                    {
                        OrderID = string.Empty;
                    }
                }

                this.RaisePropertyChanged("OrderID");
            }
        }

        private string _rjremind = string.Empty;

        /// <summary>
        /// 附加工单提醒符号
        /// </summary>
        public string RjRemind
        {
            get { return _rjremind; }
            set
            {
                _rjremind = value;
                this.RaisePropertyChanged("RjRemind");
            }
        }

        private string _processId;                           //工序ID

        /// <summary>
        /// 工序ＩＤ
        /// </summary>
        public string ProcessID
        {
            get { return _processId; }
            set
            {
                _processId = value.ToUpper();
                VF_Process(value);
                this.RaisePropertyChanged("ProcessID");
            }
        }

        private string _userId;

        /// <summary>
        /// 工号
        /// </summary>
        public string UserID
        {
            get { return _userId; }
            set
            {
                _userId = value;
                this.RaisePropertyChanged("UserID");
                GetUserDailyList(value);
            }
        }

        private string _username;

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        private BPM_Daily selectDaily = new BPM_Daily();

        /// <summary>
        /// 选择的待删除的日报
        /// </summary>
        public BPM_Daily SelectDaily
        {
            get { return selectDaily; }
            set
            {
                selectDaily = value;
                this.RaisePropertyChanged("SelectDaily");
            }
        }

        private BPM_Daily selectTotalUser;

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public BPM_Daily SelectTotalUser
        {
            get { return selectTotalUser; }
            set
            {
                selectTotalUser = value;
                this.RaisePropertyChanged("SelectTotalUser");
                if (value == null) return;
                UserID = value.JobNum;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 验证输入的工单单号
        /// </summary>
        /// <param name="value"></param>
        private bool VF_OrderID(string OrderID)
        {
            Order = allNotOverOrder.FirstOrDefault(p => p.OrderID == OrderID);
            var RelevanceOrder = Business.BpmHelper.OrderRelevance.GetModel(_OrderId);
            if (OrderID.Length < 10)
            {
                msg.MessageInfo("工单单号不能小于十位！");
                return false;
            }
            else if (OrderID.Substring(0, 3) == "527" && daily.Workstation != "散件" && daily.Workstation != "散件包装")
            {
                msg.MessageInfo("录入不合法，\r\n工单为散件工单，但您的站别不属于散件！");
                return false;
            }
            else if (Order == null)
            {
                GetBasisDate(OrderID);//刷新本地缓存
                Order = allNotOverOrder.FirstOrDefault(p => p.OrderID == OrderID);
                if (order == null)
                {
                    msg.MessageInfo("未找到此工单或该工单已完工，请检查输入");
                    return false;
                }
                else goto GoOnVF;  //跳转至GoOnVF标签 继续检测
            }
            else goto GoOnVF;      //跳转至GoOnVF标签 继续检测

            //GoOnVF标签 继续检测
            GoOnVF:
            if (Order != null && order.Product == null)  //工单不为空 产品为空
            {
                msg.MessageInfo("此工单未指定任何与之匹配的工序模板，请联系相关负责人！");
                return false;
            }
            else if (Order.State == "已完工" || Order.State == "指定完工")
            {
                msg.MessageInfo("工单已完工，请慎重录入！");
                return false;
            }
            else if (Order.Product != null && process != null && Order.Product.ProcessList != null)
            {
                var Pt = Order.Product.ProcessList.FirstOrDefault(x => x.ProcessID == process.ProcessID);
                if (Pt == null)
                {
                    msg.MessageInfo("此工单中不存在此工序！");
                    return false;
                }
                else goto GoOnVF2; //跳转至GoOnVF2标签 继续检测
            }
            else goto GoOnVF2;     //跳转至GoOnVF2标签 继续检测

            GoOnVF2:
            if (!Order.WorkShop.IsNullOrEmpty() && ((HR_User)Common.UserInfo.MyUserInfo).Workshop != Order.WorkShop)
            {
                MyMessage.MessageInfo("工单与您所在车间不匹配！\r\n该工单生产车间为：" + Order.WorkShop);
                return true;
            }
            else if (!VF_EnterCount()) { return false; } //验证工单录入数量是否大于工单总批量
            else if (RelevanceOrder != null && RelevanceOrder.AdditionalOrder != RelevanceOrder.MainOrder)
            {
                MyMessage.MessageInfo("禁止输入！\r\n 此工单为附加工单，该工单的主工单为：" + RelevanceOrder.MainOrder);
                return false;
            }
            else {
                RjRemind = Business.BpmHelper.OrderRelevance.GetModelList("MainOrder = '" + _OrderId + "'").Count < 1 ? string.Empty : "*";
                return true;
            }
        }

        /// <summary>
        /// 验证工序
        /// </summary>
        /// <param name="value"></param>
        private void VF_Process(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                if (!_processId.IsNullOrEmpty() && _processId.Length > 1)
                {
                    Process = allProcess.FirstOrDefault(p => p.ProcessID == _processId);
                    if (Order != null && order.Product == null)  //工单不为空 产品为空
                    {
                        msg.MessageInfo("此工单未指定任何与之匹配的工序模板，请联系相关负责人！");
                        ProcessID = string.Empty;
                    }
                    else if (process == null)
                    {
                        msg.MessageInfo("未找到此工序，请重新输入！");
                        ProcessID = string.Empty;
                    }
                    else if (Order != null && Order.Product != null && Order.Product.ProcessList != null)
                    {
                        var Pt = Order.Product.ProcessList.FirstOrDefault(x => x.ProcessID == process.ProcessID);
                        if (Pt == null)
                        {
                            msg.MessageInfo("此工单中不存在此工序！");
                            ProcessID = string.Empty;
                        }
                    }
                }
                else { msg.MessageInfo("输入字符长度需大于1"); ProcessID = string.Empty; }
            }
            VF_EnterCount();
        }

        /// <summary>
        /// 验证录入的数量是否超过工单总数
        /// </summary>
        /// <returns></returns>
        private bool VF_EnterCount()
        {
            if (order != null && order.Product != null && order.Product.ProcessList != null && process != null)
            {
                var pt = order.Product.ProcessList.FirstOrDefault(x => x.ProcessID == process.ProcessID);
                if (pt != null && pt.IsCheckTotalCount)
                {
                    orderWipList = Business.BpmHelper.Wip.GetOrderWIPList(order);
                    WIP = orderWipList.FirstOrDefault(x => x.ProcessID == process.ProcessID);
                    if (WIP != null && QtyOK > WIP.Qty_NotInput)
                    {
                        msg.MessageInfo("录入的数量不能大于工单总量！");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    orderWipList = Business.BpmHelper.Wip.GetOrderWIPList(order);
                    WIP = orderWipList.FirstOrDefault(x => x.ProcessID == process.ProcessID);
                    return true;
                }
            }
            else
            {
                return true;  //设置为True
            }
        }

        /// <summary>
        /// 验证效率
        /// </summary>
        private bool VF_Efficiency()
        {
            try
            {
                //生产效率计算公式 （实际产出数量*标准工时/实际工时）* 100%
                if (process != null && daily.QtyOK != null && daily.WorkHours != null)
                {
                    decimal? tem = ((((daily.QtyNG + daily.QtyOK) * process.StandardHours) / (daily.WorkHours * 60)) * 100);
                    if (tem > 180) { msg.MessageInfo("非法录入，效率超过180"); return false; }
                    else
                    {
                        if (tem > 120 || tem < 80) EfficiencyForeground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        else EfficiencyForeground = new SolidColorBrush(Color.FromRgb(0, 90, 171));
                        Efficiency = tem.Value.ToString("F2");
                        //验证累计数量是否大于工单总量
                        if (!VF_EnterCount())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else { return true; }
            }
            catch
            {
                msg.MessageInfo("未能进行效率验证，请手动进行效率验证！\r\n或检查是否设置标准工时!");
                return true;
            }
        }

        /// <summary>
        /// 获取基础数据
        /// </summary>
        private void GetBasisDate(string orderID)
        {
            //Thread t = new Thread(() =>
            //{
            allUserList = Business.HrHelper.User.GetModelList("");       //获取或有用户
            allProcess = Business.BpmHelper.Process.GetModelList("");    //获取所有工序
                                                                         //allNotOverOrder = Business.BpmHelper.Order.GetModelList(" (State IN ('已发料', '未生产', '生产中'))"); //获取所有未完工的工单
            var temorder = Business.BpmHelper.Order.GetModel(orderID);
            if (temorder != null)
            {
                allNotOverOrder.Add(temorder);
            }

            //});
            //t.IsBackground = true;
            //t.Start();
        }

        /// <summary>
        /// 获取指定用户名的当日工序列表
        /// </summary>
        /// <param name="userID"></param>
        public void GetUserDailyList(string userID)
        {
            var user = allUserList.FirstOrDefault(p => p.Job_Num == userID);
            if (!userID.IsNullOrEmpty())
            {
                if (userID.Length > 5 && user != null)
                {
                    UserName = user.Name;
                    //第一遍
                    userDailyList.Clear();
                    var TuserDailyList = savaDailyList.Where(p => p.JobNum == userID).ToArray();
                    foreach (var temDaily in TuserDailyList)
                        UserDailyList.Add(temDaily);
                    //  UserDailyList = TuserDailyList.ToList();
                }
                else { msg.MessageInfo("未找到工号为：" + userID + "的员工\r\n请添加或重试!"); UserID = string.Empty; UserName = string.Empty; }
            }
        }

        /// <summary>
        /// 保存用户报表列表
        /// </summary>
        public void SavaUserDailyList()
        {
            // AllotHours(WorksHours, userDailyList);   暂时屏蔽自动分配生产工时功能
            foreach (BPM_Daily temModel in userDailyList)
            {
                // savaDailyList.Add(temModel);
                Business.BpmHelper.Daily.Add(temModel);
            }
            GetDailyListForDb();
            userDailyList.Clear();
        }

        /// <summary>
        /// 添加多个工单到日报列表
        /// </summary>
        protected void AddDailyToUserList_Much()
        {
            double sumOrderCount = 0;
            List<BPM_Order> fjOrderList = new List<BPM_Order>();
            foreach (BPM_OrderRelevance fjOrder in Business.BpmHelper.OrderRelevance.GetModelList("MainOrder = '" + OrderID + "'"))
                fjOrderList.Add(Business.BpmHelper.Order.GetModel(fjOrder.AdditionalOrder));
            sumOrderCount = fjOrderList.Sum(x => Convert.ToDouble(x.Count));

            var YetAllotWorkHoursOrderList = new List<BPM_Daily>();
            AllotWorkHours(sumOrderCount, fjOrderList, YetAllotWorkHoursOrderList);
        }

        /// <summary>
        /// 分配工时
        /// </summary>
        /// <param name="sumOrderCount">所有附加工单的总批量之和</param>
        /// <param name="fjOrderList">附加工单列表</param>
        /// <param name="YetAllotWorkHoursOrderList">已非配过的日报列表</param>
        private void AllotWorkHours(double sumOrderCount, List<BPM_Order> fjOrderList, List<BPM_Daily> YetAllotWorkHoursOrderList)
        {
            foreach (BPM_Order temOrder in fjOrderList)
            {
                if (Daily.Date != null)
                {
                    var temDatily = new BPM_Daily()
                    {
                        Department = Daily.Department,
                        ClientName = temOrder.ClientName,
                        OrderCount = Convert.ToInt32(temOrder.Count),
                        ProductName = temOrder.ProductName,
                        Spec = temOrder.Spec,
                        State = temOrder.State,
                        WorkShop = temOrder.WorkShop,
                        ProductID = temOrder.ProductID,
                        Month = Daily.Date.Value.Date.ToString("yyyyMM"),

                        Workstation = Daily.Workstation,
                        ClassType = Daily.ClassType,
                        ProcessID = Process.ProcessID,
                        ProcessName = Process.Name,
                        JobNum = UserID,
                        Name = UserName,
                        OrderID = temOrder.OrderID,
                        Date = Daily.Date.Value.Date,
                        DateTime = Daily.DateTime,
                        NotWorkHours = Daily.NotWorkHours,
                        StandardHours = Process.StandardHours * Process.Relax,
                        //计算附加工单的良品数量和生产工时
                        QtyOK =
                            Convert.ToInt32((Convert.ToDouble(temOrder.Count) / sumOrderCount) * Convert.ToDouble(Daily.QtyOK)),
                        QtyNG =
                            Convert.ToInt32((Convert.ToDouble(temOrder.Count) / sumOrderCount) * Convert.ToDouble(Daily.QtyNG)),

                        WorkHours =
                            Convert.ToDecimal(
                                ((Convert.ToDouble(temOrder.Count) / sumOrderCount) * Convert.ToDouble(Daily.WorkHours))
                                    .ToString("F0")),
                        Qty =
                            Convert.ToInt32((Convert.ToDouble(temOrder.Count) / sumOrderCount) * Convert.ToDouble(Daily.QtyOK)) +
                            Convert.ToInt32((Convert.ToDouble(temOrder.Count) / sumOrderCount) * Convert.ToDouble(Daily.QtyNG))
                    };
                    temDatily.Efficiency = Convert.ToDouble(((((temDatily.QtyNG + temDatily.QtyOK) * temDatily.StandardHours) / (temDatily.WorkHours * 60)) * 100).Value.ToString("F"));
                    temDatily.TotalWorkHoursNotRelax = (temDatily.Qty * process.StandardHours) / 60;  //未宽放 得到工时
                    temDatily.TotalWorkHoursStandard = (temDatily.Qty * temDatily.StandardHours) / 60;
                    if (temOrder != null && temOrder.Product != null && temOrder.Product.ProcessList != null)
                    {
                        var temPt = temOrder.Product.ProcessList.FirstOrDefault(p => p.ProcessID == Process.ProcessID);
                        temDatily.ProcessNum = temPt != null ? temPt.Num : 0;
                        temDatily.ProcessSign = temPt != null ? temPt.ProcessSign : "未设置";
                    }
                    //2015-12-10 添加  2016-1-12 8:11修改V0.0.1  张文明
                    if (fjOrderList[fjOrderList.Count - 1].Equals(temDatily)) //如果是最后一个
                    {
                        //对附加工单进行分配后 计算分配前的总工时 和分配后的总工时 差值 并将差值赋值给第一个工单
                        temDatily.Qty = Daily.Qty - YetAllotWorkHoursOrderList.Sum(p => p.Qty);
                        temDatily.WorkHours = Daily.WorkHours - YetAllotWorkHoursOrderList.Sum(p => p.WorkHours);
                    }
                    //添加
                    YetAllotWorkHoursOrderList.Add(temDatily);
                    userDailyList.Add(temDatily);
                    savaDailyList.Add(temDatily);
                    Business.BpmHelper.Daily.Add(temDatily);
                }
            }
        }

        /// <summary>
        /// 添加一个工单到日报列表
        /// </summary>
        protected void AddDailyToUserList_Single()
        {
            if (Daily.Date != null)
            {
                var temDatily = new BPM_Daily()
                {
                    Department = Daily.Department,
                    ClientName = Order.ClientName,
                    OrderCount = Convert.ToInt32(Order.Count),
                    ProductName = Order.ProductName,
                    Spec = Order.Spec,
                    State = Order.State,
                    WorkShop = Order.WorkShop,
                    ProductID = Order.ProductID,
                    Month = Daily.Date.Value.Date.ToString("yyyyMM"),

                    Workstation = Daily.Workstation,
                    ClassType = Daily.ClassType,
                    ProcessID = Process.ProcessID,
                    ProcessName = Process.Name,
                    StandardHours = Process.StandardHours * Process.Relax,
                    Qty = Daily.QtyOK + Daily.QtyNG,
                    JobNum = UserID,
                    Name = UserName,
                    QtyOK = Daily.QtyOK,
                    QtyNG = Daily.QtyNG,
                    OrderID = OrderID,
                    WorkHours = WorksHours,
                    Date = Daily.Date.Value.Date,
                    DateTime = Daily.DateTime,
                    NotWorkHours = Daily.NotWorkHours,
                    Efficiency = Convert.ToDouble(((((Daily.QtyNG + Daily.QtyOK) * Process.StandardHours) / (Daily.WorkHours * 60)) * 100).Value.ToString("F")),
                };
                temDatily.TotalWorkHoursStandard = (temDatily.Qty * temDatily.StandardHours) / 60;
                if (Order != null && Order.Product != null && Order.Product.ProcessList != null)
                {
                    var temPt = Order.Product.ProcessList.FirstOrDefault(p => p.ProcessID == Process.ProcessID);
                    temDatily.ProcessNum = temPt != null ? temPt.Num : 0;
                    temDatily.ProcessSign = temPt != null ? temPt.ProcessSign : "未设置";
                }
                temDatily.TotalWorkHoursNotRelax = (temDatily.Qty * process.StandardHours) / 60;  //未宽放得到工时
                temDatily.TotalWorkHoursStandard = (temDatily.Qty * temDatily.StandardHours) / 60;
                userDailyList.Add(temDatily);
                savaDailyList.Add(temDatily);
                Business.BpmHelper.Daily.Add(temDatily);
            }
        }

        /// <summary>
        /// 从数据库中获取日报列表
        /// </summary>
        public void GetDailyListForDb()
        {
            savaDailyList.Clear();
            var temdailyList = Business.BpmHelper.Daily.GetModelList(" Department = '" +
                Daily.Department + "'  AND Workstation='" +
                Daily.Workstation + "' AND ClassType='" +
                Daily.ClassType + "'  AND  Date = '" +
                Daily.Date.Value.ToString("yyyy-MM-dd") + "'");
            foreach (var daily in temdailyList)
                savaDailyList.Add(daily);

            CalculateTotal();
        }

        /// <summary>
        /// 计算汇总信息
        /// </summary>
        public void CalculateTotal()
        {
            totalDailyUserList.Clear();
            totalDailyProcessList.Clear();
            savaTotalDailyList.Clear();
            VF_EnterCount();
            foreach (var daily in savaDailyList)
            {
                //用户汇总 总览表
                if (totalDailyUserList.FirstOrDefault(x => x.JobNum == daily.JobNum) == null) //如果未找到了该作业元的汇总资料
                {
                    totalDailyUserList.Add(new BPM_Daily()
                    {
                        JobNum = daily.JobNum,
                        Name = daily.Name,
                        WorkHours = savaDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.WorkHours),
                        NotWorkHours = savaDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.NotWorkHours),
                        QtyNG = savaDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.QtyNG),
                        QtyOK = savaDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.QtyOK),
                        Efficiency = Convert.ToDouble((savaDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.TotalWorkHoursNotRelax) / savaDailyList.Where(x => x.JobNum == daily.JobNum).Sum(x => x.WorkHours)).Value.ToString("F2"))
                    });
                }
                //工序汇总 总览表
                if (totalDailyProcessList.FirstOrDefault(p => p.ProcessID == daily.ProcessID) == null)
                {
                    totalDailyProcessList.Add(new BPM_Daily()
                    {
                        ProcessID = daily.ProcessID,
                        ProcessName = daily.ProcessName,
                        Qty = savaDailyList.Where(x => x.ProcessID == daily.ProcessID).Sum(x => x.Qty),
                        WorkHours = savaDailyList.Where(x => x.ProcessID == daily.ProcessID).Sum(x => x.WorkHours)
                    });
                }

                //计算 按 工单 人员 工序 进行分组的信息
                if (savaTotalDailyList.FirstOrDefault(p => p.OrderID == daily.OrderID && p.JobNum == daily.JobNum && p.ProcessID == daily.ProcessID) == null)
                {
                    var temdaily = Copy(daily);
                    temdaily.Qty = savaDailyList.Where(x => (x.OrderID == daily.OrderID) && x.JobNum == daily.JobNum && x.ProcessID == daily.ProcessID).Sum(x => x.Qty);
                    temdaily.QtyOK = savaDailyList.Where(x => (x.OrderID == daily.OrderID) && x.JobNum == daily.JobNum && x.ProcessID == daily.ProcessID).Sum(x => x.QtyOK);
                    temdaily.QtyNG = savaDailyList.Where(x => (x.OrderID == daily.OrderID) && x.JobNum == daily.JobNum && x.ProcessID == daily.ProcessID).Sum(x => x.QtyNG);
                    temdaily.WorkHours = savaDailyList.Where(x => (x.OrderID == daily.OrderID) && x.JobNum == daily.JobNum && x.ProcessID == daily.ProcessID).Sum(x => x.WorkHours);
                    temdaily.NotWorkHours = savaDailyList.Where(x => (x.OrderID == daily.OrderID) && x.JobNum == daily.JobNum && x.ProcessID == daily.ProcessID).Sum(x => x.NotWorkHours);
                    savaTotalDailyList.Add(temdaily);
                }
            }
            //汇总信息
            TotalInfo = "录入工单数：" + savaDailyList.Distinct(new DailyOrderIDComparer()).ToList().Count
                + "     投入人员：" + totalDailyUserList.Count
                + "     投入工序：" + totalDailyProcessList.Count;
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

        /// <summary>
        /// 分配工时运算
        /// </summary>
        /// <param name="SumHours">总投入工时</param>
        /// <param name="userDailyList"></param>
        public void AllotHours(decimal? SumHours, ObservableCollection<BPM_Daily> userDailyList)
        {
            decimal? SumHoursInput = 0;
            foreach (BPM_Daily model in userDailyList)
                SumHoursInput += model.StandardHours * model.Qty;

            foreach (BPM_Daily model in userDailyList)
                model.WorkHours = decimal.Parse((((model.StandardHours * model.Qty) / SumHoursInput) * SumHours).Value.ToString("F2"));
        }

        public void DailyExportToExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                File.Copy(@"\\qqqqqq-ms2\MCP\模板\Daily.xlsx", localFilePath, true);
                IWorkbook wk = WorkbookFactory.Create(localFilePath);

                //导出汇总
                ISheet tb = wk.GetSheet(wk.GetSheetName(0));
                int t = 1;
                foreach (BPM_Daily temmodul in savaTotalDailyList)
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

                //导出明细
                ISheet tb2 = wk.GetSheet(wk.GetSheetName(1));
                int t2 = 1;
                foreach (BPM_Daily temmodul in savaDailyList)
                {
                    //制令单号	工号	姓名	日期	班别	b25	工序	标准工时	生产工时	投入数量	良品数	不良数
                    IRow row = tb2.CreateRow(t2);
                    row.CreateCell(0).SetCellValue(temmodul.OrderID);           //工单单号
                    row.CreateCell(1).SetCellValue(temmodul.JobNum);            //工号
                    row.CreateCell(2).SetCellValue(temmodul.Name);              //姓名
                    row.CreateCell(3).SetCellValue(temmodul.Date.ToString());   //日期
                    row.CreateCell(4).SetCellValue(temmodul.ClassType);         //班别
                    row.CreateCell(5).SetCellValue(temmodul.ProcessID);         //工序ＩＤ
                    row.CreateCell(6).SetCellValue(temmodul.ProcessName);       //工序名称
                    row.CreateCell(7).SetCellValue(Convert.ToDouble(temmodul.StandardHours.ToString()));                   //标准工时
                    row.CreateCell(8).SetCellValue(Convert.ToDouble(temmodul.WorkHours.ToString()));                       //生产工时
                    row.CreateCell(9).SetCellValue(Convert.ToDouble(temmodul.Qty.ToString()));                             //数量
                    row.CreateCell(10).SetCellValue(Convert.ToDouble(temmodul.QtyOK.ToString()));                          //良品数量
                    row.CreateCell(11).SetCellValue(Convert.ToDouble(temmodul.QtyNG.ToString()));                          //不良品数量
                    row.CreateCell(12).SetCellValue(temmodul.Workstation);                                                 //站别
                    t2++;
                }
                FileStream fs2 = File.Create(localFilePath);
                wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
                msg.MessageInfo("提示：创建成功！");
            }
        }

        #endregion 方法
    }

    /****************************************************************************************
    *
    *            ViewModule
    *
    ****************************************************************************************/

    internal class DailyViewModule : DailyViewModelBase
    {
        private Grid grd;

        /// <summary>
        /// 重构函数
        /// </summary>
        /// <param name="grd"></param>
        public DailyViewModule(Grid grd)
        {
            Thread t = new Thread(() =>
            {
                try
                {
                    var temUser = ((Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo);
                    Daily.Department = temUser.Department;
                    Daily.Workstation = temUser.Workstation;
                    Daily.ClassType = temUser.ClassType;
                    if (LsSources.Workstation.FirstOrDefault(p => p.ToString() == Daily.Workstation.ToString()) == null)
                    {
                        MyMessage.MessageErr("未在站别列表中找到您的站别，请手动选择站，或在个人信息设置中重设站别后重试！");
                        Daily.Workstation = string.Empty;
                    }
                    Daily.Date = MES.Common.GetDATime.GetTime();
                    Daily.DateTime = MES.Common.GetDATime.GetTime();
                    Daily.QtyNG = 0;
                    Daily.NotWorkHours = 0;
                    this.grd = grd;
                    GetDailyListForDb(); //加载当前用户的报表
                }
                catch { MyMessage.MessageInfo("未加载您的报表，请手动加载！"); }
            });
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// Tab键按下
        /// </summary>
        public ICommand KeyTab => new DelegateCommand(() => { ZhuifengLib.Keyboard.Press(Key.Tab); });

        /// <summary>
        /// 按下Up键
        /// </summary>
        public ICommand KeyUp => new DelegateCommand<System.Windows.Controls.TextBox>((tb) =>
             {
                 tb.Focus();
                 tb.SelectAll();
             });

        /// <summary>
        /// 添加一个日报
        /// </summary>
        public ICommand Add => new DelegateCommand<System.Windows.Controls.TextBox>((tb) =>
                  {
                      tb.Focus();
                      tb.SelectAll();
                      try
                      {
                          if (ZhuifengLib.Controls.Verify.CheckIsNull_TextBoxInGrid(grd) && !Daily.Workstation.IsNullOrEmpty())
                          {
                              if (Business.BpmHelper.OrderRelevance.GetModelList("MainOrder = '" + OrderID + "'").Count < 1)  //判断是否有附加工单
                                  AddDailyToUserList_Single();
                              else
                                  AddDailyToUserList_Much();
                              //清空输入框
                              ProcessID = string.Empty;
                              Process = null;
                              QtyOK = null;
                              WorksHours = null;
                              CalculateTotal();           //计算汇总信息
                          }
                          else msg.MessageInfo("内容不完整！");
                      }
                      catch (Exception ex) { msg.MessageInfo("不允许添加，请确认输入的信息合法！\r\n" + ex.Message); }
                  });

        /// <summary>
        /// 自动分配工时
        /// </summary>
        public ICommand AutoAllot => new DelegateCommand(() =>
                 {
                     //  AllotHours(WorksHours, UserDailyList);
                     // UserDailyList.Refresh(); //更新视图
                 });

        /// <summary>
        /// 保存或更新指定员工的日报列表
        /// </summary>
        public ICommand Sava => new DelegateCommand(() =>
                {
                    SavaUserDailyList();
                });

        /// <summary>
        /// 删除一个日报
        /// </summary>
        public ICommand DeleteDaily => new DelegateCommand(() =>
                  {
                      if (SelectDaily != null)
                      {
                          if (SelectDaily.ID_Key > 0)
                          {
                              Business.BpmHelper.Daily.Delete(SelectDaily.ID_Key);
                              Business.BpmHelper.Wip.Delete(SelectDaily.OrderID);
                          }
                          UserDailyList.Remove(SelectDaily);
                          GetDailyListForDb();
                      }
                  });

        /// <summary>
        /// 载入日报
        /// </summary>
        public ICommand GetDialyList => new DelegateCommand(() =>
                 {
                     GetDailyListForDb();
                     // GetDailyListForDb();
                 });

        /// <summary>
        /// 导出日报列表到Excel中
        /// </summary>
        public ICommand ExportToExcel => new DelegateCommand(() =>
                {
                    DailyExportToExcel();
                });

        /// <summary>
        ///
        /// </summary>
        public RelayCommand<string> InputFlowCardCommand => new RelayCommand<string>((str) =>
        {
            try
            {
                Lm.App.Eic.Mes.EF.Business.UserFlowCard flowcard = new Lm.App.Eic.Mes.EF.Business.UserFlowCard(str);
                this.UserID = flowcard.Detailed.Job_Num;
            }
            catch { }
        });
    }

    /// <summary>
    /// 去"重复"时候的比较器(只要OrderID相同，即认为是相同记录)
    /// </summary>
    internal class DailyOrderIDComparer : IEqualityComparer<BPM_Daily>

    {
        public bool Equals(BPM_Daily x, BPM_Daily y)
        {
            if (x == null)

                return y == null;

            return x.OrderID == y.OrderID;
        }

        public int GetHashCode(BPM_Daily obj)
        {
            if (obj == null)
                return 0;
            return obj.OrderID.GetHashCode();
        }
    }
}