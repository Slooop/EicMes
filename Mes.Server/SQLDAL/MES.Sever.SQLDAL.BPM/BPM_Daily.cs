/**  版本信息模板在安装目录下，可自行修改。
* BPM_Daily.cs
*
* 功 能： N/A
* 类 名： BPM_Daily
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/29 星期二 16:05:19   张文明    初版
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
    /// 数据访问类:BPM_Daily
    /// </summary>
    public partial class BPM_Daily : IBPM_Daily
    {
        public BPM_Daily()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ID_Key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BPM_Daily");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID_Key", SqlDbType.Decimal)
            };
            parameters[0].Value = ID_Key;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(MES.Server.Model.BPM_Daily model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_Daily(");
            strSql.Append("OrderID,ClientName,ProductID,ProductName,Spec,OrderCount,State,ActualEndDate,DailyNum,Department,WorkShop,Workstation,ClassType,JobNum,Name,Month,Date,DateTime,ProcessNum,ProcessID,ProcessName,ProcessSign,StandardHours,WorkHours,TotalWorkHoursNotRelax,TotalWorkHoursStandard,TotalWorkHoursPmc,NotWorkHours,NotWorkCause,Qty,QtyOK,QtyNG,Efficiency,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@ClientName,@ProductID,@ProductName,@Spec,@OrderCount,@State,@ActualEndDate,@DailyNum,@Department,@WorkShop,@Workstation,@ClassType,@JobNum,@Name,@Month,@Date,@DateTime,@ProcessNum,@ProcessID,@ProcessName,@ProcessSign,@StandardHours,@WorkHours,@TotalWorkHoursNotRelax,@TotalWorkHoursStandard,@TotalWorkHoursPmc,@NotWorkHours,@NotWorkCause,@Qty,@QtyOK,@QtyNG,@Efficiency,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,50),
                    new SqlParameter("@ClientName", SqlDbType.VarChar,50),
                    new SqlParameter("@ProductID", SqlDbType.VarChar,150),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,150),
                    new SqlParameter("@Spec", SqlDbType.VarChar,150),
                    new SqlParameter("@OrderCount", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.VarChar,150),
                    new SqlParameter("@ActualEndDate", SqlDbType.Char,8),
                    new SqlParameter("@DailyNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Department", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@Workstation", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassType", SqlDbType.VarChar,50),
                    new SqlParameter("@JobNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Name", SqlDbType.VarChar,50),
                    new SqlParameter("@Month", SqlDbType.VarChar,50),
                    new SqlParameter("@Date", SqlDbType.DateTime),
                    new SqlParameter("@DateTime", SqlDbType.DateTime),
                    new SqlParameter("@ProcessNum", SqlDbType.Int,4),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
                    new SqlParameter("@ProcessName", SqlDbType.VarChar,200),
                    new SqlParameter("@ProcessSign", SqlDbType.VarChar,100),
                    new SqlParameter("@StandardHours", SqlDbType.Decimal,9),
                    new SqlParameter("@WorkHours", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursNotRelax", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursStandard", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursPmc", SqlDbType.Float,8),
                    new SqlParameter("@NotWorkHours", SqlDbType.Float,8),
                    new SqlParameter("@NotWorkCause", SqlDbType.NVarChar,100),
                    new SqlParameter("@Qty", SqlDbType.Int,4),
                    new SqlParameter("@QtyOK", SqlDbType.Int,4),
                    new SqlParameter("@QtyNG", SqlDbType.Int,4),
                    new SqlParameter("@Efficiency", SqlDbType.Float,8),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ClientName;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.Spec;
            parameters[5].Value = model.OrderCount;
            parameters[6].Value = model.State;
            parameters[7].Value = model.ActualEndDate;
            parameters[8].Value = model.DailyNum;
            parameters[9].Value = model.Department;
            parameters[10].Value = model.WorkShop;
            parameters[11].Value = model.Workstation;
            parameters[12].Value = model.ClassType;
            parameters[13].Value = model.JobNum;
            parameters[14].Value = model.Name;
            parameters[15].Value = model.Month;
            parameters[16].Value = model.Date;
            parameters[17].Value = model.DateTime;
            parameters[18].Value = model.ProcessNum;
            parameters[19].Value = model.ProcessID;
            parameters[20].Value = model.ProcessName;
            parameters[21].Value = model.ProcessSign;
            parameters[22].Value = model.StandardHours;
            parameters[23].Value = model.WorkHours;
            parameters[24].Value = model.TotalWorkHoursNotRelax;
            parameters[25].Value = model.TotalWorkHoursStandard;
            parameters[26].Value = model.TotalWorkHoursPmc;
            parameters[27].Value = model.NotWorkHours;
            parameters[28].Value = model.NotWorkCause;
            parameters[29].Value = model.Qty;
            parameters[30].Value = model.QtyOK;
            parameters[31].Value = model.QtyNG;
            parameters[32].Value = model.Efficiency;
            parameters[33].Value = model.Remarks;

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
        public bool Update(MES.Server.Model.BPM_Daily model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_Daily set ");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("ClientName=@ClientName,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("OrderCount=@OrderCount,");
            strSql.Append("State=@State,");
            strSql.Append("ActualEndDate=@ActualEndDate,");
            strSql.Append("DailyNum=@DailyNum,");
            strSql.Append("Department=@Department,");
            strSql.Append("WorkShop=@WorkShop,");
            strSql.Append("Workstation=@Workstation,");
            strSql.Append("ClassType=@ClassType,");
            strSql.Append("JobNum=@JobNum,");
            strSql.Append("Name=@Name,");
            strSql.Append("Month=@Month,");
            strSql.Append("Date=@Date,");
            strSql.Append("DateTime=@DateTime,");
            strSql.Append("ProcessNum=@ProcessNum,");
            strSql.Append("ProcessID=@ProcessID,");
            strSql.Append("ProcessName=@ProcessName,");
            strSql.Append("ProcessSign=@ProcessSign,");
            strSql.Append("StandardHours=@StandardHours,");
            strSql.Append("WorkHours=@WorkHours,");
            strSql.Append("TotalWorkHoursNotRelax=@TotalWorkHoursNotRelax,");
            strSql.Append("TotalWorkHoursStandard=@TotalWorkHoursStandard,");
            strSql.Append("TotalWorkHoursPmc=@TotalWorkHoursPmc,");
            strSql.Append("NotWorkHours=@NotWorkHours,");
            strSql.Append("NotWorkCause=@NotWorkCause,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("QtyOK=@QtyOK,");
            strSql.Append("QtyNG=@QtyNG,");
            strSql.Append("Efficiency=@Efficiency,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,50),
                    new SqlParameter("@ClientName", SqlDbType.VarChar,50),
                    new SqlParameter("@ProductID", SqlDbType.VarChar,150),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,150),
                    new SqlParameter("@Spec", SqlDbType.VarChar,150),
                    new SqlParameter("@OrderCount", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.VarChar,150),
                    new SqlParameter("@ActualEndDate", SqlDbType.Char,8),
                    new SqlParameter("@DailyNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Department", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@Workstation", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassType", SqlDbType.VarChar,50),
                    new SqlParameter("@JobNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Name", SqlDbType.VarChar,50),
                    new SqlParameter("@Month", SqlDbType.VarChar,50),
                    new SqlParameter("@Date", SqlDbType.DateTime),
                    new SqlParameter("@DateTime", SqlDbType.DateTime),
                    new SqlParameter("@ProcessNum", SqlDbType.Int,4),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,50),
                    new SqlParameter("@ProcessName", SqlDbType.VarChar,200),
                    new SqlParameter("@ProcessSign", SqlDbType.VarChar,100),
                    new SqlParameter("@StandardHours", SqlDbType.Decimal,9),
                    new SqlParameter("@WorkHours", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursNotRelax", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursStandard", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursPmc", SqlDbType.Float,8),
                    new SqlParameter("@NotWorkHours", SqlDbType.Float,8),
                    new SqlParameter("@NotWorkCause", SqlDbType.NVarChar,100),
                    new SqlParameter("@Qty", SqlDbType.Int,4),
                    new SqlParameter("@QtyOK", SqlDbType.Int,4),
                    new SqlParameter("@QtyNG", SqlDbType.Int,4),
                    new SqlParameter("@Efficiency", SqlDbType.Float,8),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,100),
                    new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ClientName;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.Spec;
            parameters[5].Value = model.OrderCount;
            parameters[6].Value = model.State;
            parameters[7].Value = model.ActualEndDate;
            parameters[8].Value = model.DailyNum;
            parameters[9].Value = model.Department;
            parameters[10].Value = model.WorkShop;
            parameters[11].Value = model.Workstation;
            parameters[12].Value = model.ClassType;
            parameters[13].Value = model.JobNum;
            parameters[14].Value = model.Name;
            parameters[15].Value = model.Month;
            parameters[16].Value = model.Date;
            parameters[17].Value = model.DateTime;
            parameters[18].Value = model.ProcessNum;
            parameters[19].Value = model.ProcessID;
            parameters[20].Value = model.ProcessName;
            parameters[21].Value = model.ProcessSign;
            parameters[22].Value = model.StandardHours;
            parameters[23].Value = model.WorkHours;
            parameters[24].Value = model.TotalWorkHoursNotRelax;
            parameters[25].Value = model.TotalWorkHoursStandard;
            parameters[26].Value = model.TotalWorkHoursPmc;
            parameters[27].Value = model.NotWorkHours;
            parameters[28].Value = model.NotWorkCause;
            parameters[29].Value = model.Qty;
            parameters[30].Value = model.QtyOK;
            parameters[31].Value = model.QtyNG;
            parameters[32].Value = model.Efficiency;
            parameters[33].Value = model.Remarks;
            parameters[34].Value = model.ID_Key;

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
            strSql.Append("delete from BPM_Daily ");
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
            strSql.Append("delete from BPM_Daily ");
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
        public MES.Server.Model.BPM_Daily GetModel(decimal ID_Key)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,ClientName,ProductID,ProductName,Spec,OrderCount,State,ActualEndDate,DailyNum,Department,WorkShop,Workstation,ClassType,JobNum,Name,Month,Date,DateTime,ProcessNum,ProcessID,ProcessName,ProcessSign,StandardHours,WorkHours,TotalWorkHoursNotRelax,TotalWorkHoursStandard,TotalWorkHoursPmc,NotWorkHours,NotWorkCause,Qty,QtyOK,QtyNG,Efficiency,Remarks,ID_Key from BPM_Daily ");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID_Key", SqlDbType.Decimal)
            };
            parameters[0].Value = ID_Key;

            MES.Server.Model.BPM_Daily model = new MES.Server.Model.BPM_Daily();
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
        public MES.Server.Model.BPM_Daily DataRowToModel(DataRow row)
        {
            MES.Server.Model.BPM_Daily model = new MES.Server.Model.BPM_Daily();
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
                if (row["ProductID"] != null)
                {
                    model.ProductID = row["ProductID"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["OrderCount"] != null && row["OrderCount"].ToString() != "")
                {
                    model.OrderCount = int.Parse(row["OrderCount"].ToString());
                }
                if (row["State"] != null)
                {
                    model.State = row["State"].ToString();
                }
                if (row["ActualEndDate"] != null)
                {
                    model.ActualEndDate = row["ActualEndDate"].ToString();
                }
                if (row["DailyNum"] != null)
                {
                    model.DailyNum = row["DailyNum"].ToString();
                }
                if (row["Department"] != null)
                {
                    model.Department = row["Department"].ToString();
                }
                if (row["WorkShop"] != null)
                {
                    model.WorkShop = row["WorkShop"].ToString();
                }
                if (row["Workstation"] != null)
                {
                    model.Workstation = row["Workstation"].ToString();
                }
                if (row["ClassType"] != null)
                {
                    model.ClassType = row["ClassType"].ToString();
                }
                if (row["JobNum"] != null)
                {
                    model.JobNum = row["JobNum"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Month"] != null)
                {
                    model.Month = row["Month"].ToString();
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["DateTime"] != null && row["DateTime"].ToString() != "")
                {
                    model.DateTime = DateTime.Parse(row["DateTime"].ToString());
                }
                if (row["ProcessNum"] != null && row["ProcessNum"].ToString() != "")
                {
                    model.ProcessNum = int.Parse(row["ProcessNum"].ToString());
                }
                if (row["ProcessID"] != null)
                {
                    model.ProcessID = row["ProcessID"].ToString();
                }
                if (row["ProcessName"] != null)
                {
                    model.ProcessName = row["ProcessName"].ToString();
                }
                if (row["ProcessSign"] != null)
                {
                    model.ProcessSign = row["ProcessSign"].ToString();
                }
                if (row["StandardHours"] != null && row["StandardHours"].ToString() != "")
                {
                    model.StandardHours = decimal.Parse(row["StandardHours"].ToString());
                }
                if (row["WorkHours"] != null && row["WorkHours"].ToString() != "")
                {
                    model.WorkHours = decimal.Parse(row["WorkHours"].ToString());
                }
                if (row["TotalWorkHoursNotRelax"] != null && row["TotalWorkHoursNotRelax"].ToString() != "")
                {
                    model.TotalWorkHoursNotRelax = decimal.Parse(row["TotalWorkHoursNotRelax"].ToString());
                }
                if (row["TotalWorkHoursStandard"] != null && row["TotalWorkHoursStandard"].ToString() != "")
                {
                    model.TotalWorkHoursStandard = decimal.Parse(row["TotalWorkHoursStandard"].ToString());
                }
                if (row["TotalWorkHoursPmc"] != null && row["TotalWorkHoursPmc"].ToString() != "")
                {
                    model.TotalWorkHoursPmc = decimal.Parse(row["TotalWorkHoursPmc"].ToString());
                }
                if (row["NotWorkHours"] != null && row["NotWorkHours"].ToString() != "")
                {
                    model.NotWorkHours = decimal.Parse(row["NotWorkHours"].ToString());
                }
                if (row["NotWorkCause"] != null)
                {
                    model.NotWorkCause = row["NotWorkCause"].ToString();
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = int.Parse(row["Qty"].ToString());
                }
                if (row["QtyOK"] != null && row["QtyOK"].ToString() != "")
                {
                    model.QtyOK = int.Parse(row["QtyOK"].ToString());
                }
                if (row["QtyNG"] != null && row["QtyNG"].ToString() != "")
                {
                    model.QtyNG = int.Parse(row["QtyNG"].ToString());
                }
                if (row["Efficiency"] != null && row["Efficiency"].ToString() != "")
                {
                    model.Efficiency = double.Parse(row["Efficiency"].ToString());
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
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
            strSql.Append("select OrderID,ClientName,ProductID,ProductName,Spec,OrderCount,State,ActualEndDate,DailyNum,Department,WorkShop,Workstation,ClassType,JobNum,Name,Month,Date,DateTime,ProcessNum,ProcessID,ProcessName,ProcessSign,StandardHours,WorkHours,TotalWorkHoursNotRelax,TotalWorkHoursStandard,TotalWorkHoursPmc,NotWorkHours,NotWorkCause,Qty,QtyOK,QtyNG,Efficiency,Remarks,ID_Key ");
            strSql.Append(" FROM BPM_Daily ");
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
            strSql.Append(" OrderID,ClientName,ProductID,ProductName,Spec,OrderCount,State,ActualEndDate,DailyNum,Department,WorkShop,Workstation,ClassType,JobNum,Name,Month,Date,DateTime,ProcessNum,ProcessID,ProcessName,ProcessSign,StandardHours,WorkHours,TotalWorkHoursNotRelax,TotalWorkHoursStandard,TotalWorkHoursPmc,NotWorkHours,NotWorkCause,Qty,QtyOK,QtyNG,Efficiency,Remarks,ID_Key ");
            strSql.Append(" FROM BPM_Daily ");
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
            strSql.Append("select count(1) FROM BPM_Daily ");
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
            strSql.Append(")AS Row, T.*  from BPM_Daily T ");
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
			parameters[0].Value = "BPM_Daily";
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
        /// 更新工单状态
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool UpdateOrderState(Model.BPM_Order order)
        {
            string sql = "UPDATE BPM_Daily SET State = '" + order.State + "', ActualEndDate = '" + order.ActualEndDate + "' WHERE(OrderID = '" + order.OrderID + "')";
            int rows = DbHelperSQL.ExecuteSql(sql);
            return rows > 0 ? true : false;
        }
        #endregion  ExtensionMethod	
    }
}
