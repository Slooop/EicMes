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
using System.Data;
using System.Collections.Generic;
using MES.Common;
using MES.Server.Model;
using MES.Server.DALFactory;
using MES.Server.IDAL;
namespace MES.Server.BLL
{
	/// <summary>
	/// OQC_ProductSerialNumberConfig
	/// </summary>
	public partial class OQC_ProductSerialNumberConfig
	{
		private readonly IOQC_ProductSerialNumberConfig dal=DataAccess.CreateOQC_ProductSerialNumberConfig();
		public OQC_ProductSerialNumberConfig()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ProductID)
		{
			return dal.Exists(ProductID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(MES.Server.Model.OQC_ProductSerialNumberConfig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MES.Server.Model.OQC_ProductSerialNumberConfig model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ProductID)
		{
			
			return dal.Delete(ProductID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProductIDlist )
		{
			return dal.DeleteList(ProductIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MES.Server.Model.OQC_ProductSerialNumberConfig GetModel(decimal ProductID)
		{
			
			return dal.GetModel(ProductID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MES.Server.Model.OQC_ProductSerialNumberConfig GetModelByCache(decimal ProductID)
		{
			
			string CacheKey = "OQC_ProductSerialNumberConfigModel-" + ProductID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MES.Server.Model.OQC_ProductSerialNumberConfig)objModel;
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
		public List<MES.Server.Model.OQC_ProductSerialNumberConfig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MES.Server.Model.OQC_ProductSerialNumberConfig> DataTableToList(DataTable dt)
		{
			List<MES.Server.Model.OQC_ProductSerialNumberConfig> modelList = new List<MES.Server.Model.OQC_ProductSerialNumberConfig>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MES.Server.Model.OQC_ProductSerialNumberConfig model;
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

