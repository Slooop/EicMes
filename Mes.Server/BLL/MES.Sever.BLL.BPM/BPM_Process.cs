/* BPM_Process.cs
*
* 功 能： N/A
* 类 名： BPM_Process
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:20:04   张文明    初版
*
* Copyright (c) 2012 MES Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using MES.Server.DALFactory;
using MES.Server.IDAL;
namespace MES.Server.BLL
{
    /// <summary>
    /// BPM_Process
    /// </summary>
    public partial class BPM_Process
	{
		private readonly IBPM_Process dal=DataAccess.CreateBPM_Process();
		public BPM_Process()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProcessID)
		{
			return dal.Exists(ProcessID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Model.BPM_Process model)
        {
            bool relast = GetModel(model.ProcessID) != null ? dal.Update(model) : dal.Add(model);
            //更新模板中的工序
            if (relast)
            {
                MES.Server.BLL.BPM_ProductTemplate bt = new BPM_ProductTemplate();
                var btList = bt.GetModelList("ProcessID = '"+model.ProcessID+"'");
                foreach(var process in btList)
                {
                    process.StandardHours = model.StandardHours * model.Relax ;
                    bt.Update(process);
                }
            }
            return relast;
        }

		///// <summary>
		///// 更新一条数据
		///// </summary>
		//public bool Update(Model.BPM_Process model)
		//{
		//	return dal.Update(model);
		//}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProcessID)
		{
			
			return dal.Delete(ProcessID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProcessIDlist )
		{
			return dal.DeleteList(ProcessIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.BPM_Process GetModel(string ProcessID)
		{
			
			return dal.GetModel(ProcessID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.BPM_Process GetModelByCache(string ProcessID)
		{
			
			string CacheKey = "BPM_ProcessModel-" + ProcessID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProcessID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.BPM_Process)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.BPM_Process> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.BPM_Process> DataTableToList(DataTable dt)
		{
			List<Model.BPM_Process> modelList = new List<Model.BPM_Process>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.BPM_Process model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

