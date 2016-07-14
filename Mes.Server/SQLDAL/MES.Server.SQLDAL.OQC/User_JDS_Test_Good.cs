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
using System.Text;
using System.Data.SqlClient;
using MES.Server.IDAL;
using MES.Server.DBUtility;//Please add references
namespace MES.Server.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:User_JDS_Test_Good
	/// </summary>
	public partial class User_JDS_Test_Good:IUser_JDS_Test_Good
	{
        DbHelperSQLP TwoLineCon = new DbHelperSQLP(PubConnection.TwoLine);
        public User_JDS_Test_Good()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(MES.Server.Model.User_JDS_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_JDS_Test_Good(");
			strSql.Append("TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B)");
			strSql.Append(" values (");
			strSql.Append("@TestDate,@PartNumber,@SN,@Result,@Wave,@IL_A,@Refl_A,@IL_B,@Refl_B)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10)};
			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.SN;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;

			object obj = TwoLineCon.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MES.Server.Model.User_JDS_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_JDS_Test_Good set ");
			strSql.Append("TestDate=@TestDate,");
			strSql.Append("PartNumber=@PartNumber,");
			strSql.Append("SN=@SN,");
			strSql.Append("Result=@Result,");
			strSql.Append("Wave=@Wave,");
			strSql.Append("IL_A=@IL_A,");
			strSql.Append("Refl_A=@Refl_A,");
			strSql.Append("IL_B=@IL_B,");
			strSql.Append("Refl_B=@Refl_B");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@TestDate", SqlDbType.VarChar,25),
					new SqlParameter("@PartNumber", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,10),
					new SqlParameter("@Wave", SqlDbType.VarChar,10),
					new SqlParameter("@IL_A", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_A", SqlDbType.VarChar,10),
					new SqlParameter("@IL_B", SqlDbType.VarChar,10),
					new SqlParameter("@Refl_B", SqlDbType.VarChar,10),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TestDate;
			parameters[1].Value = model.PartNumber;
			parameters[2].Value = model.SN;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Wave;
			parameters[5].Value = model.IL_A;
			parameters[6].Value = model.Refl_A;
			parameters[7].Value = model.IL_B;
			parameters[8].Value = model.Refl_B;
			parameters[9].Value = model.ID_Key;

			int rows=TwoLineCon.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_JDS_Test_Good ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			int rows=TwoLineCon.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_JDS_Test_Good ");
			strSql.Append(" where ID_Key in ("+ID_Keylist + ")  ");
			int rows=TwoLineCon.ExecuteSql(strSql.ToString());
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
		public MES.Server.Model.User_JDS_Test_Good GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ID_Key from User_JDS_Test_Good ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			MES.Server.Model.User_JDS_Test_Good model=new MES.Server.Model.User_JDS_Test_Good();
			DataSet ds=TwoLineCon.Query(strSql.ToString(),parameters);
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
		public MES.Server.Model.User_JDS_Test_Good DataRowToModel(DataRow row)
		{
			MES.Server.Model.User_JDS_Test_Good model=new MES.Server.Model.User_JDS_Test_Good();
			if (row != null)
			{
				if(row["TestDate"]!=null)
				{
					model.TestDate=row["TestDate"].ToString();
				}
				if(row["PartNumber"]!=null)
				{
					model.PartNumber=row["PartNumber"].ToString();
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
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
			strSql.Append("select TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ID_Key ");
			strSql.Append(" FROM User_JDS_Test_Good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return TwoLineCon.Query(strSql.ToString());
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
			strSql.Append(" TestDate,PartNumber,SN,Result,Wave,IL_A,Refl_A,IL_B,Refl_B,ID_Key ");
			strSql.Append(" FROM User_JDS_Test_Good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return TwoLineCon.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM User_JDS_Test_Good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = TwoLineCon.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from User_JDS_Test_Good T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return TwoLineCon.Query(strSql.ToString());
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
			parameters[0].Value = "User_JDS_Test_Good";
			parameters[1].Value = "ID_Key";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return TwoLineCon.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

