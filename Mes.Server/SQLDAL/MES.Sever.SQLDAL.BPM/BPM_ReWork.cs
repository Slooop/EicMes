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
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MES.Server.IDAL;
using MES.Server.DBUtility;//Please add references
namespace MES.Server.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BPM_ReWork
	/// </summary>
	public partial class BPM_ReWork:IBPM_ReWork
	{
		public BPM_ReWork()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.BPM_ReWork model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BPM_ReWork(");
			strSql.Append("OrderID,SN,WK_Send,CauseNG,JudgeJobNum,JudgeUser,WK_Receive,Disposition,Result,DispositonJobNum,DispositonUser,Qty,DateTime)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@SN,@WK_Send,@CauseNG,@JudgeJobNum,@JudgeUser,@WK_Receive,@Disposition,@Result,@DispositonJobNum,@DispositonUser,@Qty,@DateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@WK_Send", SqlDbType.VarChar,50),
					new SqlParameter("@CauseNG", SqlDbType.VarChar,50),
					new SqlParameter("@JudgeJobNum", SqlDbType.VarChar,50),
					new SqlParameter("@JudgeUser", SqlDbType.VarChar,50),
					new SqlParameter("@WK_Receive", SqlDbType.VarChar,50),
					new SqlParameter("@Disposition", SqlDbType.VarChar,50),
					new SqlParameter("@Result", SqlDbType.VarChar,50),
					new SqlParameter("@DispositonJobNum", SqlDbType.VarChar,50),
					new SqlParameter("@DispositonUser", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.SN;
			parameters[2].Value = model.WK_Send;
			parameters[3].Value = model.CauseNG;
			parameters[4].Value = model.JudgeJobNum;
			parameters[5].Value = model.JudgeUser;
			parameters[6].Value = model.WK_Receive;
			parameters[7].Value = model.Disposition;
			parameters[8].Value = model.Result;
			parameters[9].Value = model.DispositonJobNum;
			parameters[10].Value = model.DispositonUser;
			parameters[11].Value = model.Qty;
			parameters[12].Value = model.DateTime;

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
		public bool Update(Model.BPM_ReWork model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BPM_ReWork set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("SN=@SN,");
			strSql.Append("WK_Send=@WK_Send,");
			strSql.Append("CauseNG=@CauseNG,");
			strSql.Append("JudgeJobNum=@JudgeJobNum,");
			strSql.Append("JudgeUser=@JudgeUser,");
			strSql.Append("WK_Receive=@WK_Receive,");
			strSql.Append("Disposition=@Disposition,");
			strSql.Append("Result=@Result,");
			strSql.Append("DispositonJobNum=@DispositonJobNum,");
			strSql.Append("DispositonUser=@DispositonUser,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("DateTime=@DateTime");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@WK_Send", SqlDbType.VarChar,50),
					new SqlParameter("@CauseNG", SqlDbType.VarChar,50),
					new SqlParameter("@JudgeJobNum", SqlDbType.VarChar,50),
					new SqlParameter("@JudgeUser", SqlDbType.VarChar,50),
					new SqlParameter("@WK_Receive", SqlDbType.VarChar,50),
					new SqlParameter("@Disposition", SqlDbType.VarChar,50),
					new SqlParameter("@Result", SqlDbType.VarChar,50),
					new SqlParameter("@DispositonJobNum", SqlDbType.VarChar,50),
					new SqlParameter("@DispositonUser", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.SN;
			parameters[2].Value = model.WK_Send;
			parameters[3].Value = model.CauseNG;
			parameters[4].Value = model.JudgeJobNum;
			parameters[5].Value = model.JudgeUser;
			parameters[6].Value = model.WK_Receive;
			parameters[7].Value = model.Disposition;
			parameters[8].Value = model.Result;
			parameters[9].Value = model.DispositonJobNum;
			parameters[10].Value = model.DispositonUser;
			parameters[11].Value = model.Qty;
			parameters[12].Value = model.DateTime;

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
			strSql.Append("delete from BPM_ReWork ");
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
		public Model.BPM_ReWork GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrderID,SN,WK_Send,CauseNG,JudgeJobNum,JudgeUser,WK_Receive,Disposition,Result,DispositonJobNum,DispositonUser,Qty,DateTime from BPM_ReWork ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            Model.BPM_ReWork model=new Model.BPM_ReWork();
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
		public Model.BPM_ReWork DataRowToModel(DataRow row)
		{
            Model.BPM_ReWork model=new Model.BPM_ReWork();
			if (row != null)
			{
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["WK_Send"]!=null)
				{
					model.WK_Send=row["WK_Send"].ToString();
				}
				if(row["CauseNG"]!=null)
				{
					model.CauseNG=row["CauseNG"].ToString();
				}
				if(row["JudgeJobNum"]!=null)
				{
					model.JudgeJobNum=row["JudgeJobNum"].ToString();
				}
				if(row["JudgeUser"]!=null)
				{
					model.JudgeUser=row["JudgeUser"].ToString();
				}
				if(row["WK_Receive"]!=null)
				{
					model.WK_Receive=row["WK_Receive"].ToString();
				}
				if(row["Disposition"]!=null)
				{
					model.Disposition=row["Disposition"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["DispositonJobNum"]!=null)
				{
					model.DispositonJobNum=row["DispositonJobNum"].ToString();
				}
				if(row["DispositonUser"]!=null)
				{
					model.DispositonUser=row["DispositonUser"].ToString();
				}
				if(row["Qty"]!=null && row["Qty"].ToString()!="")
				{
					model.Qty=int.Parse(row["Qty"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
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
			strSql.Append("select OrderID,SN,WK_Send,CauseNG,JudgeJobNum,JudgeUser,WK_Receive,Disposition,Result,DispositonJobNum,DispositonUser,Qty,DateTime ");
			strSql.Append(" FROM BPM_ReWork ");
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
			strSql.Append(" OrderID,SN,WK_Send,CauseNG,JudgeJobNum,JudgeUser,WK_Receive,Disposition,Result,DispositonJobNum,DispositonUser,Qty,DateTime ");
			strSql.Append(" FROM BPM_ReWork ");
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
			strSql.Append("select count(1) FROM BPM_ReWork ");
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
			strSql.Append(")AS Row, T.*  from BPM_ReWork T ");
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
			parameters[0].Value = "BPM_ReWork";
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

