/**  版本信息模板在安装目录下，可自行修改。
* V_ProductionRecords.cs
*
* 功 能： N/A
* 类 名： V_ProductionRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/8/17 星期一 9:40:24   张文明    初版
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
	/// V_ProductionRecords:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class V_ProductionRecords
	{
        #region Model
        private string _orderid;
        private int? _num;
        private string _processid;
        private string _processname;
        private decimal? _qty;
        private decimal? _qty_ng;
        private decimal? _qty_ok;
        private string _passratio;
        private string _rejectratio;
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
        public decimal? Qty_NG
        {
            set { _qty_ng = value; }
            get { return _qty_ng; }
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
        public string PassRatio
        {
            set { _passratio = value; }
            get { return _passratio; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RejectRatio
        {
            set { _rejectratio = value; }
            get { return _rejectratio; }
        }
        #endregion Model

	}
}

