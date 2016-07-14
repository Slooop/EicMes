/**
* User_JDS_Test_Good.cs
*
* 功 能： N/A
* 类 名： User_JDS_Test_Good
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/11 10:23:55   张文明    初版
*
* Copyright (c) 2015 LightMaster Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace MES.Server.IDAL
{
	/// <summary>
	/// 接口层User_JDS_Test_Good
	/// </summary>
	public interface IUser_JDS_Test_Good
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		decimal Add(MES.Server.Model.User_JDS_Test_Good model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(MES.Server.Model.User_JDS_Test_Good model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(decimal ID_Key);
		bool DeleteList(string ID_Keylist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MES.Server.Model.User_JDS_Test_Good GetModel(decimal ID_Key);
		MES.Server.Model.User_JDS_Test_Good DataRowToModel(DataRow row);
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

		#endregion  MethodEx
	} 
}
