/**  版本信息模板在安装目录下，可自行修改。
* BPM_OrderRelevance.cs
*
* 功 能： N/A
* 类 名： BPM_OrderRelevance
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/29 星期四 9:46:35   张文明    初版
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
namespace MES.Server.BLL
{
    /// <summary>
    /// BPM_OrderRelevance
    /// </summary>
    public partial class BPM_OrderRelevance
    {
        private readonly IBPM_OrderRelevance dal = DataAccess.CreateBPM_OrderRelevance();
        public BPM_OrderRelevance()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AdditionalOrder)
        {
            return dal.Exists(AdditionalOrder);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.BPM_OrderRelevance model)
        {
            if (Exists(model.AdditionalOrder))
                return Update(model);
            else
                return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.BPM_OrderRelevance model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string AdditionalOrder)
        {

            return dal.Delete(AdditionalOrder);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string AdditionalOrderlist)
        {
            return dal.DeleteList(AdditionalOrderlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BPM_OrderRelevance GetModel(string AdditionalOrder)
        {

            return dal.GetModel(AdditionalOrder);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.BPM_OrderRelevance GetModelByCache(string AdditionalOrder)
        {

            string CacheKey = "BPM_OrderRelevanceModel-" + AdditionalOrder;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(AdditionalOrder);
                    if (objModel != null)
                    {
                        int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.BPM_OrderRelevance)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.BPM_OrderRelevance> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.BPM_OrderRelevance> DataTableToList(DataTable dt)
        {
            List<Model.BPM_OrderRelevance> modelList = new List<Model.BPM_OrderRelevance>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.BPM_OrderRelevance model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

