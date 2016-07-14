/**
* OQC_ProductInspectConfig.cs
*
* 功 能： N/A
* 类 名： OQC_ProductInspectConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:55   张文明    初版
*
* Copyright (c) 2015 LightMaster Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MES.Server.Model
{
	/// <summary>
	/// OQC_ProductInspectConfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OQC_ProductInspectConfig
	{
		public OQC_ProductInspectConfig()
		{}
		#region Model
		private string _productid;
		private string _tabname;
		private string _fieldname;
		private decimal? _max;
		private decimal? _min;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TabName
		{
			set{ _tabname=value;}
			get{return _tabname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FieldName
		{
			set{ _fieldname=value;}
			get{return _fieldname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Max
		{
			set{ _max=value;}
			get{return _max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Min
		{
			set{ _min=value;}
			get{return _min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ID_Key
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		#endregion Model

	}
}

