/**
* OQC_OrderPrintConfig.cs
*
* 功 能： N/A
* 类 名： OQC_OrderPrintConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:40   张文明    初版
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
	/// 数据访问类:OQC_OrderPrintConfig
	/// </summary>
	public partial class OQC_OrderPrintConfig:IOQC_OrderPrintConfig
	{
		public OQC_OrderPrintConfig()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OrderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OQC_OrderPrintConfig");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
			parameters[0].Value = OrderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MES.Server.Model.OQC_OrderPrintConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OQC_OrderPrintConfig(");
			strSql.Append("OrderID,PackLot,PrintType,TriggerCount,LabName,LabPath,LabID)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@PackLot,@PrintType,@TriggerCount,@LabName,@LabPath,@LabID)");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@PackLot", SqlDbType.VarChar,50),
					new SqlParameter("@PrintType", SqlDbType.VarChar,50),
					new SqlParameter("@TriggerCount", SqlDbType.Int,4),
					new SqlParameter("@LabName", SqlDbType.VarChar,200),
					new SqlParameter("@LabPath", SqlDbType.VarChar,200),
					new SqlParameter("@LabID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.PackLot;
			parameters[2].Value = model.PrintType;
			parameters[3].Value = model.TriggerCount;
			parameters[4].Value = model.LabName;
			parameters[5].Value = model.LabPath;
			parameters[6].Value = model.LabID;

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
		public bool Update(MES.Server.Model.OQC_OrderPrintConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OQC_OrderPrintConfig set ");
			strSql.Append("PackLot=@PackLot,");
			strSql.Append("PrintType=@PrintType,");
			strSql.Append("TriggerCount=@TriggerCount,");
			strSql.Append("LabName=@LabName,");
			strSql.Append("LabPath=@LabPath,");
			strSql.Append("LabID=@LabID");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PackLot", SqlDbType.VarChar,50),
					new SqlParameter("@PrintType", SqlDbType.VarChar,50),
					new SqlParameter("@TriggerCount", SqlDbType.Int,4),
					new SqlParameter("@LabName", SqlDbType.VarChar,200),
					new SqlParameter("@LabPath", SqlDbType.VarChar,200),
					new SqlParameter("@LabID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PackLot;
			parameters[1].Value = model.PrintType;
			parameters[2].Value = model.TriggerCount;
			parameters[3].Value = model.LabName;
			parameters[4].Value = model.LabPath;
			parameters[5].Value = model.LabID;
			parameters[6].Value = model.OrderID;

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
		public bool Delete(string OrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OQC_OrderPrintConfig ");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
			parameters[0].Value = OrderID;

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
		public bool DeleteList(string OrderIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OQC_OrderPrintConfig ");
			strSql.Append(" where OrderID in ("+OrderIDlist + ")  ");
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
		public MES.Server.Model.OQC_OrderPrintConfig GetModel(string OrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrderID,PackLot,PrintType,TriggerCount,LabName,LabPath,LabID from OQC_OrderPrintConfig ");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
			parameters[0].Value = OrderID;

			MES.Server.Model.OQC_OrderPrintConfig model=new MES.Server.Model.OQC_OrderPrintConfig();
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
		public MES.Server.Model.OQC_OrderPrintConfig DataRowToModel(DataRow row)
		{
			MES.Server.Model.OQC_OrderPrintConfig model=new MES.Server.Model.OQC_OrderPrintConfig();
			if (row != null)
			{
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["PackLot"]!=null)
				{
					model.PackLot=row["PackLot"].ToString();
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
				if(row["LabID"]!=null && row["LabID"].ToString()!="")
				{
					model.LabID=int.Parse(row["LabID"].ToString());
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
			strSql.Append("select OrderID,PackLot,PrintType,TriggerCount,LabName,LabPath,LabID ");
			strSql.Append(" FROM OQC_OrderPrintConfig ");
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
			strSql.Append(" OrderID,PackLot,PrintType,TriggerCount,LabName,LabPath,LabID ");
			strSql.Append(" FROM OQC_OrderPrintConfig ");
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
			strSql.Append("select count(1) FROM OQC_OrderPrintConfig ");
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
				strSql.Append("order by T.OrderID desc");
			}
			strSql.Append(")AS Row, T.*  from OQC_OrderPrintConfig T ");
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
			parameters[0].Value = "OQC_OrderPrintConfig";
			parameters[1].Value = "OrderID";
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

