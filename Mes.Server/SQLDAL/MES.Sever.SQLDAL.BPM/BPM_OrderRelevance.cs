/**  版本信息模板在安装目录下，可自行修改。
* BPM_OrderRelevance.cs
*
* 功 能： N/A
* 类 名： BPM_OrderRelevance
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/29 星期四 9:46:35   张文明    初版
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
    /// 数据访问类:BPM_OrderRelevance
    /// </summary>
    public partial class BPM_OrderRelevance : IBPM_OrderRelevance
    {
        public BPM_OrderRelevance()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AdditionalOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BPM_OrderRelevance");
            strSql.Append(" where AdditionalOrder=@AdditionalOrder ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdditionalOrder", SqlDbType.VarChar,20)          };
            parameters[0].Value = AdditionalOrder;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.BPM_OrderRelevance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_OrderRelevance(");
            strSql.Append("MainOrder,AdditionalOrder,ProductName,Spec,Qty)");
            strSql.Append(" values (");
            strSql.Append("@MainOrder,@AdditionalOrder,@ProductName,@Spec,@Qty)");
            SqlParameter[] parameters = {
                    new SqlParameter("@MainOrder", SqlDbType.VarChar,20),
                    new SqlParameter("@AdditionalOrder", SqlDbType.VarChar,20),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@Spec", SqlDbType.VarChar,100),
                    new SqlParameter("@Qty", SqlDbType.Float,8)};
            parameters[0].Value = model.MainOrder;
            parameters[1].Value = model.AdditionalOrder;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Spec;
            parameters[4].Value = model.Qty;

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
        public bool Update(Model.BPM_OrderRelevance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_OrderRelevance set ");
            strSql.Append("MainOrder=@MainOrder,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("Qty=@Qty");
            strSql.Append(" where AdditionalOrder=@AdditionalOrder ");
            SqlParameter[] parameters = {
                    new SqlParameter("@MainOrder", SqlDbType.VarChar,20),
                    new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@Spec", SqlDbType.VarChar,100),
                    new SqlParameter("@Qty", SqlDbType.Float,8),
                    new SqlParameter("@AdditionalOrder", SqlDbType.VarChar,20)};
            parameters[0].Value = model.MainOrder;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.Spec;
            parameters[3].Value = model.Qty;
            parameters[4].Value = model.AdditionalOrder;

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
        public bool Delete(string AdditionalOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_OrderRelevance ");
            strSql.Append(" where AdditionalOrder=@AdditionalOrder ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdditionalOrder", SqlDbType.VarChar,20)          };
            parameters[0].Value = AdditionalOrder;

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
        public bool DeleteList(string AdditionalOrderlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_OrderRelevance ");
            strSql.Append(" where AdditionalOrder in (" + AdditionalOrderlist + ")  ");
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
        public Model.BPM_OrderRelevance GetModel(string AdditionalOrder)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MainOrder,AdditionalOrder,ProductName,Spec,Qty from BPM_OrderRelevance ");
            strSql.Append(" where AdditionalOrder=@AdditionalOrder ");
            SqlParameter[] parameters = {
                    new SqlParameter("@AdditionalOrder", SqlDbType.VarChar,20)          };
            parameters[0].Value = AdditionalOrder;

            Model.BPM_OrderRelevance model = new Model.BPM_OrderRelevance();
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
        public Model.BPM_OrderRelevance DataRowToModel(DataRow row)
        {
            Model.BPM_OrderRelevance model = new Model.BPM_OrderRelevance();
            if (row != null)
            {
                if (row["MainOrder"] != null)
                {
                    model.MainOrder = row["MainOrder"].ToString();
                }
                if (row["AdditionalOrder"] != null)
                {
                    model.AdditionalOrder = row["AdditionalOrder"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
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
            strSql.Append("select MainOrder,AdditionalOrder,ProductName,Spec,Qty ");
            strSql.Append(" FROM BPM_OrderRelevance ");
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
            strSql.Append(" MainOrder,AdditionalOrder,ProductName,Spec,Qty ");
            strSql.Append(" FROM BPM_OrderRelevance ");
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
            strSql.Append("select count(1) FROM BPM_OrderRelevance ");
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
                strSql.Append("order by T.AdditionalOrder desc");
            }
            strSql.Append(")AS Row, T.*  from BPM_OrderRelevance T ");
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
			parameters[0].Value = "BPM_OrderRelevance";
			parameters[1].Value = "AdditionalOrder";
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

