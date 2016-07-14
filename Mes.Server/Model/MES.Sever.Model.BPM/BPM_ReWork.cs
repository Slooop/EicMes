/**  版本信息模板在安装目录下，可自行修改。
* BPM_ReWork.cs
*
* 功 能： N/A
* 类 名： BPM_ReWork
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/5 星期六 16:03:24   张文明    初版
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
	/// BPM_ReWork:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BPM_ReWork
	{
		public BPM_ReWork()
		{}
		#region Model
        private bool _isCheck = false;
		private string _orderid;
		private string _sn;
		private string _wk_send;
		private string _causeng;
		private string _judgejobnum;
		private string _judgeuser;
		private string _wk_receive;
		private string _disposition;
		private string _result;
		private string _dispositonjobnum;
		private string _dispositonuser;
		private int? _qty;
		private DateTime? _datetime;

        public bool IsCheck
        {
            get { return _isCheck; }
            set { _isCheck = value; }
        }
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
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WK_Send
		{
			set{ _wk_send=value;}
			get{return _wk_send;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CauseNG
		{
			set{ _causeng=value;}
			get{return _causeng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JudgeJobNum
		{
			set{ _judgejobnum=value;}
			get{return _judgejobnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JudgeUser
		{
			set{ _judgeuser=value;}
			get{return _judgeuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WK_Receive
		{
			set{ _wk_receive=value;}
			get{return _wk_receive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Disposition
		{
			set{ _disposition=value;}
			get{return _disposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DispositonJobNum
		{
			set{ _dispositonjobnum=value;}
			get{return _dispositonjobnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DispositonUser
		{
			set{ _dispositonuser=value;}
			get{return _dispositonuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

