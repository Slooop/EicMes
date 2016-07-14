/* BPM_Product.cs
*
* 功 能： N/A
* 类 名： BPM_Product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:20:19   张文明    初版
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
    /// 数据访问类:BPM_Product
    /// </summary>
    public partial class BPM_Product : IBPM_Product
    {
        public BPM_Product()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BPM_Product");
            strSql.Append(" where ProductID=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ProductID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.BPM_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_Product(");
            strSql.Append("ProductID,Alias,Name,Spec,ConnectorQty,PtID,Pic)");
            strSql.Append(" values (");
            strSql.Append("@ProductID,@Alias,@Name,@Spec,@ConnectorQty,@PtID,@Pic)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50),
					new SqlParameter("@Alias", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@Spec", SqlDbType.VarChar,200),
					new SqlParameter("@ConnectorQty", SqlDbType.Int,4),
					new SqlParameter("@PtID", SqlDbType.VarChar,150),
					new SqlParameter("@Pic", SqlDbType.VarChar,250)};
            parameters[0].Value = model.ProductID;
            parameters[1].Value = model.Alias;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Spec;
            parameters[4].Value = model.ConnectorQty;
            parameters[5].Value = model.PtID;
            parameters[6].Value = model.Pic;

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
        public bool Update(Model.BPM_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_Product set ");
            strSql.Append("Alias=@Alias,");
            strSql.Append("Name=@Name,");
            strSql.Append("Spec=@Spec,");
            strSql.Append("ConnectorQty=@ConnectorQty,");
            strSql.Append("PtID=@PtID,");
            strSql.Append("Pic=@Pic");
            strSql.Append(" where ProductID=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Alias", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@Spec", SqlDbType.VarChar,200),
					new SqlParameter("@ConnectorQty", SqlDbType.Int,4),
					new SqlParameter("@PtID", SqlDbType.VarChar,150),
					new SqlParameter("@Pic", SqlDbType.VarChar,250),
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Alias;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Spec;
            parameters[3].Value = model.ConnectorQty;
            parameters[4].Value = model.PtID;
            parameters[5].Value = model.Pic;
            parameters[6].Value = model.ProductID;

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
        public bool Delete(string ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_Product ");
            strSql.Append(" where ProductID=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ProductID;

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
        public bool DeleteList(string ProductIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BPM_Product ");
            strSql.Append(" where ProductID in (" + ProductIDlist + ")  ");
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
        public Model.BPM_Product GetModel(string ProductID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProductID,Alias,Name,Spec,ConnectorQty,PtID,Pic from BPM_Product ");
            strSql.Append(" where ProductID=@ProductID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.VarChar,50)			};
            parameters[0].Value = ProductID;

            Model.BPM_Product model = new Model.BPM_Product();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                //赋值工序列表
                BPM_ProductTemplate pt = new BPM_ProductTemplate();
                
                model.ProcessList = pt.GetModelList(model.PtID);
                return model;
            }
            else
            {
                return null;
            }
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BPM_Product DataRowToModel(DataRow row)
        {
            Model.BPM_Product model = new Model.BPM_Product();
            if (row != null)
            {
                if (row["ProductID"] != null)
                {
                    model.ProductID = row["ProductID"].ToString();
                }
                if (row["Alias"] != null)
                {
                    model.Alias = row["Alias"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["ConnectorQty"] != null && row["ConnectorQty"].ToString() != "")
                {
                    model.ConnectorQty = int.Parse(row["ConnectorQty"].ToString());
                }
                if (row["PtID"] != null)
                {
                    model.PtID = row["PtID"].ToString();
                }
                if (row["Pic"] != null)
                {
                    model.Pic = row["Pic"].ToString();
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
            strSql.Append("select ProductID,Alias,Name,Spec,ConnectorQty,PtID,Pic ");
            strSql.Append(" FROM BPM_Product ");
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
            strSql.Append(" ProductID,Alias,Name,Spec,ConnectorQty,PtID,Pic ");
            strSql.Append(" FROM BPM_Product ");
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
            strSql.Append("select count(1) FROM BPM_Product ");
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
                strSql.Append("order by T.ProductID desc");
            }
            strSql.Append(")AS Row, T.*  from BPM_Product T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

       

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

