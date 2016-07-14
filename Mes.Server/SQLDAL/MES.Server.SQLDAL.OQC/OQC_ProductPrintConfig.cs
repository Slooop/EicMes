/**
* OQC_ProductPrintConfig.cs
*
* 功 能： N/A
* 类 名： OQC_ProductPrintConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:59   张文明    初版
*
* Copyright (c) 2015 LightMaster Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MES.Server.IDAL;
using MES.Server.DBUtility;//Please add references
namespace MES.Server.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:OQC_ProductPrintConfig
	/// </summary>
	public partial class OQC_ProductPrintConfig:IOQC_ProductPrintConfig
	{
		public OQC_ProductPrintConfig()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProductID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OQC_ProductPrintConfig");
			strSql.Append(" where ProductID=@ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)			};
			parameters[0].Value = ProductID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MES.Server.Model.OQC_ProductPrintConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OQC_ProductPrintConfig(");
			strSql.Append("ProductID,PrintType,TriggerCount,LabName,LabPath)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@PrintType,@TriggerCount,@LabName,@LabPath)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50),
					new SqlParameter("@PrintType", SqlDbType.VarChar,50),
					new SqlParameter("@TriggerCount", SqlDbType.Int,4),
					new SqlParameter("@LabName", SqlDbType.VarChar,200),
					new SqlParameter("@LabPath", SqlDbType.VarChar,200)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.PrintType;
			parameters[2].Value = model.TriggerCount;
			parameters[3].Value = model.LabName;
			parameters[4].Value = model.LabPath;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MES.Server.Model.OQC_ProductPrintConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OQC_ProductPrintConfig set ");
			strSql.Append("PrintType=@PrintType,");
			strSql.Append("TriggerCount=@TriggerCount,");
			strSql.Append("LabName=@LabName,");
			strSql.Append("LabPath=@LabPath");
			strSql.Append(" where ProductID=@ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PrintType", SqlDbType.VarChar,50),
					new SqlParameter("@TriggerCount", SqlDbType.Int,4),
					new SqlParameter("@LabName", SqlDbType.VarChar,200),
					new SqlParameter("@LabPath", SqlDbType.VarChar,200),
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PrintType;
			parameters[1].Value = model.TriggerCount;
			parameters[2].Value = model.LabName;
			parameters[3].Value = model.LabPath;
			parameters[4].Value = model.ProductID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OQC_ProductPrintConfig ");
			strSql.Append(" where ProductID=@ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)			};
			parameters[0].Value = ProductID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ProductIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OQC_ProductPrintConfig ");
			strSql.Append(" where ProductID in ("+ProductIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MES.Server.Model.OQC_ProductPrintConfig GetModel(string ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductID,PrintType,TriggerCount,LabName,LabPath from OQC_ProductPrintConfig ");
			strSql.Append(" where ProductID=@ProductID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)			};
			parameters[0].Value = ProductID;

			MES.Server.Model.OQC_ProductPrintConfig model=new MES.Server.Model.OQC_ProductPrintConfig();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MES.Server.Model.OQC_ProductPrintConfig DataRowToModel(DataRow row)
		{
			MES.Server.Model.OQC_ProductPrintConfig model=new MES.Server.Model.OQC_ProductPrintConfig();
			if (row != null)
			{
				if(row["ProductID"]!=null)
				{
					model.ProductID=row["ProductID"].ToString();
				}
				if(row["PrintType"]!=null)
				{
					model.PrintType=row["PrintType"].ToString();
				}
				if(row["TriggerCount"]!=null && row["TriggerCount"].ToString()!="")
				{
					model.TriggerCount=int.Parse(row["TriggerCount"].ToString());
				}
				if(row["LabName"]!=null)
				{
					model.LabName=row["LabName"].ToString();
				}
				if(row["LabPath"]!=null)
				{
					model.LabPath=row["LabPath"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductID,PrintType,TriggerCount,LabName,LabPath ");
			strSql.Append(" FROM OQC_ProductPrintConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ProductID,PrintType,TriggerCount,LabName,LabPath ");
			strSql.Append(" FROM OQC_ProductPrintConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM OQC_ProductPrintConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ProductID desc");
			}
			strSql.Append(")AS Row, T.*  from OQC_ProductPrintConfig T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "OQC_ProductPrintConfig";
			parameters[1].Value = "ProductID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

