/**  版本信息模板在安装目录下，可自行修改。
* V_ProductionRecords.cs
*
* 功 能： N/A
* 类 名： V_ProductionRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/8/17 星期一 9:40:24   张文明    初版
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
	/// 数据访问类:V_ProductionRecords
	/// </summary>
	public partial class V_ProductionRecords:IV_ProductionRecords
	{
		public V_ProductionRecords()
		{}
      
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.V_ProductionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into V_ProductionRecords(");
            strSql.Append("OrderID,Num,ProcessID,ProcessName,Qty,Qty_NG,Qty_OK,PassRatio,RejectRatio)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@Num,@ProcessID,@ProcessName,@Qty,@Qty_NG,@Qty_OK,@PassRatio,@RejectRatio)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
					new SqlParameter("@Qty", SqlDbType.Decimal,17),
					new SqlParameter("@Qty_NG", SqlDbType.Decimal,17),
					new SqlParameter("@Qty_OK", SqlDbType.Decimal,17),
					new SqlParameter("@PassRatio", SqlDbType.VarChar,42),
					new SqlParameter("@RejectRatio", SqlDbType.VarChar,42)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.Num;
            parameters[2].Value = model.ProcessID;
            parameters[3].Value = model.ProcessName;
            parameters[4].Value = model.Qty;
            parameters[5].Value = model.Qty_NG;
            parameters[6].Value = model.Qty_OK;
            parameters[7].Value = model.PassRatio;
            parameters[8].Value = model.RejectRatio;

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
        public bool Update(Model.V_ProductionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update V_ProductionRecords set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Num=@Num,");
            strSql.Append("ProcessID=@ProcessID,");
            strSql.Append("ProcessName=@ProcessName,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("Qty_NG=@Qty_NG,");
            strSql.Append("Qty_OK=@Qty_OK,");
            strSql.Append("PassRatio=@PassRatio,");
            strSql.Append("RejectRatio=@RejectRatio");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
					new SqlParameter("@Qty", SqlDbType.Decimal,17),
					new SqlParameter("@Qty_NG", SqlDbType.Decimal,17),
					new SqlParameter("@Qty_OK", SqlDbType.Decimal,17),
					new SqlParameter("@PassRatio", SqlDbType.VarChar,42),
					new SqlParameter("@RejectRatio", SqlDbType.VarChar,42)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.Num;
            parameters[2].Value = model.ProcessID;
            parameters[3].Value = model.ProcessName;
            parameters[4].Value = model.Qty;
            parameters[5].Value = model.Qty_NG;
            parameters[6].Value = model.Qty_OK;
            parameters[7].Value = model.PassRatio;
            parameters[8].Value = model.RejectRatio;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from V_ProductionRecords ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

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
        /// 得到一个对象实体
        /// </summary>
        public Model.V_ProductionRecords GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,Num,ProcessID,ProcessName,Qty,Qty_NG,Qty_OK,PassRatio,RejectRatio from V_ProductionRecords ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
			};

            Model.V_ProductionRecords model = new Model.V_ProductionRecords();
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
        public Model.V_ProductionRecords DataRowToModel(DataRow row)
        {
            Model.V_ProductionRecords model = new Model.V_ProductionRecords();
            if (row != null)
            {
                if (row["OrderID"] != null)
                {
                    model.OrderID = row["OrderID"].ToString();
                }
                if (row["Num"] != null && row["Num"].ToString() != "")
                {
                    model.Num = int.Parse(row["Num"].ToString());
                }
                if (row["ProcessID"] != null)
                {
                    model.ProcessID = row["ProcessID"].ToString();
                }
                if (row["ProcessName"] != null)
                {
                    model.ProcessName = row["ProcessName"].ToString();
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["Qty_NG"] != null && row["Qty_NG"].ToString() != "")
                {
                    model.Qty_NG = decimal.Parse(row["Qty_NG"].ToString());
                }
                if (row["Qty_OK"] != null && row["Qty_OK"].ToString() != "")
                {
                    model.Qty_OK = decimal.Parse(row["Qty_OK"].ToString());
                }
                if (row["PassRatio"] != null)
                {
                    model.PassRatio = row["PassRatio"].ToString();
                }
                if (row["RejectRatio"] != null)
                {
                    model.RejectRatio = row["RejectRatio"].ToString();
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
            strSql.Append("select OrderID,Num,ProcessID,ProcessName,Qty,Qty_NG,Qty_OK,PassRatio,RejectRatio ");
            strSql.Append(" FROM V_ProductionRecords ");
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
            strSql.Append(" OrderID,Num,ProcessID,ProcessName,Qty,Qty_NG,Qty_OK,PassRatio,RejectRatio ");
            strSql.Append(" FROM V_ProductionRecords ");
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
            strSql.Append("select count(1) FROM V_ProductionRecords ");
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from V_ProductionRecords T ");
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
            parameters[0].Value = "V_ProductionRecords";
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

