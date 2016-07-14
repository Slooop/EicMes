/**  版本信息模板在安装目录下，可自行修改。
* BPM_ReWork.cs
*
* 功 能： N/A
* 类 名： BPM_ReWork
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/5 星期六 16:03:24   张文明    初版
*
* Copyright (c) 2015 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System.Data;
namespace MES.Server.IDAL
{
    /// <summary>
    /// 接口层BPM_ReWork
    /// </summary>
    public interface IBPM_ReWork
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Model.BPM_ReWork model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.BPM_ReWork model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete();
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.BPM_ReWork GetModel();
        Model.BPM_ReWork DataRowToModel(DataRow row);
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
