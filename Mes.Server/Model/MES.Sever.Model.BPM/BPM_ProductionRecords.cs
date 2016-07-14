/**  版本信息模板在安装目录下，可自行修改。
* BPM_ProductionRecords.cs
*
* 功 能： N/A
* 类 名： BPM_ProductionRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/8/6 17:00:17   张文明    初版
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
    /// BPM_ProductionRecords:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BPM_ProductionRecords
    {
        public BPM_ProductionRecords()
        { }
        #region Model
        private string _orderid;
        private string _flowcardnum;
        private int? _num;
        private string _processid;
        private string _processname;
        private decimal? _qty;
        private decimal? _qty_ok;
        private decimal? _qty_ng;
        private string _userid;
        private string _username;
        private DateTime? _datetime;
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
        public string FlowCardNum
        {
            set { _flowcardnum = value; }
            get { return _flowcardnum; }
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
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty_OK
        {
            set { _qty_ok = value; }
            get { return _qty_ok; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty_NG
        {
            set { _qty_ng = value; }
            get { return _qty_ng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        public decimal ID_Key
        {
            set { _id_key = value; }
            get { return _id_key; }
        }
        #endregion Model
    }
}

