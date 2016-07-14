/* BPM_Product.cs
*
* 功 能： N/A
* 类 名： BPM_Product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:20:20   张文明    初版
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
    /// BPM_Product
    /// </summary>
    public partial class BPM_Product
	{
		private readonly IBPM_Product dal=DataAccess.CreateBPM_Product();
		public BPM_Product()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProductID)
		{
			return dal.Exists(ProductID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.BPM_Product model)
		{
            var _model = GetModel(model.ProductID);
            if (_model!=null)
            {
                if (ZhuifengLib.MyMessage.IsOkMessage("您所添加的品号已存在与数据库，对应的模板为："+_model.PtID+"\r\n继续将更新现有数据！"))
                    return dal.Update(model);
                else return false;
            }
            else
                return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BPM_Product model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProductID)
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
		public Model.BPM_Product GetModel(string ProductID)
		{
			
			return dal.GetModel(ProductID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.BPM_Product GetModelByCache(string ProductID)
		{
			
			string CacheKey = "BPM_ProductModel-" + ProductID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.BPM_Product)objModel;
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
		public List<Model.BPM_Product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.BPM_Product> DataTableToList(DataTable dt)
		{
			List<Model.BPM_Product> modelList = new List<Model.BPM_Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.BPM_Product model;
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

