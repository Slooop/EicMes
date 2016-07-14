/**  版本信息模板在安装目录下，可自行修改。
* BPM_Process.cs
*
* 功 能： N/A
* 类 名： BPM_Process
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/13 星期二 13:29:46   张文明    初版
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
	/// BPM_Process:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BPM_Process
	{
        public BPM_Process()
        { }
        #region Model
        private string _processid;
        private string _name;
        private decimal? _standardhours;
        private decimal? _relax;
        private int? _pcsh;
        private string _workstation;
        private string _workshop;
        private string _remark;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        public decimal? Relax
        {
            set { _relax = value; }
            get { return _relax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PCSH
        {
            set { _pcsh = value; }
            get { return _pcsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Workstation
        {
            set { _workstation = value; }
            get { return _workstation; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model


    }
}

