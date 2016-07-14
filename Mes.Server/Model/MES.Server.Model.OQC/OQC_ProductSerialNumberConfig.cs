/**
* OQC_ProductSerialNumberConfig.cs
*
* 功 能： N/A
* 类 名： OQC_ProductSerialNumberConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:04:01   张文明    初版
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
	/// OQC_ProductSerialNumberConfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OQC_ProductSerialNumberConfig
	{
		public OQC_ProductSerialNumberConfig()
		{}
		#region Model
		private decimal _productid;
		private string _connectorlist;
		private string _pigtaillist;
		/// <summary>
		/// 
		/// </summary>
		public decimal ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConnectorList
		{
			set{ _connectorlist=value;}
			get{return _connectorlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PigtailList
		{
			set{ _pigtaillist=value;}
			get{return _pigtaillist;}
		}
		#endregion Model

	}
}

