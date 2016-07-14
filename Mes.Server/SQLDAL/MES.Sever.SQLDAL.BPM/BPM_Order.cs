using MES.Server.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MES.Server.SQLServerDAL
{
    public partial class BPM_Order : IDAL.IBPM_Order
    {
        DbHelperSQLP ligMat = new DbHelperSQLP(PubConnection.lig);


        #region Order_ERPdb
        /*
        /// <summary>
        /// 获取一个工单
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <returns></returns>
        public Model.BPM_Order GetModel_ERP(string orderID)
        {
            if (orderID.Length > 10)
            {
                string _orderTyep = orderID.Substring(0, 3);
                string _orderid = orderID.Substring(4, 7);
                DataSet ds = ligMat.Query("select TA001,TA002,TA006 AS 品号,TA028,TA034 AS 品名,TA035 AS 规格,TA015 AS 批量,TA026,TA009 AS 开工日期,TA010 AS 完工日期,TA029,TA026,TA027 from MOCTA where TA001='" + _orderTyep + "' and TA002='" + _orderid + "'");
                return DataSetToModel_ERP(ds);
            }
            else return null;
        }

        /// <summary>
        /// DataSet转Model
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public Model.BPM_Order DataSetToModel_ERP(DataSet ds)
        {
            if(ds.Tables[0].Rows.Count>0)
            {
                Model.BPM_Order order = new Model.BPM_Order()
                {
                    ProductID = ds.Tables[0].Rows[0]["品号"].ToString(),
                    ProductName = ds.Tables[0].Rows[0]["品名"].ToString(),
                    Spec = ds.Tables[0].Rows[0]["规格"].ToString(),
                    Count = double.Parse( ds.Tables[0].Rows[0]["批量"].ToString()),
                    StartDate = ds.Tables[0].Rows[0]["开工日期"].ToString(),
                    EndDate =  ds.Tables[0].Rows[0]["完工日期"].ToString(),
                };
                BPM_Product product = new BPM_Product();
                order.Product = product.GetModel(order.ProductID);  //产品信息
                return order;
            }
            else { return null; }
        }
    */
        #endregion


        #region  Order_MESdb

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BPM_Order");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
            parameters[0].Value = OrderID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MES.Server.Model.BPM_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_Order(");
            strSql.Append("OrderID,ClientName,ProductID,ProductName,Spec,Count,TotalWorkHoursStandard,StartDate,EndDate,ActualStartDate,ActualEndDate,DeliveryDate,Qty,PN,PO,WorkDepartment,WorkShop,State,Relax,IsRemind)");
            strSql.Append(" values (");
            strSql.Append("@OrderID,@ClientName,@ProductID,@ProductName,@Spec,@Count,@TotalWorkHoursStandard,@StartDate,@EndDate,@ActualStartDate,@ActualEndDate,@DeliveryDate,@Qty,@PN,@PO,@WorkDepartment,@WorkShop,@State,@Relax,@IsRemind)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,50),
                    new SqlParameter("@ClientName", SqlDbType.VarChar,50),
                    new SqlParameter("@ProductID", SqlDbType.VarChar,50),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@Spec", SqlDbType.VarChar,300),
                    new SqlParameter("@Count", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursStandard", SqlDbType.Float,8),
                    new SqlParameter("@StartDate", SqlDbType.VarChar,50),
                    new SqlParameter("@EndDate", SqlDbType.VarChar,50),
                    new SqlParameter("@ActualStartDate", SqlDbType.Char,8),
                    new SqlParameter("@ActualEndDate", SqlDbType.Char,8),
                    new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
                    new SqlParameter("@Qty", SqlDbType.VarChar,50),
                    new SqlParameter("@PN", SqlDbType.VarChar,50),
                    new SqlParameter("@PO", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkDepartment", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@State", SqlDbType.VarChar,50),
                    new SqlParameter("@Relax", SqlDbType.Decimal,9),
                    new SqlParameter("@IsRemind", SqlDbType.Bit,1)};
            parameters[0].Value = model.OrderID;
            parameters[1].Value = model.ClientName;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.Spec;
            parameters[5].Value = model.Count;
            parameters[6].Value = model.TotalWorkHoursStandard;
            parameters[7].Value = model.StartDate;
            parameters[8].Value = model.EndDate;
            parameters[9].Value = model.ActualStartDate;
            parameters[10].Value = model.ActualEndDate;
            parameters[11].Value = model.DeliveryDate;
            parameters[12].Value = model.Qty;
            parameters[13].Value = model.PN;
            parameters[14].Value = model.PO;
            parameters[15].Value = model.WorkDepartment;
            parameters[16].Value = model.WorkShop;
            parameters[17].Value = model.State;
            parameters[18].Value = model.Relax;
            parameters[19].Value = model.IsRemind;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MES.Server.Model.BPM_Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_Order set ");
            strSql.Append("ClientName=@ClientName,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("Count=@Count,");
            strSql.Append("TotalWorkHoursStandard=@TotalWorkHoursStandard,");
            strSql.Append("StartDate=@StartDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("ActualStartDate=@ActualStartDate,");
            strSql.Append("ActualEndDate=@ActualEndDate,");
            strSql.Append("DeliveryDate=@DeliveryDate,");
            strSql.Append("Qty=@Qty,");
            strSql.Append("PN=@PN,");
            strSql.Append("PO=@PO,");
            strSql.Append("WorkDepartment=@WorkDepartment,");
            strSql.Append("WorkShop=@WorkShop,");
            strSql.Append("State=@State,");
            strSql.Append("Relax=@Relax,");
            strSql.Append("IsRemind=@IsRemind");
            strSql.Append(" where OrderID=@OrderID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ClientName", SqlDbType.VarChar,50),
                    new SqlParameter("@ProductID", SqlDbType.VarChar,50),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@Spec", SqlDbType.VarChar,300),
                    new SqlParameter("@Count", SqlDbType.Float,8),
                    new SqlParameter("@TotalWorkHoursStandard", SqlDbType.Float,8),
                    new SqlParameter("@StartDate", SqlDbType.VarChar,50),
                    new SqlParameter("@EndDate", SqlDbType.VarChar,50),
                    new SqlParameter("@ActualStartDate", SqlDbType.Char,8),
                    new SqlParameter("@ActualEndDate", SqlDbType.Char,8),
                    new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
                    new SqlParameter("@Qty", SqlDbType.VarChar,50),
                    new SqlParameter("@PN", SqlDbType.VarChar,50),
                    new SqlParameter("@PO", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkDepartment", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@State", SqlDbType.VarChar,50),
                    new SqlParameter("@Relax", SqlDbType.Decimal,9),
                    new SqlParameter("@IsRemind", SqlDbType.Bit,1),
                    new SqlParameter("@OrderID", SqlDbType.VarChar,50),
                    new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ClientName;
            parameters[1].Value = model.ProductID;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Spec;
            parameters[4].Value = model.Count;
            parameters[5].Value = model.TotalWorkHoursStandard;
            parameters[6].Value = model.StartDate;
            parameters[7].Value = model.EndDate;
            parameters[8].Value = model.ActualStartDate;
            parameters[9].Value = model.ActualEndDate;
            parameters[10].Value = model.DeliveryDate;
            parameters[11].Value = model.Qty;
            parameters[12].Value = model.PN;
            parameters[13].Value = model.PO;
            parameters[14].Value = model.WorkDepartment;
            parameters[15].Value = model.WorkShop;
            parameters[16].Value = model.State;
            parameters[17].Value = model.Relax;
            parameters[18].Value = model.IsRemind;
            parameters[19].Value = model.OrderID;
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
        public bool Delete(string OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_Order ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
            parameters[0].Value = OrderID;

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
        public bool DeleteList(string OrderIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_Order ");
            strSql.Append(" where OrderID in (" + OrderIDlist + ")  ");
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
        public Model.BPM_Order GetModel(string OrderID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BPM_Order ");
            strSql.Append(" where OrderID=@OrderID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)			};
            parameters[0].Value = OrderID;

            Model.BPM_Order model = new Model.BPM_Order();
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
        public Model.BPM_Order DataRowToModel(DataRow row)
        {
            MES.Server.Model.BPM_Order model = new MES.Server.Model.BPM_Order();
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
                if (row["Count"] != null && row["Count"].ToString() != "")
                {
                    model.Count = double.Parse(row["Count"].ToString());
                }
                if (row["TotalWorkHoursStandard"] != null && row["TotalWorkHoursStandard"].ToString() != "")
                {
                    model.TotalWorkHoursStandard = double.Parse(row["TotalWorkHoursStandard"].ToString());
                }
                if (row["StartDate"] != null)
                {
                    model.StartDate = row["StartDate"].ToString();
                }
                if (row["EndDate"] != null)
                {
                    model.EndDate = row["EndDate"].ToString();
                }
                if (row["ActualStartDate"] != null)
                {
                    model.ActualStartDate = row["ActualStartDate"].ToString();
                }
                if (row["ActualEndDate"] != null)
                {
                    model.ActualEndDate = row["ActualEndDate"].ToString();
                }
                if (row["DeliveryDate"] != null && row["DeliveryDate"].ToString() != "")
                {
                    model.DeliveryDate = DateTime.Parse(row["DeliveryDate"].ToString());
                }
                if (row["Qty"] != null)
                {
                    model.Qty = row["Qty"].ToString();
                }
                if (row["PN"] != null)
                {
                    model.PN = row["PN"].ToString();
                }
                if (row["PO"] != null)
                {
                    model.PO = row["PO"].ToString();
                }
                if (row["WorkDepartment"] != null)
                {
                    model.WorkDepartment = row["WorkDepartment"].ToString();
                }
                if (row["WorkShop"] != null)
                {
                    model.WorkShop = row["WorkShop"].ToString();
                }
                if (row["State"] != null)
                {
                    model.State = row["State"].ToString();
                }
                if (row["Relax"] != null && row["Relax"].ToString() != "")
                {
                    model.Relax = double.Parse(row["Relax"].ToString());
                }
                if (row["IsRemind"] != null && row["IsRemind"].ToString() != "")
                {
                    if ((row["IsRemind"].ToString() == "1") || (row["IsRemind"].ToString().ToLower() == "true"))
                    {
                        model.IsRemind = true;
                    }
                    else
                    {
                        model.IsRemind = false;
                    }
                }
                if (row["ID_Key"] != null && row["ID_Key"].ToString() != "")
                {
                    model.ID_Key = decimal.Parse(row["ID_Key"].ToString());
                }
            }
            BPM_Product product = new BPM_Product();
            model.Product = product.GetModel(model.ProductID);  //产品信息
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BPM_Order ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM BPM_Order ");
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
            strSql.Append("select count(1) FROM BPM_Order ");
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
                strSql.Append("order by T.OrderID desc");
            }
            strSql.Append(")AS Row, T.*  from BPM_Order T ");
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
            parameters[0].Value = "BPM_Order";
            parameters[1].Value = "OrderID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        #endregion  BasicMethod
    }
}
