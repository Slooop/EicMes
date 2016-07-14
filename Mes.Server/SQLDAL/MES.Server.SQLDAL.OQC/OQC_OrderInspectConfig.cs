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
using System.Text;
using System.Data.SqlClient;
using MES.Server.IDAL;
using MES.Server.DBUtility;//Please add references
namespace MES.Server.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:OQC_OrderInspectConfig
	/// </summary>
	public partial class OQC_OrderInspectConfig:IOQC_OrderInspectConfig
	{
		public OQC_OrderInspectConfig()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OrderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OQC_OrderInspectConfig");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
			parameters[0].Value = OrderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MES.Server.Model.OQC_OrderInspectConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OQC_OrderInspectConfig(");
			strSql.Append("OrderID,TabName,FieldName,Max,Min,ID_Key)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@TabName,@FieldName,@Max,@Min,@ID_Key)");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@TabName", SqlDbType.VarChar,50),
					new SqlParameter("@FieldName", SqlDbType.VarChar,50),
					new SqlParameter("@Max", SqlDbType.Float,8),
					new SqlParameter("@Min", SqlDbType.Float,8),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.TabName;
			parameters[2].Value = model.FieldName;
			parameters[3].Value = model.Max;
			parameters[4].Value = model.Min;
			parameters[5].Value = model.ID_Key;

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
		public bool Update(MES.Server.Model.OQC_OrderInspectConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OQC_OrderInspectConfig set ");
			strSql.Append("TabName=@TabName,");
			strSql.Append("FieldName=@FieldName,");
			strSql.Append("Max=@Max,");
			strSql.Append("Min=@Min,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TabName", SqlDbType.VarChar,50),
					new SqlParameter("@FieldName", SqlDbType.VarChar,50),
					new SqlParameter("@Max", SqlDbType.Float,8),
					new SqlParameter("@Min", SqlDbType.Float,8),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TabName;
			parameters[1].Value = model.FieldName;
			parameters[2].Value = model.Max;
			parameters[3].Value = model.Min;
			parameters[4].Value = model.ID_Key;
			parameters[5].Value = model.OrderID;

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
			strSql.Append("delete from OQC_OrderInspectConfig ");
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
			strSql.Append("delete from OQC_OrderInspectConfig ");
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
		public MES.Server.Model.OQC_OrderInspectConfig GetModel(string OrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrderID,TabName,FieldName,Max,Min,ID_Key from OQC_OrderInspectConfig ");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
			parameters[0].Value = OrderID;

			MES.Server.Model.OQC_OrderInspectConfig model=new MES.Server.Model.OQC_OrderInspectConfig();
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
		public MES.Server.Model.OQC_OrderInspectConfig DataRowToModel(DataRow row)
		{
			MES.Server.Model.OQC_OrderInspectConfig model=new MES.Server.Model.OQC_OrderInspectConfig();
			if (row != null)
			{
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["TabName"]!=null)
				{
					model.TabName=row["TabName"].ToString();
				}
				if(row["FieldName"]!=null)
				{
					model.FieldName=row["FieldName"].ToString();
				}
				if(row["Max"]!=null && row["Max"].ToString()!="")
				{
					model.Max=decimal.Parse(row["Max"].ToString());
				}
				if(row["Min"]!=null && row["Min"].ToString()!="")
				{
					model.Min=decimal.Parse(row["Min"].ToString());
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
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
			strSql.Append("select OrderID,TabName,FieldName,Max,Min,ID_Key ");
			strSql.Append(" FROM OQC_OrderInspectConfig ");
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
			strSql.Append(" OrderID,TabName,FieldName,Max,Min,ID_Key ");
			strSql.Append(" FROM OQC_OrderInspectConfig ");
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
			strSql.Append("select count(1) FROM OQC_OrderInspectConfig ");
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
			strSql.Append(")AS Row, T.*  from OQC_OrderInspectConfig T ");
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
			parameters[0].Value = "OQC_OrderInspectConfig";
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

