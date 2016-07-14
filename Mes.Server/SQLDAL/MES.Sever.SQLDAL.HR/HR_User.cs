/* HR_User.cs
*
* 功 能： N/A
* 类 名： HR_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/15 9:26:44   张文明    初版
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
using System.Collections.Generic;
using System.Linq;

namespace MES.Server.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:HR_User
    /// </summary>
    public partial class HR_User : IHR_User
    {
        public HR_User()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal USI_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HR_User");
            strSql.Append(" where USI_ID=@USI_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@USI_ID", SqlDbType.Decimal)
            };
            parameters[0].Value = USI_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(MES.Server.Model.HR_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HR_User(");
            strSql.Append("Department,Workshop,Workstation,ClassType,Job_Title,Is_Job,Job_Num,Name,Password,PhotoPath,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,IsWork,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Emergency_Phone,Resume,Remark,Permission,R1,R2,R3,R4,R5)");
            strSql.Append(" values (");
            strSql.Append("@Department,@Workshop,@Workstation,@ClassType,@Job_Title,@Is_Job,@Job_Num,@Name,@Password,@PhotoPath,@Age,@Sex,@IsWedding,@Politics,@ID_Card,@Nation,@Native_Place,@Degree,@Major,@School,@Date_Of_Birth,@Entry_Date,@Termination_Date,@IsWork,@QQ,@Email_Address,@Phone,@Present_Assress,@Emergency_Contact,@Emergency_Phone,@Resume,@Remark,@Permission,@R1,@R2,@R3,@R4,@R5)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Department", SqlDbType.VarChar,30),
                    new SqlParameter("@Workshop", SqlDbType.NChar,10),
                    new SqlParameter("@Workstation", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassType", SqlDbType.VarChar,30),
                    new SqlParameter("@Job_Title", SqlDbType.VarChar,50),
                    new SqlParameter("@Is_Job", SqlDbType.VarChar,10),
                    new SqlParameter("@Job_Num", SqlDbType.VarChar,30),
                    new SqlParameter("@Name", SqlDbType.VarChar,30),
                    new SqlParameter("@Password", SqlDbType.VarChar,30),
                    new SqlParameter("@PhotoPath", SqlDbType.VarChar,200),
                    new SqlParameter("@Age", SqlDbType.VarChar,10),
                    new SqlParameter("@Sex", SqlDbType.VarChar,10),
                    new SqlParameter("@IsWedding", SqlDbType.VarChar,10),
                    new SqlParameter("@Politics", SqlDbType.VarChar,20),
                    new SqlParameter("@ID_Card", SqlDbType.VarChar,50),
                    new SqlParameter("@Nation", SqlDbType.VarChar,20),
                    new SqlParameter("@Native_Place", SqlDbType.VarChar,255),
                    new SqlParameter("@Degree", SqlDbType.VarChar,20),
                    new SqlParameter("@Major", SqlDbType.VarChar,50),
                    new SqlParameter("@School", SqlDbType.VarChar,50),
                    new SqlParameter("@Date_Of_Birth", SqlDbType.DateTime),
                    new SqlParameter("@Entry_Date", SqlDbType.DateTime),
                    new SqlParameter("@Termination_Date", SqlDbType.DateTime),
                    new SqlParameter("@IsWork", SqlDbType.VarChar,5),
                    new SqlParameter("@QQ", SqlDbType.VarChar,20),
                    new SqlParameter("@Email_Address", SqlDbType.VarChar,30),
                    new SqlParameter("@Phone", SqlDbType.VarChar,30),
                    new SqlParameter("@Present_Assress", SqlDbType.VarChar,255),
                    new SqlParameter("@Emergency_Contact", SqlDbType.Text),
                    new SqlParameter("@Emergency_Phone", SqlDbType.VarChar,50),
                    new SqlParameter("@Resume", SqlDbType.Text),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Permission", SqlDbType.VarChar,50),
                    new SqlParameter("@R1", SqlDbType.VarChar,300),
                    new SqlParameter("@R2", SqlDbType.VarChar,300),
                    new SqlParameter("@R3", SqlDbType.VarChar,300),
                    new SqlParameter("@R4", SqlDbType.VarChar,300),
                    new SqlParameter("@R5", SqlDbType.VarChar,300)};
            parameters[0].Value = model.Department;
            parameters[1].Value = model.Workshop;
            parameters[2].Value = model.Workstation;
            parameters[3].Value = model.ClassType;
            parameters[4].Value = model.Job_Title;
            parameters[5].Value = model.Is_Job;
            parameters[6].Value = model.Job_Num;
            parameters[7].Value = model.Name;
            parameters[8].Value = model.Password;
            parameters[9].Value = model.PhotoPath;
            parameters[10].Value = model.Age;
            parameters[11].Value = model.Sex;
            parameters[12].Value = model.IsWedding;
            parameters[13].Value = model.Politics;
            parameters[14].Value = model.ID_Card;
            parameters[15].Value = model.Nation;
            parameters[16].Value = model.Native_Place;
            parameters[17].Value = model.Degree;
            parameters[18].Value = model.Major;
            parameters[19].Value = model.School;
            parameters[20].Value = model.Date_Of_Birth;
            parameters[21].Value = model.Entry_Date;
            parameters[22].Value = model.Termination_Date;
            parameters[23].Value = model.IsWork;
            parameters[24].Value = model.QQ;
            parameters[25].Value = model.Email_Address;
            parameters[26].Value = model.Phone;
            parameters[27].Value = model.Present_Assress;
            parameters[28].Value = model.Emergency_Contact;
            parameters[29].Value = model.Emergency_Phone;
            parameters[30].Value = model.Resume;
            parameters[31].Value = model.Remark;
            parameters[32].Value = model.Permission;
            parameters[33].Value = model.R1;
            parameters[34].Value = model.R2;
            parameters[35].Value = model.R3;
            parameters[36].Value = model.R4;
            parameters[37].Value = model.R5;

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
        public bool Update(MES.Server.Model.HR_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HR_User set ");
            strSql.Append("Department=@Department,");
            strSql.Append("Workshop=@Workshop,");
            strSql.Append("Workstation=@Workstation,");
            strSql.Append("ClassType=@ClassType,");
            strSql.Append("Job_Title=@Job_Title,");
            strSql.Append("Is_Job=@Is_Job,");
            strSql.Append("Job_Num=@Job_Num,");
            strSql.Append("Name=@Name,");
            strSql.Append("Password=@Password,");
            strSql.Append("PhotoPath=@PhotoPath,");
            strSql.Append("Age=@Age,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("IsWedding=@IsWedding,");
            strSql.Append("Politics=@Politics,");
            strSql.Append("ID_Card=@ID_Card,");
            strSql.Append("Nation=@Nation,");
            strSql.Append("Native_Place=@Native_Place,");
            strSql.Append("Degree=@Degree,");
            strSql.Append("Major=@Major,");
            strSql.Append("School=@School,");
            strSql.Append("Date_Of_Birth=@Date_Of_Birth,");
            strSql.Append("Entry_Date=@Entry_Date,");
            strSql.Append("Termination_Date=@Termination_Date,");
            strSql.Append("IsWork=@IsWork,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Email_Address=@Email_Address,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Present_Assress=@Present_Assress,");
            strSql.Append("Emergency_Contact=@Emergency_Contact,");
            strSql.Append("Emergency_Phone=@Emergency_Phone,");
            strSql.Append("Resume=@Resume,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Permission=@Permission,");
            strSql.Append("R1=@R1,");
            strSql.Append("R2=@R2,");
            strSql.Append("R3=@R3,");
            strSql.Append("R4=@R4,");
            strSql.Append("R5=@R5");
            strSql.Append(" where Job_Num=@Job_Num");
            SqlParameter[] parameters = {
                    new SqlParameter("@Department", SqlDbType.VarChar,30),
                    new SqlParameter("@Workshop", SqlDbType.NChar,10),
                    new SqlParameter("@Workstation", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassType", SqlDbType.VarChar,30),
                    new SqlParameter("@Job_Title", SqlDbType.VarChar,50),
                    new SqlParameter("@Is_Job", SqlDbType.VarChar,10),
                    new SqlParameter("@Job_Num", SqlDbType.VarChar,30),
                    new SqlParameter("@Name", SqlDbType.VarChar,30),
                    new SqlParameter("@Password", SqlDbType.VarChar,30),
                    new SqlParameter("@PhotoPath", SqlDbType.VarChar,200),
                    new SqlParameter("@Age", SqlDbType.VarChar,10),
                    new SqlParameter("@Sex", SqlDbType.VarChar,10),
                    new SqlParameter("@IsWedding", SqlDbType.VarChar,10),
                    new SqlParameter("@Politics", SqlDbType.VarChar,20),
                    new SqlParameter("@ID_Card", SqlDbType.VarChar,50),
                    new SqlParameter("@Nation", SqlDbType.VarChar,20),
                    new SqlParameter("@Native_Place", SqlDbType.VarChar,255),
                    new SqlParameter("@Degree", SqlDbType.VarChar,20),
                    new SqlParameter("@Major", SqlDbType.VarChar,50),
                    new SqlParameter("@School", SqlDbType.VarChar,50),
                    new SqlParameter("@Date_Of_Birth", SqlDbType.DateTime),
                    new SqlParameter("@Entry_Date", SqlDbType.DateTime),
                    new SqlParameter("@Termination_Date", SqlDbType.DateTime),
                    new SqlParameter("@IsWork", SqlDbType.VarChar,5),
                    new SqlParameter("@QQ", SqlDbType.VarChar,20),
                    new SqlParameter("@Email_Address", SqlDbType.VarChar,30),
                    new SqlParameter("@Phone", SqlDbType.VarChar,30),
                    new SqlParameter("@Present_Assress", SqlDbType.VarChar,255),
                    new SqlParameter("@Emergency_Contact", SqlDbType.Text),
                    new SqlParameter("@Emergency_Phone", SqlDbType.VarChar,50),
                    new SqlParameter("@Resume", SqlDbType.Text),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@Permission", SqlDbType.VarChar,50),
                    new SqlParameter("@R1", SqlDbType.VarChar,300),
                    new SqlParameter("@R2", SqlDbType.VarChar,300),
                    new SqlParameter("@R3", SqlDbType.VarChar,300),
                    new SqlParameter("@R4", SqlDbType.VarChar,300),
                    new SqlParameter("@R5", SqlDbType.VarChar,300),
                    new SqlParameter("@USI_ID", SqlDbType.Decimal,9)};
            parameters[0].Value = model.Department;
            parameters[1].Value = model.Workshop;
            parameters[2].Value = model.Workstation;
            parameters[3].Value = model.ClassType;
            parameters[4].Value = model.Job_Title;
            parameters[5].Value = model.Is_Job;
            parameters[6].Value = model.Job_Num;
            parameters[7].Value = model.Name;
            parameters[8].Value = model.Password;
            parameters[9].Value = model.PhotoPath;
            parameters[10].Value = model.Age;
            parameters[11].Value = model.Sex;
            parameters[12].Value = model.IsWedding;
            parameters[13].Value = model.Politics;
            parameters[14].Value = model.ID_Card;
            parameters[15].Value = model.Nation;
            parameters[16].Value = model.Native_Place;
            parameters[17].Value = model.Degree;
            parameters[18].Value = model.Major;
            parameters[19].Value = model.School;
            parameters[20].Value = model.Date_Of_Birth;
            parameters[21].Value = model.Entry_Date;
            parameters[22].Value = model.Termination_Date;
            parameters[23].Value = model.IsWork;
            parameters[24].Value = model.QQ;
            parameters[25].Value = model.Email_Address;
            parameters[26].Value = model.Phone;
            parameters[27].Value = model.Present_Assress;
            parameters[28].Value = model.Emergency_Contact;
            parameters[29].Value = model.Emergency_Phone;
            parameters[30].Value = model.Resume;
            parameters[31].Value = model.Remark;
            parameters[32].Value = model.Permission;
            parameters[33].Value = model.R1;
            parameters[34].Value = model.R2;
            parameters[35].Value = model.R3;
            parameters[36].Value = model.R4;
            parameters[37].Value = model.R5;
            parameters[38].Value = model.USI_ID;

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
        public bool Delete(decimal USI_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HR_User ");
            strSql.Append(" where USI_ID=@USI_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@USI_ID", SqlDbType.Decimal)
            };
            parameters[0].Value = USI_ID;

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
        public bool DeleteList(string USI_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HR_User ");
            strSql.Append(" where USI_ID in (" + USI_IDlist + ")  ");
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



        public List<Model.HR_User> UserChangeClass(List<MES.Server.Model.HR_User> lsUser)
        {
            /*
            1。讲所有人员设置为白板
            2.更新LsUser人员为晚班

            */
            DbHelperSQL.ExecuteSql("UPDATE       HR_User  SET                ClassType = '白班'");
            var ds = GetList("");
            List<Model.HR_User> tem = new List<Model.HR_User>();
            foreach(DataRow dr  in ds.Tables[0].Rows)
            {
                tem.Add(DataRowToModel(dr));
            }

            var NotUpUser = new List<Model.HR_User>();
            foreach(var temUser in lsUser)
            {
                var bb = tem.FirstOrDefault(m => m.Job_Num == temUser.Job_Num);
                if (bb != null)
                {
                    bb.ClassType = "晚班";
                    if (Update(bb))
                    {
                        NotUpUser.Add(bb);
                    }
                  
                }
            }
         
            return NotUpUser;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MES.Server.Model.HR_User GetModel(decimal USI_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 USI_ID,Department,Workshop,Workstation,ClassType,Job_Title,Is_Job,Job_Num,Name,Password,PhotoPath,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,IsWork,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Emergency_Phone,Resume,Remark,Permission,R1,R2,R3,R4,R5 from HR_User ");
            strSql.Append(" where USI_ID=@USI_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@USI_ID", SqlDbType.Decimal)
            };
            parameters[0].Value = USI_ID;

            MES.Server.Model.HR_User model = new MES.Server.Model.HR_User();
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
        public MES.Server.Model.HR_User DataRowToModel(DataRow row)
        {
            MES.Server.Model.HR_User model = new MES.Server.Model.HR_User();
            if (row != null)
            {
                if (row["USI_ID"] != null && row["USI_ID"].ToString() != "")
                {
                    model.USI_ID = decimal.Parse(row["USI_ID"].ToString());
                }
                if (row["Department"] != null)
                {
                    model.Department = row["Department"].ToString();
                }
                if (row["Workshop"] != null)
                {
                    model.Workshop = row["Workshop"].ToString();
                }
                if (row["Workstation"] != null)
                {
                    model.Workstation = row["Workstation"].ToString();
                }
                if (row["ClassType"] != null)
                {
                    model.ClassType = row["ClassType"].ToString();
                }
                if (row["Job_Title"] != null)
                {
                    model.Job_Title = row["Job_Title"].ToString();
                }
                if (row["Is_Job"] != null)
                {
                    model.Is_Job = row["Is_Job"].ToString();
                }
                if (row["Job_Num"] != null)
                {
                    model.Job_Num = row["Job_Num"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["PhotoPath"] != null)
                {
                    model.PhotoPath = row["PhotoPath"].ToString();
                }
                if (row["Age"] != null)
                {
                    model.Age = row["Age"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["IsWedding"] != null)
                {
                    model.IsWedding = row["IsWedding"].ToString();
                }
                if (row["Politics"] != null)
                {
                    model.Politics = row["Politics"].ToString();
                }
                if (row["ID_Card"] != null)
                {
                    model.ID_Card = row["ID_Card"].ToString();
                }
                if (row["Nation"] != null)
                {
                    model.Nation = row["Nation"].ToString();
                }
                if (row["Native_Place"] != null)
                {
                    model.Native_Place = row["Native_Place"].ToString();
                }
                if (row["Degree"] != null)
                {
                    model.Degree = row["Degree"].ToString();
                }
                if (row["Major"] != null)
                {
                    model.Major = row["Major"].ToString();
                }
                if (row["School"] != null)
                {
                    model.School = row["School"].ToString();
                }
                if (row["Date_Of_Birth"] != null && row["Date_Of_Birth"].ToString() != "")
                {
                    model.Date_Of_Birth = DateTime.Parse(row["Date_Of_Birth"].ToString());
                }
                if (row["Entry_Date"] != null && row["Entry_Date"].ToString() != "")
                {
                    model.Entry_Date = DateTime.Parse(row["Entry_Date"].ToString());
                }
                if (row["Termination_Date"] != null && row["Termination_Date"].ToString() != "")
                {
                    model.Termination_Date = DateTime.Parse(row["Termination_Date"].ToString());
                }
                if (row["IsWork"] != null)
                {
                    model.IsWork = row["IsWork"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Email_Address"] != null)
                {
                    model.Email_Address = row["Email_Address"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Present_Assress"] != null)
                {
                    model.Present_Assress = row["Present_Assress"].ToString();
                }
                if (row["Emergency_Contact"] != null)
                {
                    model.Emergency_Contact = row["Emergency_Contact"].ToString();
                }
                if (row["Emergency_Phone"] != null)
                {
                    model.Emergency_Phone = row["Emergency_Phone"].ToString();
                }
                if (row["Resume"] != null)
                {
                    model.Resume = row["Resume"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Permission"] != null)
                {
                    model.Permission = row["Permission"].ToString();
                }
                if (row["R1"] != null)
                {
                    model.R1 = row["R1"].ToString();
                }
                if (row["R2"] != null)
                {
                    model.R2 = row["R2"].ToString();
                }
                if (row["R3"] != null)
                {
                    model.R3 = row["R3"].ToString();
                }
                if (row["R4"] != null)
                {
                    model.R4 = row["R4"].ToString();
                }
                if (row["R5"] != null)
                {
                    model.R5 = row["R5"].ToString();
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
            strSql.Append("select USI_ID,Department,Workshop,Workstation,ClassType,Job_Title,Is_Job,Job_Num,Name,Password,PhotoPath,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,IsWork,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Emergency_Phone,Resume,Remark,Permission,R1,R2,R3,R4,R5 ");
            strSql.Append(" FROM HR_User ");
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
            strSql.Append(" USI_ID,Department,Workshop,Workstation,ClassType,Job_Title,Is_Job,Job_Num,Name,Password,PhotoPath,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,IsWork,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Emergency_Phone,Resume,Remark,Permission,R1,R2,R3,R4,R5 ");
            strSql.Append(" FROM HR_User ");
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
            strSql.Append("select count(1) FROM HR_User ");
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
                strSql.Append("order by T.USI_ID desc");
            }
            strSql.Append(")AS Row, T.*  from HR_User T ");
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
			parameters[0].Value = "HR_User";
			parameters[1].Value = "USI_ID";
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(String jobNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HR_User");
            strSql.Append(" where Job_Num=@Job_Num  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Job_Num", SqlDbType.VarChar,30),
            };
            parameters[0].Value = jobNum;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(String jobNum, string passWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HR_User");
            strSql.Append(" where Job_Num=@Job_Num AND Password = @password ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Job_Num", SqlDbType.VarChar,30),
                    new SqlParameter("@Password", SqlDbType.NChar,10),
            };
            parameters[0].Value = jobNum;
            parameters[1].Value = passWord;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

