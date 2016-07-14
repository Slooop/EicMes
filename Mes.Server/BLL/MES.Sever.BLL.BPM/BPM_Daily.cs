/**  版本信息模板在安装目录下，可自行修改。
* BPM_Daily.cs
*
* 功 能： N/A
* 类 名： BPM_Daily
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/23 星期三 13:05:58   张文明    初版
*
* Copyright (c) 2015 Maticsoft Corporation. All rights reserved.
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
using System.Text;

namespace MES.Server.BLL
{
    /// <summary>
    /// BPM_Daily
    /// </summary>
    public partial class BPM_Daily
	{
		private readonly IBPM_Daily dal=DataAccess.CreateBPM_Daily();
		public BPM_Daily()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.BPM_Daily model)
		{
            BPM_WIP bll_wip = new BPM_WIP();
			if (GetModel(model.ID_Key) != null)
            {
                bool tem = Update(model);
                bll_wip.EnterDaily(model);
                return tem;
            }
			else
            {
                var tem = dal.Add(model) > 0;
                bll_wip.EnterDaily(model);
                return tem;
            }
				
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BPM_Daily model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 更新工单状态
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool UpdateOrderState(Model.BPM_Order order)
        {
            return dal.UpdateOrderState(order);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID_Key)
		{
			
			return dal.Delete(ID_Key);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ID_Keylist )
		{
			return dal.DeleteList(ID_Keylist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.BPM_Daily GetModel(decimal ID_Key)
		{
			return dal.GetModel(ID_Key);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.BPM_Daily GetModelByCache(decimal ID_Key)
		{
			
			string CacheKey = "BPM_DailyModel-" + ID_Key;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID_Key);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.BPM_Daily)objModel;
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
		public List<Model.BPM_Daily> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.BPM_Daily> DataTableToList(DataTable dt)
		{
			List<Model.BPM_Daily> modelList = new List<Model.BPM_Daily>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.BPM_Daily model;
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

        public List<Model.BPM_Daily> GetTotalWorkHours(Model.BPM_Daily model,List<Model.BPM_Daily> lsDaily)
        {

            var totalWorkHours = new List<Model.BPM_Daily>();
            
 


            return totalWorkHours;
        }


        /// <summary>
        /// 根据工单列表获取列表中指定工单的日报表
        /// </summary>
        /// <param name="lsOrder"></param>
        /// <returns></returns>
        public List<Model.BPM_Daily> GetModelList(List<Model.BPM_Order> lsOrder)
        {
            if (lsOrder.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("OrderID IN (");
                foreach (var tem in lsOrder)
                {
                    sb.Append("'");
                    sb.Append(tem.OrderID);
                    sb.Append("',");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append(")");
                return GetModelList(sb.ToString());
            }
            else {return new List<Model.BPM_Daily>(); }
        }

		#endregion  ExtensionMethod
	}
}

