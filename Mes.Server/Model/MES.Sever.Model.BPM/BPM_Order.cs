/**  版本信息模板在安装目录下，可自行修改。
* BPM_Order.cs
*
* 功 能： N/A
* 类 名： BPM_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/8/10 星期一 10:07:59   张文明    初版
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
    /// BPM_Order:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BPM_Order
    {
        public BPM_Order()
        { }
        #region Model
        private string _orderid;
        private string _clientname;
        private string _productid;
        private string _productname;
        private string _spec;
        private double? _count;
        private double? _totalworkhoursstandard;
        private string _startdate;
        private string _enddate;
        private string _actualstartdate;
        private string _actualenddate;
        private DateTime? _deliverydate;
        private string _qty;
        private string _pn;
        private string _po;
        private string _workdepartment;
        private string _workshop;
        private string _state;
        private double? _relax;
        private bool _isremind;
        private double?  _inStorageCount;
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
        public double? Count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 总标准工时
        /// </summary>
        public double? TotalWorkHoursStandard
        {
            set { _totalworkhoursstandard = value; }
            get { return _totalworkhoursstandard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
		/// 实际开工日期
		/// </summary>
		public string ActualStartDate
        {
            set { _actualstartdate = value; }
            get { return _actualstartdate; }
        }
        /// <summary>
        /// 实际完工日期
        /// </summary>
        public string ActualEndDate
        {
            set { _actualenddate = value; }
            get { return _actualenddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeliveryDate
        {
            set { _deliverydate = value; }
            get { return _deliverydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PN
        {
            set { _pn = value; }
            get { return _pn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PO
        {
            set { _po = value; }
            get { return _po; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkDepartment
        {
            set { _workdepartment = value; }
            get { return _workdepartment; }
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
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? Relax
        {
            set { _relax = value; }
            get { return _relax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRemind
        {
            set { _isremind = value; }
            get { return _isremind; }
        }

        public double? InStorageCount
        {
            get { return _inStorageCount; }
            set { _inStorageCount = value; }
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


        private BPM_Product product = null;

        /// <summary>
        /// 产品信息
        /// </summary>
        public BPM_Product Product
        {
            get { return product; }
            set { product = value; }
        }


    }
}

