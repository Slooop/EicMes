/* BPM_Product.cs
*
* 功 能： N/A
* 类 名： BPM_Product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:20:19   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace MES.Server.Model
{
	/// <summary>
	/// BPM_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BPM_Product
	{
		public BPM_Product()
		{}
		#region Model
		private string _productid;
		private string _alias;
		private string _name;
        private string _spec;
        private int? _connectorqty;
		private string _pic;
        private string _ptid;
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
		public string Alias
		{
			set{ _alias=value;}
			get{return _alias;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
        public int? ConnectorQty
        {
            set { _connectorqty = value; }
            get { return _connectorqty; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string PtID  
        {
            set{ _ptid=value;}
			get{return _ptid;}
        }

        private ObservableCollection<BPM_ProductTemplate> processlist = new ObservableCollection<BPM_ProductTemplate>();

        /// <summary>
        /// 工序列表
        /// </summary>
        public ObservableCollection<BPM_ProductTemplate> ProcessList
        {
            get { return processlist; }
            set { processlist = value;}
        }

        /// <summary>
        /// 管制工序列表
        /// </summary>
        public ObservableCollection<BPM_ProductTemplate> ControlProcessList
        {
            get
            {
                return new ObservableCollection<BPM_ProductTemplate>((from s in ProcessList where s.IsControl == "是" select s).ToList());
            }
        }
        
		#endregion Model

	}
}

