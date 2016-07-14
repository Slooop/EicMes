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
using System.Collections.Generic;
using System.Data;
namespace MES.Server.IDAL
{
	/// <summary>
	/// 接口层HR_User
	/// </summary>
	public interface IHR_User
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(decimal USI_ID);

        bool Exists(string JobNum);
        /// <summary>
		/// 是否存在该记录
		/// </summary>
       bool Exists(String jobNum, string passWord);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		decimal Add(Model.HR_User model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.HR_User model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(decimal USI_ID);
		bool DeleteList(string USI_IDlist );
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.HR_User GetModel(decimal USI_ID);
        Model.HR_User DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx
        List<Model.HR_User> UserChangeClass(List<Model.HR_User> lsUser);
        #endregion  MethodEx
    } 
}
