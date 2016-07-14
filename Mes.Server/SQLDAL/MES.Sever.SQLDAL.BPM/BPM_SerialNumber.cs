/* BPM_SerialNumber.cs
*
* 功 能： N/A
* 类 名： BPM_SerialNumber
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/13 13:19:41   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
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
	/// 数据访问类:BPM_SerialNumber
	/// </summary>
	public partial class BPM_SerialNumber:IBPM_SerialNumber
	{
		public BPM_SerialNumber()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BPM_SerialNumber");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)			};
			parameters[0].Value = SN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.BPM_SerialNumber model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BPM_SerialNumber(");
			strSql.Append("SN,Type,State,Qty,BatchNo,OrderID,R1)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Type,@State,@Qty,@BatchNo,@OrderID,@R1)");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.VarChar,50),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@R1", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.State;
			parameters[3].Value = model.Qty;
			parameters[4].Value = model.BatchNo;
			parameters[5].Value = model.OrderID;
			parameters[6].Value = model.R1;

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
		public bool Update(Model.BPM_SerialNumber model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BPM_SerialNumber set ");
			strSql.Append("Type=@Type,");
			strSql.Append("State=@State,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("R1=@R1");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.VarChar,50),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@R1", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.State;
			parameters[2].Value = model.Qty;
			parameters[3].Value = model.BatchNo;
			parameters[4].Value = model.OrderID;
			parameters[5].Value = model.R1;
			parameters[6].Value = model.SN;

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
		public bool Delete(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BPM_SerialNumber ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)			};
			parameters[0].Value = SN;

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
		public bool DeleteList(string SNlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BPM_SerialNumber ");
			strSql.Append(" where SN in ("+SNlist + ")  ");
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
		public Model.BPM_SerialNumber GetModel(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Type,State,Qty,BatchNo,OrderID,R1 from BPM_SerialNumber ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)			};
			parameters[0].Value = SN;

            Model.BPM_SerialNumber model=new Model.BPM_SerialNumber();
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
		public Model.BPM_SerialNumber DataRowToModel(DataRow row)
		{
            Model.BPM_SerialNumber model=new Model.BPM_SerialNumber();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["Qty"]!=null)
				{
					model.Qty=row["Qty"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["R1"]!=null)
				{
					model.R1=row["R1"].ToString();
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
			strSql.Append("select SN,Type,State,Qty,BatchNo,OrderID,R1 ");
			strSql.Append(" FROM BPM_SerialNumber ");
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
			strSql.Append(" SN,Type,State,Qty,BatchNo,OrderID,R1 ");
			strSql.Append(" FROM BPM_SerialNumber ");
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
			strSql.Append("select count(1) FROM BPM_SerialNumber ");
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
				strSql.Append("order by T.SN desc");
			}
			strSql.Append(")AS Row, T.*  from BPM_SerialNumber T ");
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
			parameters[0].Value = "BPM_SerialNumber";
			parameters[1].Value = "SN";
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

