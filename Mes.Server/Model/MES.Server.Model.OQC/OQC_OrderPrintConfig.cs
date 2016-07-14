/**
* OQC_OrderPrintConfig.cs
*
* 功 能： N/A
* 类 名： OQC_OrderPrintConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:40   张文明    初版
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
	/// OQC_OrderPrintConfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OQC_OrderPrintConfig
	{
		public OQC_OrderPrintConfig()
		{}
		#region Model
		private string _orderid;
		private string _packlot;
		private string _printtype;
		private int? _triggercount;
		private string _labname;
		private string _labpath;
		private int? _labid;
		/// <summary>
		/// 
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PackLot
		{
			set{ _packlot=value;}
			get{return _packlot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrintType
		{
			set{ _printtype=value;}
			get{return _printtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TriggerCount
		{
			set{ _triggercount=value;}
			get{return _triggercount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LabName
		{
			set{ _labname=value;}
			get{return _labname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LabPath
		{
			set{ _labpath=value;}
			get{return _labpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LabID
		{
			set{ _labid=value;}
			get{return _labid;}
		}
		#endregion Model

	}
}

