/**  版本信息模板在安装目录下，可自行修改。
* BPM_ProductionRecords.cs
*
* 功 能： N/A
* 类 名： BPM_ProductionRecords
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/8/6 17:00:17   张文明    初版
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
    /// 数据访问类:BPM_ProductionRecords
    /// </summary>
    public partial class BPM_ProductionRecords : IBPM_ProductionRecords
    {
        public BPM_ProductionRecords()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(Model.BPM_ProductionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_ProductionRecords(");
            strSql.Append("OrderID,FlowCardNum,Num,ProcessID,ProcessName,Qty,Qty_OK,Qty_NG,UserID,UserName,DateTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@FlowCardNum,@Num,@ProcessID,@ProcessName,@Qty,@Qty_OK,@Qty_NG,@UserID,@UserName,@DateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@FlowCardNum", SqlDbType.VarChar,50),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Qty_OK", SqlDbType.Decimal,9),
					new SqlParameter("@Qty_NG", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.NChar,10),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.FlowCardNum;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.ProcessID;
            parameters[4].Value = model.ProcessName;
            parameters[5].Value = model.Qty;
            parameters[6].Value = model.Qty_OK;
            parameters[7].Value = model.Qty_NG;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.UserName;
            parameters[10].Value = model.DateTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.BPM_ProductionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_ProductionRecords set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("FlowCardNum=@FlowCardNum,");
            strSql.Append("Num=@Num,");
            strSql.Append("ProcessID=@ProcessID,");
            strSql.Append("ProcessName=@ProcessName,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("Qty_OK=@Qty_OK,");
            strSql.Append("Qty_NG=@Qty_NG,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("DateTime=@DateTime");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@FlowCardNum", SqlDbType.VarChar,50),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
					new SqlParameter("@Qty", SqlDbType.Decimal,9),
					new SqlParameter("@Qty_OK", SqlDbType.Decimal,9),
					new SqlParameter("@Qty_NG", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.NChar,10),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.FlowCardNum;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.ProcessID;
            parameters[4].Value = model.ProcessName;
            parameters[5].Value = model.Qty;
            parameters[6].Value = model.Qty_OK;
            parameters[7].Value = model.Qty_NG;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.UserName;
            parameters[10].Value = model.DateTime;
            parameters[11].Value = model.ID_Key;

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
        public bool Delete(decimal ID_Key)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_ProductionRecords ");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
            parameters[0].Value = ID_Key;

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
        public bool DeleteList(string ID_Keylist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_ProductionRecords ");
            strSql.Append(" where ID_Key in (" + ID_Keylist + ")  ");
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
        public Model.BPM_ProductionRecords GetModel(decimal ID_Key)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,FlowCardNum,Num,ProcessID,ProcessName,Qty,Qty_OK,Qty_NG,UserID,UserName,DateTime,ID_Key from BPM_ProductionRecords ");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
            parameters[0].Value = ID_Key;

            Model.BPM_ProductionRecords model = new Model.BPM_ProductionRecords();
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
        public Model.BPM_ProductionRecords DataRowToModel(DataRow row)
        {
            Model.BPM_ProductionRecords model = new Model.BPM_ProductionRecords();
            if (row != null)
            {
                if (row["OrderID"] != null)
                {
                    model.OrderID = row["OrderID"].ToString();
                }
                if (row["FlowCardNum"] != null)
                {
                    model.FlowCardNum = row["FlowCardNum"].ToString();
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
                if (row["Qty_OK"] != null && row["Qty_OK"].ToString() != "")
                {
                    model.Qty_OK = decimal.Parse(row["Qty_OK"].ToString());
                }
                if (row["Qty_NG"] != null && row["Qty_NG"].ToString() != "")
                {
                    model.Qty_NG = decimal.Parse(row["Qty_NG"].ToString());
                }
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["DateTime"] != null && row["DateTime"].ToString() != "")
                {
                    model.DateTime = DateTime.Parse(row["DateTime"].ToString());
                }
                if (row["ID_Key"] != null && row["ID_Key"].ToString() != "")
                {
                    model.ID_Key = decimal.Parse(row["ID_Key"].ToString());
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
            strSql.Append("select OrderID,FlowCardNum,Num,ProcessID,ProcessName,Qty,Qty_OK,Qty_NG,UserID,UserName,DateTime,ID_Key ");
            strSql.Append(" FROM BPM_ProductionRecords ");
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
            strSql.Append(" OrderID,FlowCardNum,Num,ProcessID,ProcessName,Qty,Qty_OK,Qty_NG,UserID,UserName,DateTime,ID_Key ");
            strSql.Append(" FROM BPM_ProductionRecords ");
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
            strSql.Append("select count(1) FROM BPM_ProductionRecords ");
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
                strSql.Append("order by T.ID_Key desc");
            }
            strSql.Append(")AS Row, T.*  from BPM_ProductionRecords T ");
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
            parameters[0].Value = "BPM_ProductionRecords";
            parameters[1].Value = "ID_Key";
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

