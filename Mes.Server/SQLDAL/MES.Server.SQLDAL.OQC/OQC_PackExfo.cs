/**
* OQC_PackExfo.cs
*
* 功 能： N/A
* 类 名： OQC_PackExfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/29 18:03:48   张文明    初版
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
	/// 数据访问类:OQC_PackExfo
	/// </summary>
	public partial class OQC_PackExfo:IOQC_PackExfo
	{
		public OQC_PackExfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OQC_PackExfo");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25)			};
			parameters[0].Value = SN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MES.Server.Model.OQC_PackExfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OQC_PackExfo(");
			strSql.Append("SN,TestDate,PartNumber,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName,ID_Key)");
			strSql.Append(" values (");
			strSql.Append("@SN,@TestDate,@PartNumber,@Result,@Wave,@IL_A,@Refl_A,@IL_B,@Refl_B,@ClientSN,@OrderID,@BatchNo,@PackDate,@CustomerName,@ID_Key)");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10),
					new SqlParameter("@ClientSN", SqlDbType.VarChar,25),
					new SqlParameter("@OrderID", SqlDbType.VarChar,35),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,35),
					new SqlParameter("@PackDate", SqlDbType.DateTime),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,25),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.TestDate;
			parameters[2].Value = model.PartNumber;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;
			parameters[9].Value = model.ClientSN;
			parameters[10].Value = model.OrderID;
			parameters[11].Value = model.BatchNo;
			parameters[12].Value = model.PackDate;
			parameters[13].Value = model.CustomerName;
			parameters[14].Value = model.ID_Key;

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
		public bool Update(MES.Server.Model.OQC_PackExfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OQC_PackExfo set ");
			strSql.Append("TestDate=@TestDate,");
			strSql.Append("PartNumber=@PartNumber,");
			strSql.Append("Result=@Result,");
			strSql.Append("Wave=@Wave,");
			strSql.Append("IL_A=@IL_A,");
			strSql.Append("Refl_A=@Refl_A,");
			strSql.Append("IL_B=@IL_B,");
			strSql.Append("Refl_B=@Refl_B,");
			strSql.Append("ClientSN=@ClientSN,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("PackDate=@PackDate,");
			strSql.Append("CustomerName=@CustomerName,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10),
					new SqlParameter("@ClientSN", SqlDbType.VarChar,25),
					new SqlParameter("@OrderID", SqlDbType.VarChar,35),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,35),
					new SqlParameter("@PackDate", SqlDbType.DateTime),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,25),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@SN", SqlDbType.VarChar,25)};
			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.Result;
			parameters[3].Value = model.Wave;
			parameters[4].Value = model.IL_A;
			parameters[5].Value = model.Refl_A;
			parameters[6].Value = model.IL_B;
			parameters[7].Value = model.Refl_B;
			parameters[8].Value = model.ClientSN;
			parameters[9].Value = model.OrderID;
			parameters[10].Value = model.BatchNo;
			parameters[11].Value = model.PackDate;
			parameters[12].Value = model.CustomerName;
			parameters[13].Value = model.ID_Key;
			parameters[14].Value = model.SN;

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
			strSql.Append("delete from OQC_PackExfo ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25)			};
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
			strSql.Append("delete from OQC_PackExfo ");
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
		public MES.Server.Model.OQC_PackExfo GetModel(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,TestDate,PartNumber,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName,ID_Key from OQC_PackExfo ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25)			};
			parameters[0].Value = SN;

			MES.Server.Model.OQC_PackExfo model=new MES.Server.Model.OQC_PackExfo();
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
		public MES.Server.Model.OQC_PackExfo DataRowToModel(DataRow row)
		{
			MES.Server.Model.OQC_PackExfo model=new MES.Server.Model.OQC_PackExfo();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["TestDate"]!=null)
				{
					model.TestDate=row["TestDate"].ToString();
				}
				if(row["PartNumber"]!=null)
				{
					model.PartNumber=row["PartNumber"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Wave"]!=null)
				{
					model.Wave=row["Wave"].ToString();
				}
				if(row["IL_A"]!=null)
				{
					model.IL_A=row["IL_A"].ToString();
				}
				if(row["Refl_A"]!=null)
				{
					model.Refl_A=row["Refl_A"].ToString();
				}
				if(row["IL_B"]!=null)
				{
					model.IL_B=row["IL_B"].ToString();
				}
				if(row["Refl_B"]!=null)
				{
					model.Refl_B=row["Refl_B"].ToString();
				}
				if(row["ClientSN"]!=null)
				{
					model.ClientSN=row["ClientSN"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["PackDate"]!=null && row["PackDate"].ToString()!="")
				{
					model.PackDate=DateTime.Parse(row["PackDate"].ToString());
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
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
			strSql.Append("select SN,TestDate,PartNumber,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName,ID_Key ");
			strSql.Append(" FROM OQC_PackExfo ");
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
			strSql.Append(" SN,TestDate,PartNumber,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ClientSN,OrderID,BatchNo,PackDate,CustomerName,ID_Key ");
			strSql.Append(" FROM OQC_PackExfo ");
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
			strSql.Append("select count(1) FROM OQC_PackExfo ");
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
			strSql.Append(")AS Row, T.*  from OQC_PackExfo T ");
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
			parameters[0].Value = "OQC_PackExfo";
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

