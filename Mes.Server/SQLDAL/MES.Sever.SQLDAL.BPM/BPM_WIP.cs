/**  版本信息模板在安装目录下，可自行修改。
* BPM_WIP.cs
*
* 功 能： N/A
* 类 名： BPM_WIP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/7 星期一 16:36:51   张文明    初版
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
using MES.Server.Model;

namespace MES.Server.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BPM_WIP
    /// </summary>
    public partial class BPM_WIP : IBPM_WIP
    {
        public BPM_WIP()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(MES.Server.Model.BPM_WIP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_WIP(");
            strSql.Append("OrderID,ClientName,ProductName,Spec,Count,ProcessCount,ProcessID,ProcessName,StandardHours,ConnectorQty,ProcessSign,TotalStandatdHours,Qty,Qty_OK,Qty_NG,Qty_NotInput,GetTime,WorkHours,Efficiency,Wip)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@ClientName,@ProductName,@Spec,@Count,@ProcessCount,@ProcessID,@ProcessName,@StandardHours,@ConnectorQty,@ProcessSign,@TotalStandatdHours,@Qty,@Qty_OK,@Qty_NG,@Qty_NotInput,@GetTime,@WorkHours,@Efficiency,@Wip)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,20),
                    new SqlParameter("@ClientName", SqlDbType.NChar,50),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@Spec", SqlDbType.VarChar,100),
                    new SqlParameter("@Count", SqlDbType.Int,4),
                    new SqlParameter("@ProcessCount", SqlDbType.Int,4),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,20),
                    new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
                    new SqlParameter("@StandardHours", SqlDbType.Float,8),
                    new SqlParameter("@ConnectorQty", SqlDbType.Int,4),
                    new SqlParameter("@ProcessSign", SqlDbType.VarChar,30),
                    new SqlParameter("@TotalStandatdHours", SqlDbType.Float,8),
                    new SqlParameter("@Qty", SqlDbType.Int,4),
                    new SqlParameter("@Qty_OK", SqlDbType.Int,4),
                    new SqlParameter("@Qty_NG", SqlDbType.Int,4),
                    new SqlParameter("@Qty_NotInput", SqlDbType.Int,4),
                    new SqlParameter("@GetTime", SqlDbType.Float,8),
                    new SqlParameter("@WorkHours", SqlDbType.Float,8),
                    new SqlParameter("@Efficiency", SqlDbType.Float,8),
                    new SqlParameter("@Wip", SqlDbType.Int,4)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ClientName;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Spec;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.ProcessCount;
            parameters[6].Value = model.ProcessID;
            parameters[7].Value = model.ProcessName;
            parameters[8].Value = model.StandardHours;
            parameters[9].Value = model.ConnectorQty;
            parameters[10].Value = model.ProcessSign;
            parameters[11].Value = model.TotalStandatdHours;
            parameters[12].Value = model.Qty;
            parameters[13].Value = model.Qty_OK;
            parameters[14].Value = model.Qty_NG;
            parameters[15].Value = model.Qty_NotInput;
            parameters[16].Value = model.GetTime;
            parameters[17].Value = model.WorkHours;
            parameters[18].Value = model.Efficiency;
            parameters[19].Value = model.Wip;

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
        public bool Update(MES.Server.Model.BPM_WIP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_WIP set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("ClientName=@ClientName,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("Count=@Count,");
            strSql.Append("ProcessCount=@ProcessCount,");
            strSql.Append("ProcessID=@ProcessID,");
            strSql.Append("ProcessName=@ProcessName,");
            strSql.Append("StandardHours=@StandardHours,");
            strSql.Append("ConnectorQty=@ConnectorQty,");
            strSql.Append("ProcessSign=@ProcessSign,");
            strSql.Append("TotalStandatdHours=@TotalStandatdHours,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("Qty_OK=@Qty_OK,");
            strSql.Append("Qty_NG=@Qty_NG,");
            strSql.Append("Qty_NotInput=@Qty_NotInput,");
            strSql.Append("GetTime=@GetTime,");
            strSql.Append("WorkHours=@WorkHours,");
            strSql.Append("Efficiency=@Efficiency,");
            strSql.Append("Wip=@Wip");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,20),
                    new SqlParameter("@ClientName", SqlDbType.NChar,50),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@Spec", SqlDbType.VarChar,100),
                    new SqlParameter("@Count", SqlDbType.Int,4),
                    new SqlParameter("@ProcessCount", SqlDbType.Int,4),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,20),
                    new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
                    new SqlParameter("@StandardHours", SqlDbType.Float,8),
                    new SqlParameter("@ConnectorQty", SqlDbType.Int,4),
                    new SqlParameter("@ProcessSign", SqlDbType.VarChar,30),
                    new SqlParameter("@TotalStandatdHours", SqlDbType.Float,8),
                    new SqlParameter("@Qty", SqlDbType.Int,4),
                    new SqlParameter("@Qty_OK", SqlDbType.Int,4),
                    new SqlParameter("@Qty_NG", SqlDbType.Int,4),
                    new SqlParameter("@Qty_NotInput", SqlDbType.Int,4),
                    new SqlParameter("@GetTime", SqlDbType.Float,8),
                    new SqlParameter("@WorkHours", SqlDbType.Float,8),
                    new SqlParameter("@Efficiency", SqlDbType.Float,8),
                    new SqlParameter("@Wip", SqlDbType.Int,4),
                    new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ClientName;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Spec;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.ProcessCount;
            parameters[6].Value = model.ProcessID;
            parameters[7].Value = model.ProcessName;
            parameters[8].Value = model.StandardHours;
            parameters[9].Value = model.ConnectorQty;
            parameters[10].Value = model.ProcessSign;
            parameters[11].Value = model.TotalStandatdHours;
            parameters[12].Value = model.Qty;
            parameters[13].Value = model.Qty_OK;
            parameters[14].Value = model.Qty_NG;
            parameters[15].Value = model.Qty_NotInput;
            parameters[16].Value = model.GetTime;
            parameters[17].Value = model.WorkHours;
            parameters[18].Value = model.Efficiency;
            parameters[19].Value = model.Wip;
            parameters[20].Value = model.ID_Key;

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
            strSql.Append("delete from BPM_WIP ");
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
            strSql.Append("delete from BPM_WIP ");
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
        public MES.Server.Model.BPM_WIP GetModel(decimal ID_Key)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,ClientName,ProductName,Spec,Count,ProcessCount,ProcessID,ProcessName,StandardHours,ConnectorQty,ProcessSign,TotalStandatdHours,Qty,Qty_OK,Qty_NG,Qty_NotInput,GetTime,WorkHours,Efficiency,Wip,ID_Key from BPM_WIP ");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID_Key", SqlDbType.Decimal)
            };
            parameters[0].Value = ID_Key;

            MES.Server.Model.BPM_WIP model = new MES.Server.Model.BPM_WIP();
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
        public MES.Server.Model.BPM_WIP DataRowToModel(DataRow row)
        {
            MES.Server.Model.BPM_WIP model = new MES.Server.Model.BPM_WIP();
            if (row != null)
            {
                if (row["OrderID"] != null)
                {
                    model.OrderID = row["OrderID"].ToString();
                }
                if (row["ClientName"] != null)
                {
                    model.ClientName = row["ClientName"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["Count"] != null && row["Count"].ToString() != "")
                {
                    model.Count = int.Parse(row["Count"].ToString());
                }
                if (row["ProcessCount"] != null && row["ProcessCount"].ToString() != "")
                {
                    model.ProcessCount = int.Parse(row["ProcessCount"].ToString());
                }
                if (row["ProcessID"] != null)
                {
                    model.ProcessID = row["ProcessID"].ToString();
                }
                if (row["ProcessName"] != null)
                {
                    model.ProcessName = row["ProcessName"].ToString();
                }
                if (row["StandardHours"] != null && row["StandardHours"].ToString() != "")
                {
                    model.StandardHours = double.Parse(row["StandardHours"].ToString());
                }
                if (row["ConnectorQty"] != null && row["ConnectorQty"].ToString() != "")
                {
                    model.ConnectorQty = int.Parse(row["ConnectorQty"].ToString());
                }
                if (row["ProcessSign"] != null)
                {
                    model.ProcessSign = row["ProcessSign"].ToString();
                }
                if (row["TotalStandatdHours"] != null && row["TotalStandatdHours"].ToString() != "")
                {
                    model.TotalStandatdHours = double.Parse(row["TotalStandatdHours"].ToString());
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = int.Parse(row["Qty"].ToString());
                }
                if (row["Qty_OK"] != null && row["Qty_OK"].ToString() != "")
                {
                    model.Qty_OK = int.Parse(row["Qty_OK"].ToString());
                }
                if (row["Qty_NG"] != null && row["Qty_NG"].ToString() != "")
                {
                    model.Qty_NG = int.Parse(row["Qty_NG"].ToString());
                }
                if (row["Qty_NotInput"] != null && row["Qty_NotInput"].ToString() != "")
                {
                    model.Qty_NotInput = int.Parse(row["Qty_NotInput"].ToString());
                }
                if (row["GetTime"] != null && row["GetTime"].ToString() != "")
                {
                    model.GetTime = double.Parse(row["GetTime"].ToString());
                }
                if (row["WorkHours"] != null && row["WorkHours"].ToString() != "")
                {
                    model.WorkHours = double.Parse(row["WorkHours"].ToString());
                }
                if (row["Efficiency"] != null && row["Efficiency"].ToString() != "")
                {
                    model.Efficiency = double.Parse(row["Efficiency"].ToString());
                }
                if (row["Wip"] != null && row["Wip"].ToString() != "")
                {
                    model.Wip = int.Parse(row["Wip"].ToString());
                }
                if (row["ID_Key"] != null && row["ID_Key"].ToString() != "")
                {
                    model.ID_Key = double.Parse(row["ID_Key"].ToString());
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
            strSql.Append("select OrderID,ClientName,ProductName,Spec,Count,ProcessCount,ProcessID,ProcessName,StandardHours,ConnectorQty,ProcessSign,TotalStandatdHours,Qty,Qty_OK,Qty_NG,Qty_NotInput,GetTime,WorkHours,Efficiency,Wip,ID_Key ");
            strSql.Append(" FROM BPM_WIP ");
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
            strSql.Append(" OrderID,ClientName,ProductName,Spec,Count,ProcessCount,ProcessID,ProcessName,StandardHours,ConnectorQty,ProcessSign,TotalStandatdHours,Qty,Qty_OK,Qty_NG,Qty_NotInput,GetTime,WorkHours,Efficiency,Wip,ID_Key ");
            strSql.Append(" FROM BPM_WIP ");
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
            strSql.Append("select count(1) FROM BPM_WIP ");
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
            strSql.Append(")AS Row, T.*  from BPM_WIP T ");
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
			parameters[0].Value = "BPM_WIP";
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

        /// <summary>
        /// 获得一个实体
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="ProcessID"></param>
        /// <returns></returns>
        public Model.BPM_WIP GetModel(string OrderID, string ProcessID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from BPM_WIP ");
            strSql.Append(" where OrderID='" + OrderID + "' AND ProcessID='" + ProcessID + "'");


            MES.Server.Model.BPM_WIP model = new MES.Server.Model.BPM_WIP();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        ///  qingchu 
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>shandd 
        public bool Delete(string orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_WIP ");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,20)
            };
            parameters[0].Value = orderID;

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

        #endregion  ExtensionMethod



    }
}

