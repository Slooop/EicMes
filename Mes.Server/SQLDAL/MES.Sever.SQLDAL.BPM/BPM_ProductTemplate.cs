/* BPM_ProductTemplate.cs
*
* 功 能： N/A
* 类 名： BPM_ProductTemplate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/18 18:56:04   张文明    初版
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
using MES.Server.DBUtility;
using System.Collections.ObjectModel;//Please add references
namespace MES.Server.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BPM_ProductTemplate
	/// </summary>
	public partial class BPM_ProductTemplate:IBPM_ProductTemplate
	{
		public BPM_ProductTemplate()
		{ }
		
        #region  BasicMethod


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ObservableCollection<Model.BPM_ProductTemplate> GetModelList(string ptID)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  * from BPM_ProductTemplate ");
			strSql.Append(" where PtID=@PtID");
			SqlParameter[] parameters = {
					new SqlParameter("@PtID", SqlDbType.VarChar,100)};
			parameters[0].Value = ptID;
            Model.BPM_ProductTemplate model = new Model.BPM_ProductTemplate();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ObservableCollection<Model.BPM_ProductTemplate> tem =
                new ObservableCollection<Model.BPM_ProductTemplate>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    tem.Add(DataRowToModel(dr));
                }
                return tem;
            }
            else { return null; }
		}



		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PtID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from BPM_ProductTemplate");
			strSql.Append(" where PtID=@PtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PtID", SqlDbType.VarChar,100)			};
			parameters[0].Value = PtID;

			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(MES.Server.Model.BPM_ProductTemplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BPM_ProductTemplate(");
            strSql.Append("Department,WorkShop,PtID,Alias,Name,Num,ProcessID,ProcessName,ProcessSign,IsCheckTotalCount,OnceQty,StandardHours,ConnectorQty,TL,IsVital,IsControl,ReWorkProcess)");
            strSql.Append(" values (");
            strSql.Append("@Department,@WorkShop,@PtID,@Alias,@Name,@Num,@ProcessID,@ProcessName,@ProcessSign,@IsCheckTotalCount,@OnceQty,@StandardHours,@ConnectorQty,@TL,@IsVital,@IsControl,@ReWorkProcess)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Department", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@PtID", SqlDbType.VarChar,100),
                    new SqlParameter("@Alias", SqlDbType.VarChar,100),
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Num", SqlDbType.Int,4),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,100),
                    new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
                    new SqlParameter("@ProcessSign", SqlDbType.VarChar,100),
                    new SqlParameter("@IsCheckTotalCount", SqlDbType.Bit,1),
                    new SqlParameter("@OnceQty", SqlDbType.Int,4),
                    new SqlParameter("@StandardHours", SqlDbType.Decimal,9),
                    new SqlParameter("@ConnectorQty", SqlDbType.Int,4),
                    new SqlParameter("@TL", SqlDbType.Decimal,9),
                    new SqlParameter("@IsVital", SqlDbType.VarChar,10),
                    new SqlParameter("@IsControl", SqlDbType.VarChar,10),
                    new SqlParameter("@ReWorkProcess", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.Department;
            parameters[1].Value = model.WorkShop;
            parameters[2].Value = model.PtID;
            parameters[3].Value = model.Alias;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Num;
            parameters[6].Value = model.ProcessID;
            parameters[7].Value = model.ProcessName;
            parameters[8].Value = model.ProcessSign;
            parameters[9].Value = model.IsCheckTotalCount;
            parameters[10].Value = model.OnceQty;
            parameters[11].Value = model.StandardHours;
            parameters[12].Value = model.ConnectorQty;
            parameters[13].Value = model.TL;
            parameters[14].Value = model.IsVital;
            parameters[15].Value = model.IsControl;
            parameters[16].Value = model.ReWorkProcess;

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
        public bool Update(MES.Server.Model.BPM_ProductTemplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BPM_ProductTemplate set ");
            strSql.Append("Department=@Department,");
            strSql.Append("WorkShop=@WorkShop,");
            strSql.Append("PtID=@PtID,");
            strSql.Append("Alias=@Alias,");
            strSql.Append("Name=@Name,");
            strSql.Append("Num=@Num,");
            strSql.Append("ProcessID=@ProcessID,");
            strSql.Append("ProcessName=@ProcessName,");
            strSql.Append("ProcessSign=@ProcessSign,");
            strSql.Append("IsCheckTotalCount=@IsCheckTotalCount,");
            strSql.Append("OnceQty=@OnceQty,");
            strSql.Append("StandardHours=@StandardHours,");
            strSql.Append("ConnectorQty=@ConnectorQty,");
            strSql.Append("TL=@TL,");
            strSql.Append("IsVital=@IsVital,");
            strSql.Append("IsControl=@IsControl,");
            strSql.Append("ReWorkProcess=@ReWorkProcess");
            strSql.Append(" where ID_Key=@ID_Key");
            SqlParameter[] parameters = {
                    new SqlParameter("@Department", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkShop", SqlDbType.VarChar,50),
                    new SqlParameter("@PtID", SqlDbType.VarChar,100),
                    new SqlParameter("@Alias", SqlDbType.VarChar,100),
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@Num", SqlDbType.Int,4),
                    new SqlParameter("@ProcessID", SqlDbType.VarChar,100),
                    new SqlParameter("@ProcessName", SqlDbType.VarChar,100),
                    new SqlParameter("@ProcessSign", SqlDbType.VarChar,100),
                    new SqlParameter("@IsCheckTotalCount", SqlDbType.Bit,1),
                    new SqlParameter("@OnceQty", SqlDbType.Int,4),
                    new SqlParameter("@StandardHours", SqlDbType.Decimal,9),
                    new SqlParameter("@ConnectorQty", SqlDbType.Int,4),
                    new SqlParameter("@TL", SqlDbType.Decimal,9),
                    new SqlParameter("@IsVital", SqlDbType.VarChar,10),
                    new SqlParameter("@IsControl", SqlDbType.VarChar,10),
                    new SqlParameter("@ReWorkProcess", SqlDbType.VarChar,1000),
                    new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
            parameters[0].Value = model.Department;
            parameters[1].Value = model.WorkShop;
            parameters[2].Value = model.PtID;
            parameters[3].Value = model.Alias;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Num;
            parameters[6].Value = model.ProcessID;
            parameters[7].Value = model.ProcessName;
            parameters[8].Value = model.ProcessSign;
            parameters[9].Value = model.IsCheckTotalCount;
            parameters[10].Value = model.OnceQty;
            parameters[11].Value = model.StandardHours;
            parameters[12].Value = model.ConnectorQty;
            parameters[13].Value = model.TL;
            parameters[14].Value = model.IsVital;
            parameters[15].Value = model.IsControl;
            parameters[16].Value = model.ReWorkProcess;
            parameters[17].Value = model.ID_Key;

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
			strSql.Append("delete from BPM_ProductTemplate ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PtID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from BPM_ProductTemplate ");
			strSql.Append(" where PtID=@PtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PtID", SqlDbType.VarChar,100)			};
			parameters[0].Value = PtID;

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
			strSql.Append("delete from BPM_ProductTemplate ");
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


		public Model.BPM_ProductTemplate GetModel(string ptID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 * from BPM_ProductTemplate ");
			strSql.Append(" where PtID=@PtID");
			SqlParameter[] parameters = {
					new SqlParameter("@PtID", SqlDbType.VarChar,100)
			};
			parameters[0].Value = ptID;

            Model.BPM_ProductTemplate model = new Model.BPM_ProductTemplate();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
				return DataRowToModel(ds.Tables[0].Rows[0]);
			else
				return null;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.BPM_ProductTemplate GetModel(decimal ID_Key)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 * from BPM_ProductTemplate ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

            Model.BPM_ProductTemplate model = new Model.BPM_ProductTemplate();
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
		public MES.Server.Model.BPM_ProductTemplate DataRowToModel(DataRow row)
        {
            MES.Server.Model.BPM_ProductTemplate model = new MES.Server.Model.BPM_ProductTemplate();
            if (row != null)
            {
                if (row["Department"] != null)
                {
                    model.Department = row["Department"].ToString();
                }
                if (row["WorkShop"] != null)
                {
                    model.WorkShop = row["WorkShop"].ToString();
                }
                if (row["PtID"] != null)
                {
                    model.PtID = row["PtID"].ToString();
                }
                if (row["Alias"] != null)
                {
                    model.Alias = row["Alias"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
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
                if (row["ProcessSign"] != null)
                {
                    model.ProcessSign = row["ProcessSign"].ToString();
                }
                if (row["IsCheckTotalCount"] != null && row["IsCheckTotalCount"].ToString() != "")
                {
                    if ((row["IsCheckTotalCount"].ToString() == "1") || (row["IsCheckTotalCount"].ToString().ToLower() == "true"))
                    {
                        model.IsCheckTotalCount = true;
                    }
                    else
                    {
                        model.IsCheckTotalCount = false;
                    }
                }
                if (row["OnceQty"] != null && row["OnceQty"].ToString() != "")
                {
                    model.OnceQty = int.Parse(row["OnceQty"].ToString());
                }
                if (row["StandardHours"] != null && row["StandardHours"].ToString() != "")
                {
                    model.StandardHours = decimal.Parse(row["StandardHours"].ToString());
                }
                if (row["ConnectorQty"] != null && row["ConnectorQty"].ToString() != "")
                {
                    model.ConnectorQty = int.Parse(row["ConnectorQty"].ToString());
                }
                if (row["TL"] != null && row["TL"].ToString() != "")
                {
                    model.TL = decimal.Parse(row["TL"].ToString());
                }
                if (row["IsVital"] != null)
                {
                    model.IsVital = row["IsVital"].ToString();
                }
                if (row["IsControl"] != null)
                {
                    model.IsControl = row["IsControl"].ToString();
                }
                if (row["ReWorkProcess"] != null)
                {
                    model.ReWorkProcess = row["ReWorkProcess"].ToString();
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
			strSql.Append("select  * ");
			strSql.Append(" FROM BPM_ProductTemplate ");
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
			strSql.Append("select * ");
			strSql.Append(" FROM BPM_ProductTemplate ");
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
			strSql.Append("select count(1) FROM BPM_ProductTemplate ");
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
			strSql.Append(")AS Row, T.*  from BPM_ProductTemplate T ");
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
		public System.Collections.Generic.List<string> GetPTName()
		{
			DataSet ds = DbHelperSQL.Query("select DISTINCT PtID  FROM BPM_ProductTemplate ORDER BY PtID");
			System.Collections.Generic.List<string> temlist = new System.Collections.Generic.List<string>();
			foreach (DataRow dr in ds.Tables[0].Rows)
				temlist.Add(dr[0].ToString());
			return temlist;
		}

        public System.Collections.Generic.List<string> GetPTName(string Department,string Workshop)
        {
            DataSet ds = DbHelperSQL.Query("select DISTINCT PtID  FROM BPM_ProductTemplate WHERE     (Department = '"+Department+"') AND (WorkShop = '"+Workshop+ "') ORDER BY PtID");
            System.Collections.Generic.List<string> temlist = new System.Collections.Generic.List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
                temlist.Add(dr[0].ToString());
            return temlist;
        }


        #endregion  ExtensionMethod



    }
}

