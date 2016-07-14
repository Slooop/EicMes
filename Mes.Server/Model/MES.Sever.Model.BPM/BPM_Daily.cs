/**  版本信息模板在安装目录下，可自行修改。
* BPM_Daily.cs
*
* 功 能： N/A
* 类 名： BPM_Daily
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/29 星期二 16:05:19   张文明    初版
*
* Copyright (c) 2015 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MES.Server.Model
{
	/// <summary>
	/// BPM_Daily:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class BPM_Daily
    {
        public BPM_Daily()
        { }
        #region Model
        private string _orderid;
        private string _clientname;
        private string _productid;
        private string _productname;
        private string _spec;
        private int? _ordercount;
        private string _state;
        private string _actualenddate;
        private string _dailynum;
        private string _department;
        private string _workshop;
        private string _workstation;
        private string _classtype;
        private string _jobnum;
        private string _name;
        private string _month;
        private DateTime? _date;
        private DateTime? _datetime;
        private int? _processnum;
        private string _processid;
        private string _processname;
        private string _processsign;
        private decimal? _standardhours;
        private decimal? _workhours;
        private decimal? _totalworkhoursnotrelax;
        private decimal? _totalworkhoursstandard;
        private decimal? _totalworkhourspmc;
        private decimal? _notworkhours;
        private string _notworkcause;
        private int? _qty;
        private int? _qtyok;
        private int? _qtyng;
        private double? _efficiency;
        private string _remarks;
        private decimal _id_key;
        /// <summary>
        /// 
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClientName
        {
            set { _clientname = value; }
            get { return _clientname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderCount
        {
            set { _ordercount = value; }
            get { return _ordercount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActualEndDate
        {
            set { _actualenddate = value; }
            get { return _actualenddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DailyNum
        {
            set { _dailynum = value; }
            get { return _dailynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkShop
        {
            set { _workshop = value; }
            get { return _workshop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Workstation
        {
            set { _workstation = value; }
            get { return _workstation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassType
        {
            set { _classtype = value; }
            get { return _classtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JobNum
        {
            set { _jobnum = value; }
            get { return _jobnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Month
        {
            set { _month = value; }
            get { return _month; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateTime
        {
            set { _datetime = value; }
            get { return _datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProcessNum
        {
            set { _processnum = value; }
            get { return _processnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessID
        {
            set { _processid = value; }
            get { return _processid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessName
        {
            set { _processname = value; }
            get { return _processname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessSign
        {
            set { _processsign = value; }
            get { return _processsign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? StandardHours
        {
            set { _standardhours = value; }
            get { return _standardhours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkHours
        {
            set { _workhours = value; }
            get { return _workhours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalWorkHoursNotRelax
        {
            set { _totalworkhoursnotrelax = value; }
            get { return _totalworkhoursnotrelax; }
        }
        /// <summary>
        /// 总标准工时
        /// </summary>
        public decimal? TotalWorkHoursStandard
        {
            set { _totalworkhoursstandard = value; }
            get { return _totalworkhoursstandard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalWorkHoursPmc
        {
            set { _totalworkhourspmc = value; }
            get { return _totalworkhourspmc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NotWorkHours
        {
            set { _notworkhours = value; }
            get { return _notworkhours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NotWorkCause
        {
            set { _notworkcause = value; }
            get { return _notworkcause; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? QtyOK
        {
            set { _qtyok = value; }
            get { return _qtyok; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? QtyNG
        {
            set { _qtyng = value; }
            get { return _qtyng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? Efficiency
        {
            set { _efficiency = value; }
            get { return _efficiency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ID_Key
        {
            set { _id_key = value; }
            get { return _id_key; }
        }
        #endregion Model

        #region ExProp
        /// <summary>
        /// 差值计算 标准工时 - 实际使用工时
        /// </summary>
        public double Difference_StandardAndWork { get; set; }
        #endregion
    }
}