/**
* OQC_OrderInspectConfig.cs
*
* 功 能： N/A
* 类 名： OQC_OrderInspectConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:35   张文明    初版
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
	/// 接口层OQC_OrderInspectConfig
	/// </summary>
	public interface IOQC_OrderInspectConfig
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string OrderID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(MES.Server.Model.OQC_OrderInspectConfig model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(MES.Server.Model.OQC_OrderInspectConfig model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string OrderID);
		bool DeleteList(string OrderIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		MES.Server.Model.OQC_OrderInspectConfig GetModel(string OrderID);
		MES.Server.Model.OQC_OrderInspectConfig DataRowToModel(DataRow row);
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
