/* HR_User.cs
*
* 功 能： N/A
* 类 名： HR_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/15 9:26:44   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
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
    /// HR_User
    /// </summary>
    public partial class HR_User
	{
		private readonly IHR_User dal=DataAccess.CreateHR_User();
		public HR_User()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal USI_ID)
		{
			return dal.Exists(USI_ID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string JobNum)
        {
            return dal.Exists(JobNum);
        }

      

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(String jobNum, string passWord)
        {
            return dal.Exists(jobNum, passWord);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.HR_User model)
		{
            if (Exists(model.Job_Num))
                return dal.Update(model);
            else return dal.Add(model) > 0;
        }

  //      /// <summary>
  //      /// 更新一条数据
  //      /// </summary>
  //      public bool Update(Model.HR_User model)
		//{
  //          if (Exists(model.Job_Num))
  //              return dal.Update(model);
  //          else return dal.Add(new Model.HR_User() {Job_Num= model.Job_Num, Name= model.Name, Password= model.Job_Num,Department= model.Department }) > 0;
            
               
		//}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal USI_ID)
		{
			
			return dal.Delete(USI_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string USI_IDlist )
		{
			return dal.DeleteList(USI_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.HR_User GetModel(decimal USI_ID)
		{
			
			return dal.GetModel(USI_ID);
		}

        /// <summary>
        /// 获取一个用户
        /// </summary>
        /// <param name="jobNum">工号</param>
        /// <returns></returns>
        public Model.HR_User GetModel(string jobNum)
        {
            List<Model.HR_User> userList = GetModelList("Job_Num = '"+jobNum+"'");
            return( userList.Count > 0 ? userList[0]:null);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.HR_User GetModelByCache(decimal USI_ID)
		{
			
			string CacheKey = "HR_UserModel-" + USI_ID;
			object objModel = MES.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(USI_ID);
					if (objModel != null)
					{
						int ModelCache = MES.Common.ConfigHelper.GetConfigInt("ModelCache");
						MES.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero); 
					}
				}
				catch{}
			}
			return (Model.HR_User)objModel;
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
		public List<Model.HR_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.HR_User> DataTableToList(DataTable dt)
		{
			List<Model.HR_User> modelList = new List<Model.HR_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.HR_User model;
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
        public List<Model.HR_User> GetModelList_forExcel(string _patch)
        {
            return DataTableToList(ZhuifengLib.NpoiHelper.GenerateTableData(_patch));
        }

        public List<Model.HR_User> UserChangeClass(List<MES.Server.Model.HR_User> lsUser)
        {
            return dal.UserChangeClass(lsUser);
        }
        #endregion  ExtensionMethod
    }
}

