/**  版本信息模板在安装目录下，可自行修改。
* BPM_WIP.cs
*
* 功 能： N/A
* 类 名： BPM_WIP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/7 星期一 16:36:50   张文明    初版
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
	/// BPM_WIP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BPM_WIP
	{
		public BPM_WIP()
		{}
        #region Model
        private string _orderid;
        private string _clientname;
        private string _productname;
        private string _spec;
        private int? _count;
        private int? _processcount;
        private string _processid;
        private string _processname;
        private double? _standardhours;
        private int? _connectorqty;
        private string _processsign;
        private double? _totalstandatdhours;
        private int? _qty;
        private int? _qty_ok;
        private int? _qty_ng;
        private int? _qty_notinput;
        private double? _gettime;
        private double? _workhours;
        private double _efficiency;
        private int? _wip;
        private double _id_key;
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
        public int? Count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
		/// 
		/// </summary>
		public int? ProcessCount
        {
            set { _processcount = value; }
            get { return _processcount; }
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
        public double? StandardHours
        {
            set { _standardhours = value; }
            get { return _standardhours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ConnectorQty
        {
            set { _connectorqty = value; }
            get { return _connectorqty; }
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
        public double? TotalStandatdHours
        {
            set { _totalstandatdhours = value; }
            get { return _totalstandatdhours; }
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
        public int? Qty_OK
        {
            set { _qty_ok = value; }
            get { return _qty_ok; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Qty_NG
        {
            set { _qty_ng = value; }
            get { return _qty_ng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Qty_NotInput
        {
            set { _qty_notinput = value; }
            get { return _qty_notinput; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? GetTime
        {
            set { _gettime = value; }
            get { return _gettime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? WorkHours
        {
            set { _workhours = value; }
            get { return _workhours; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double Efficiency
        {
            set { _efficiency = value; }
            get { return _efficiency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Wip
        {
            set { _wip = value; }
            get { return _wip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double ID_Key
        {
            set { _id_key = value; }
            get { return _id_key; }
        }
        #endregion Model
    }
}

