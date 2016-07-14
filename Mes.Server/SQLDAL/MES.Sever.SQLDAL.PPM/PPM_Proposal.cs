/* PPM_Proposal.cs
*
* 功 能： N/A
* 类 名： PPM_Proposal
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/10 13:57:04   张文明    初版
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
	/// 数据访问类:PPM_Proposal
	/// </summary>
	public partial class PPM_Proposal:IPPM_Proposal
	{
		public PPM_Proposal()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.PPM_Proposal model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PPM_Proposal(");
			strSql.Append("Upm_ID,Title,U_Content,Up_User,Up_Date,Feasibility,Executor,U_Plan,Implement,Progress,Result,Close_Data,Audit_Content,Audit_User,R1,R2,R3)");
			strSql.Append(" values (");
			strSql.Append("@Upm_ID,@Title,@U_Content,@Up_User,@Up_Date,@Feasibility,@Executor,@U_Plan,@Implement,@Progress,@Result,@Close_Data,@Audit_Content,@Audit_User,@R1,@R2,@R3)");
			SqlParameter[] parameters = {
					new SqlParameter("@Upm_ID", SqlDbType.VarChar,100),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@U_Content", SqlDbType.VarChar,1000),
					new SqlParameter("@Up_User", SqlDbType.VarChar,100),
					new SqlParameter("@Up_Date", SqlDbType.DateTime),
					new SqlParameter("@Feasibility", SqlDbType.VarChar,100),
					new SqlParameter("@Executor", SqlDbType.VarChar,100),
					new SqlParameter("@U_Plan", SqlDbType.VarChar,3000),
					new SqlParameter("@Implement", SqlDbType.VarChar,3000),
					new SqlParameter("@Progress", SqlDbType.VarChar,100),
					new SqlParameter("@Result", SqlDbType.VarChar,100),
					new SqlParameter("@Close_Data", SqlDbType.DateTime),
					new SqlParameter("@Audit_Content", SqlDbType.VarChar,3000),
					new SqlParameter("@Audit_User", SqlDbType.VarChar,100),
					new SqlParameter("@R1", SqlDbType.VarChar,3000),
					new SqlParameter("@R2", SqlDbType.VarChar,3000),
					new SqlParameter("@R3", SqlDbType.VarChar,3000)
					};
			parameters[0].Value = model.Upm_ID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.U_Content;
			parameters[3].Value = model.Up_User;
			parameters[4].Value = model.Up_Date;
			parameters[5].Value = model.Feasibility;
			parameters[6].Value = model.Executor;
			parameters[7].Value = model.U_Plan;
			parameters[8].Value = model.Implement;
			parameters[9].Value = model.Progress;
			parameters[10].Value = model.Result;
			parameters[11].Value = model.Close_Data;
			parameters[12].Value = model.Audit_Content;
			parameters[13].Value = model.Audit_User;
			parameters[14].Value = model.R1;
			parameters[15].Value = model.R2;
			parameters[16].Value = model.R3;
	

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
		public bool Update(Model.PPM_Proposal model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PPM_Proposal set ");
			strSql.Append("Upm_ID=@Upm_ID,");
			strSql.Append("Title=@Title,");
			strSql.Append("U_Content=@U_Content,");
			strSql.Append("Up_User=@Up_User,");
			strSql.Append("Up_Date=@Up_Date,");
			strSql.Append("Feasibility=@Feasibility,");
			strSql.Append("Executor=@Executor,");
			strSql.Append("U_Plan=@U_Plan,");
			strSql.Append("Implement=@Implement,");
			strSql.Append("Progress=@Progress,");
			strSql.Append("Result=@Result,");
			strSql.Append("Close_Data=@Close_Data,");
			strSql.Append("Audit_Content=@Audit_Content,");
			strSql.Append("Audit_User=@Audit_User,");
			strSql.Append("R1=@R1,");
			strSql.Append("R2=@R2,");
			strSql.Append("R3=@R3,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Upm_ID", SqlDbType.VarChar,100),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@U_Content", SqlDbType.VarChar,1000),
					new SqlParameter("@Up_User", SqlDbType.VarChar,100),
					new SqlParameter("@Up_Date", SqlDbType.DateTime),
					new SqlParameter("@Feasibility", SqlDbType.VarChar,100),
					new SqlParameter("@Executor", SqlDbType.VarChar,100),
					new SqlParameter("@U_Plan", SqlDbType.VarChar,3000),
					new SqlParameter("@Implement", SqlDbType.VarChar,3000),
					new SqlParameter("@Progress", SqlDbType.VarChar,100),
					new SqlParameter("@Result", SqlDbType.VarChar,100),
					new SqlParameter("@Close_Data", SqlDbType.DateTime),
					new SqlParameter("@Audit_Content", SqlDbType.VarChar,3000),
					new SqlParameter("@Audit_User", SqlDbType.VarChar,100),
					new SqlParameter("@R1", SqlDbType.VarChar,3000),
					new SqlParameter("@R2", SqlDbType.VarChar,3000),
					new SqlParameter("@R3", SqlDbType.VarChar,3000),
					};
			parameters[0].Value = model.Upm_ID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.U_Content;
			parameters[3].Value = model.Up_User;
			parameters[4].Value = model.Up_Date;
			parameters[5].Value = model.Feasibility;
			parameters[6].Value = model.Executor;
			parameters[7].Value = model.U_Plan;
			parameters[8].Value = model.Implement;
			parameters[9].Value = model.Progress;
			parameters[10].Value = model.Result;
			parameters[11].Value = model.Close_Data;
			parameters[12].Value = model.Audit_Content;
			parameters[13].Value = model.Audit_User;
			parameters[14].Value = model.R1;
			parameters[15].Value = model.R2;
			parameters[16].Value = model.R3;
			

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PPM_Proposal ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Model.PPM_Proposal GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Upm_ID,Title,U_Content,Up_User,Up_Date,Feasibility,Executor,U_Plan,Implement,Progress,Result,Close_Data,Audit_Content,Audit_User,R1,R2,R3,ID_Key from PPM_Proposal ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            Model.PPM_Proposal model=new Model.PPM_Proposal();
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
		public Model.PPM_Proposal DataRowToModel(DataRow row)
		{
            Model.PPM_Proposal model=new Model.PPM_Proposal();
			if (row != null)
			{
				if(row["Upm_ID"]!=null)
				{
					model.Upm_ID=row["Upm_ID"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["U_Content"]!=null)
				{
					model.U_Content=row["U_Content"].ToString();
				}
				if(row["Up_User"]!=null)
				{
					model.Up_User=row["Up_User"].ToString();
				}
				if(row["Up_Date"]!=null && row["Up_Date"].ToString()!="")
				{
					model.Up_Date=DateTime.Parse(row["Up_Date"].ToString());
				}
				if(row["Feasibility"]!=null)
				{
					model.Feasibility=row["Feasibility"].ToString();
				}
				if(row["Executor"]!=null)
				{
					model.Executor=row["Executor"].ToString();
				}
				if(row["U_Plan"]!=null)
				{
					model.U_Plan=row["U_Plan"].ToString();
				}
				if(row["Implement"]!=null)
				{
					model.Implement=row["Implement"].ToString();
				}
				if(row["Progress"]!=null)
				{
					model.Progress=row["Progress"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Close_Data"]!=null && row["Close_Data"].ToString()!="")
				{
					model.Close_Data=DateTime.Parse(row["Close_Data"].ToString());
				}
				if(row["Audit_Content"]!=null)
				{
					model.Audit_Content=row["Audit_Content"].ToString();
				}
				if(row["Audit_User"]!=null)
				{
					model.Audit_User=row["Audit_User"].ToString();
				}
				if(row["R1"]!=null)
				{
					model.R1=row["R1"].ToString();
				}
				if(row["R2"]!=null)
				{
					model.R2=row["R2"].ToString();
				}
				if(row["R3"]!=null)
				{
					model.R3=row["R3"].ToString();
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
			strSql.Append("select Upm_ID,Title,U_Content,Up_User,Up_Date,Feasibility,Executor,U_Plan,Implement,Progress,Result,Close_Data,Audit_Content,Audit_User,R1,R2,R3,ID_Key ");
			strSql.Append(" FROM PPM_Proposal ");
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
			strSql.Append(" Upm_ID,Title,U_Content,Up_User,Up_Date,Feasibility,Executor,U_Plan,Implement,Progress,Result,Close_Data,Audit_Content,Audit_User,R1,R2,R3,ID_Key ");
			strSql.Append(" FROM PPM_Proposal ");
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
			strSql.Append("select count(1) FROM PPM_Proposal ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from PPM_Proposal T ");
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
			parameters[0].Value = "PPM_Proposal";
			parameters[1].Value = "";
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

