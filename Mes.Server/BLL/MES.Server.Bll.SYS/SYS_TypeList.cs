/* SYS_TypeList.cs
*
* 功 能： N/A
* 类 名： SYS_TypeList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/13 13:19:19   张文明    初版
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
    /// SYS_TypeList
    /// </summary>
    public partial class SYS_TypeList
	{
		private readonly ISYS_TypeList dal=DataAccess.CreateSYS_TypeList();
		
        public List<string> lsType(TypeList tp)
        {
            List<string> lsValue = new List<string>();
            List<Model.SYS_TypeList> tem = GetModelList("Type = '" + tp.ToString() + "'");
            foreach (Model.SYS_TypeList t in tem)
                lsValue.Add(t.Value);
            return lsValue;
        }

		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Model.SYS_TypeList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.SYS_TypeList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.SYS_TypeList GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.SYS_TypeList GetModelByCache(decimal ID)
		{
			
			string CacheKey = "SYS_TypeListModel-" + ID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.SYS_TypeList)objModel;
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
		public List<Model.SYS_TypeList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.SYS_TypeList> DataTableToList(DataTable dt)
		{
			List<Model.SYS_TypeList> modelList = new List<Model.SYS_TypeList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.SYS_TypeList model;
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

	}

    public enum TypeList
    {
        OrderState,
        Department,
        Workshop,
        Workstation,
        ClassType,
        JobTitle,
        IsWedding,
        Politics,
        Degree,
        Sex,
        TrueOrFalse,
        Client,
        Is_Job,
     
    }

}

