/* BPM_ProductTemplate.cs
*
* 功 能： N/A
* 类 名： BPM_ProductTemplate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:20:23   张文明    初版
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
using System.Linq;

namespace MES.Server.BLL
{
    /// <summary>
    /// BPM_ProductTemplate
    /// </summary>
    public partial class BPM_ProductTemplate
    {
        private readonly IBPM_ProductTemplate dal = DataAccess.CreateBPM_ProductTemplate();
        public BPM_ProductTemplate()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PtID)
        {
            return dal.Exists(PtID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(Model.BPM_ProductTemplate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.BPM_ProductTemplate model)
        {
            return dal.Update(model);
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
        public bool Delete(string ptId)
        {

            return dal.Delete(ptId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ID_Keylist)
        {
            return dal.DeleteList(ID_Keylist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BPM_ProductTemplate GetModel(decimal ID_Key)
        {

            return dal.GetModel(ID_Key);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.BPM_ProductTemplate GetModelByCache(decimal ID_Key)
        {

            string CacheKey = "BPM_ProductTemplateModel-" + ID_Key;
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
                catch { }
            }
            return (Model.BPM_ProductTemplate)objModel;
        }

        /// <summary>
        /// 获得一个模板
        /// </summary>
        /// <param name="processTemplateName"></param>
        /// <returns></returns>
        public List<Model.BPM_ProductTemplate> GetProcessTemprate(string processTemplateName)
        {
            return GetModelList("PtID = '"+processTemplateName+"'");
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
        public List<Model.BPM_ProductTemplate> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]).OrderBy(t=>t.Num).ToList();
        }

        public List<Model.BPM_ProductTemplate> GetModelList_forExcel(string _patch)
        {
            return DataTableToList(ZhuifengLib.NpoiHelper.GenerateTableData(_patch)).OrderBy(t => t.Num).ToList();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.BPM_ProductTemplate> DataTableToList(DataTable dt)
        {
            List<Model.BPM_ProductTemplate> modelList = new List<Model.BPM_ProductTemplate>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.BPM_ProductTemplate model;
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

       
        public List<string> GetPTName()
        {
            return dal.GetPTName();
        }
        /// <summary>
        /// 获得模板名称列表
        /// </summary>
        /// <param name="Department">部门</param>
        /// <param name="Workshop">车间</param>
        /// <returns></returns>
        public  List<string> GetPTName(string Department, string Workshop)
        {
            return dal.GetPTName(Department, Workshop);
        }
        #endregion  ExtensionMethod
    }
}

