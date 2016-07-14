/**  版本信息模板在安装目录下，可自行修改。
* BPM_OrderRelevance.cs
*
* 功 能： N/A
* 类 名： BPM_OrderRelevance
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/28 星期三 15:15:19   张文明    初版
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
	/// BPM_OrderRelevance:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BPM_OrderRelevance
	{
        public BPM_OrderRelevance()
        { }
        #region Model
        private string _mainorder;
        private string _additionalorder;
        private string _productname;
        private string _spec;
        private decimal? _qty;
        /// <summary>
        /// 
        /// </summary>
        public string MainOrder
        {
            set { _mainorder = value; }
            get { return _mainorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdditionalOrder
        {
            set { _additionalorder = value; }
            get { return _additionalorder; }
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
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        #endregion Model


    }
}

