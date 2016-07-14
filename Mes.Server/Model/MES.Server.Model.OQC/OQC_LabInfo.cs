/**
* OQC_LabInfo.cs
*
* 功 能： N/A
* 类 名： OQC_LabInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:28   张文明    初版
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
	/// OQC_LabInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OQC_LabInfo
	{
		public OQC_LabInfo()
		{}
		#region Model
		private int _labid;
		private string _term;
		private string _value;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public int LabID
		{
			set{ _labid=value;}
			get{return _labid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Term
		{
			set{ _term=value;}
			get{return _term;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value
		{
			set{ _value=value;}
			get{return _value;}
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

