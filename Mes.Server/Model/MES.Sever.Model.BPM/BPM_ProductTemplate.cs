/* BPM_ProductTemplate.cs
*
* 功 能： N/A
* 类 名： BPM_ProductTemplate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:56:04   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MES.Server.Model
{
	/// <summary>
	/// BPM_ProductTemplate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BPM_ProductTemplate
	{
        public BPM_ProductTemplate()
        { }

        #region Model
        private string _department;
        private string _workshop;
        private string _ptid;
        private string _alias;
        private string _name;
        private int? _num;
        private string _processid;
        private string _processname;
        private string _processsign;
        private bool _ischecktotalcount;
        private int? _onceqty;
        private decimal? _standardhours;
        private int? _connectorqty;
        private decimal? _tl;
        private string _isvital;
        private string _iscontrol;
        private string _reworkprocess;
        private decimal _id_key;
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
        public string PtID
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Alias
        {
            set { _alias = value; }
            get { return _alias; }
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
        public int? Num
        {
            set { _num = value; }
            get { return _num; }
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
        public bool IsCheckTotalCount
        {
            set { _ischecktotalcount = value; }
            get { return _ischecktotalcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OnceQty
        {
            set { _onceqty = value; }
            get { return _onceqty; }
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
        public int? ConnectorQty
        {
            set { _connectorqty = value; }
            get { return _connectorqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TL
        {
            set { _tl = value; }
            get { return _tl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsVital
        {
            set { _isvital = value; }
            get { return _isvital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsControl
        {
            set { _iscontrol = value; }
            get { return _iscontrol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReWorkProcess
        {
            set { _reworkprocess = value; }
            get { return _reworkprocess; }
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


    }
}

