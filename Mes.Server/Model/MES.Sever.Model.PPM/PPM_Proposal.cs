/* PPM_Proposal.cs
*
* 功 能： N/A
* 类 名： PPM_Proposal
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/10 13:57:03   张文明    初版
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
	/// PPM_Proposal:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PPM_Proposal
	{
		public PPM_Proposal()
		{}
		#region Model
		private string _upm_id;
		private string _title;
		private string _u_content;
		private string _up_user;
		private DateTime? _up_date;
		private string _feasibility;
		private string _executor;
		private string _u_plan;
		private string _implement;
		private string _progress;
		private string _result;
		private DateTime? _close_data;
		private string _audit_content;
		private string _audit_user;
		private string _r1;
		private string _r2;
		private string _r3;
		private decimal _id_key;
		/// <summary>
		/// 提案ID
		/// </summary>
		public string Upm_ID
		{
			set{ _upm_id=value;}
			get{return _upm_id;}
		}
		/// <summary>
		/// 主题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string U_Content
		{
			set{ _u_content=value;}
			get{return _u_content;}
		}
		/// <summary>
		/// 提案人
		/// </summary>
		public string Up_User
		{
			set{ _up_user=value;}
			get{return _up_user;}
		}
		/// <summary>
		/// 提案日期
		/// </summary>
		public DateTime? Up_Date
		{
			set{ _up_date=value;}
			get{return _up_date;}
		}
		/// <summary>
		/// 可行性
		/// </summary>
		public string Feasibility
		{
			set{ _feasibility=value;}
			get{return _feasibility;}
		}
		/// <summary>
		/// 执行负责人
		/// </summary>
		public string Executor
		{
			set{ _executor=value;}
			get{return _executor;}
		}
		/// <summary>
		/// 执行计划
		/// </summary>
		public string U_Plan
		{
			set{ _u_plan=value;}
			get{return _u_plan;}
		}
		/// <summary>
		/// 项目实施履历
		/// </summary>
		public string Implement
		{
			set{ _implement=value;}
			get{return _implement;}
		}
		/// <summary>
		/// 实施进度
		/// </summary>
		public string Progress
		{
			set{ _progress=value;}
			get{return _progress;}
		}
		/// <summary>
		/// 实施结果
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 结案日期
		/// </summary>
		public DateTime? Close_Data
		{
			set{ _close_data=value;}
			get{return _close_data;}
		}
		/// <summary>
		/// 结案评语
		/// </summary>
		public string Audit_Content
		{
			set{ _audit_content=value;}
			get{return _audit_content;}
		}
		/// <summary>
		/// 结案审核人
		/// </summary>
		public string Audit_User
		{
			set{ _audit_user=value;}
			get{return _audit_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R1
		{
			set{ _r1=value;}
			get{return _r1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R2
		{
			set{ _r2=value;}
			get{return _r2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R3
		{
			set{ _r3=value;}
			get{return _r3;}
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

