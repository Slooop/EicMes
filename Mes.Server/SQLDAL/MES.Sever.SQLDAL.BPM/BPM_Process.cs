/**  版本信息模板在安装目录下，可自行修改。
* BPM_Process.cs
*
* 功 能： N/A
* 类 名： BPM_Process
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/13 星期二 13:29:46   张文明    初版
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
	/// 数据访问类:BPM_Process
	/// </summary>
	public partial class BPM_Process:IBPM_Process
	{
		public BPM_Process()
		{}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProcessID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BPM_Process");
            strSql.Append(" where ProcessID=@ProcessID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50)            };
            parameters[0].Value = ProcessID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MES.Server.Model.BPM_Process model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_Process(");
            strSql.Append("ProcessID,Name,StandardHours,Relax,PCSH,Workstation,WorkShop,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ProcessID,@Name,@StandardHours,@Relax,@PCSH,@Workstation,@WorkShop,@Remark)");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
                    new SqlParameter("@Name", SqlDbType.VarChar,50),
                    new SqlParameter("@StandardHours", SqlDbType.Float,8),
                    new SqlParameter("@Relax", SqlDbType.Float,8),
                    new SqlParameter("@PCSH", SqlDbType.Int,4),
                    new SqlParameter("@Workstation", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ProcessID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.StandardHours;
            parameters[3].Value = model.Relax;
            parameters[4].Value = model.PCSH;
            parameters[5].Value = model.Workstation;
            parameters[6].Value = model.WorkShop;
            parameters[7].Value = model.Remark;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(MES.Server.Model.BPM_Process model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_Process set ");
            strSql.Append("Name=@Name,");
            strSql.Append("StandardHours=@StandardHours,");
            strSql.Append("Relax=@Relax,");
            strSql.Append("PCSH=@PCSH,");
            strSql.Append("Workstation=@Workstation,");
            strSql.Append("WorkShop=@WorkShop,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ProcessID=@ProcessID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,50),
                    new SqlParameter("@StandardHours", SqlDbType.Float,8),
                    new SqlParameter("@Relax", SqlDbType.Float,8),
                    new SqlParameter("@PCSH", SqlDbType.Int,4),
                    new SqlParameter("@Workstation", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.StandardHours;
            parameters[2].Value = model.Relax;
            parameters[3].Value = model.PCSH;
            parameters[4].Value = model.Workstation;
            parameters[5].Value = model.WorkShop;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.ProcessID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string ProcessID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_Process ");
            strSql.Append(" where ProcessID=@ProcessID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50)            };
            parameters[0].Value = ProcessID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string ProcessIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_Process ");
            strSql.Append(" where ProcessID in (" + ProcessIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public MES.Server.Model.BPM_Process GetModel(string ProcessID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProcessID,Name,StandardHours,Relax,PCSH,Workstation,WorkShop,Remark from BPM_Process ");
            strSql.Append(" where ProcessID=@ProcessID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50)            };
            parameters[0].Value = ProcessID;

            MES.Server.Model.BPM_Process model = new MES.Server.Model.BPM_Process();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public MES.Server.Model.BPM_Process DataRowToModel(DataRow row)
        {
            MES.Server.Model.BPM_Process model = new MES.Server.Model.BPM_Process();
            if (row != null)
            {
                if (row["ProcessID"] != null)
                {
                    model.ProcessID = row["ProcessID"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["StandardHours"] != null && row["StandardHours"].ToString() != "")
                {
                    model.StandardHours = decimal.Parse(row["StandardHours"].ToString());
                }
                if (row["Relax"] != null && row["Relax"].ToString() != "")
                {
                    model.Relax = decimal.Parse(row["Relax"].ToString());
                }
                if (row["PCSH"] != null && row["PCSH"].ToString() != "")
                {
                    model.PCSH = int.Parse(row["PCSH"].ToString());
                }
                if (row["Workstation"] != null)
                {
                    model.Workstation = row["Workstation"].ToString();
                }
                if (row["WorkShop"] != null)
                {
                    model.WorkShop = row["WorkShop"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProcessID,Name,StandardHours,Relax,PCSH,Workstation,WorkShop,Remark ");
            strSql.Append(" FROM BPM_Process ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ProcessID,Name,StandardHours,Relax,PCSH,Workstation,WorkShop,Remark ");
            strSql.Append(" FROM BPM_Process ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM BPM_Process ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ProcessID desc");
            }
            strSql.Append(")AS Row, T.*  from BPM_Process T ");
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
			parameters[0].Value = "BPM_Process";
			parameters[1].Value = "ProcessID";
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

