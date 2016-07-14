/**
* User_3D_Test_Good.cs
*
* 功 能： N/A
* 类 名： User_3D_Test_Good
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/11 10:23:41   张文明    初版
*
* Copyright (c) 2015 LightMaster Corporation. All rights reserved.
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
	/// 数据访问类:User_3D_Test_Good
	/// </summary>
	public partial class User_3D_Test_Good:IUser_3D_Test_Good
	{
        DbHelperSQLP TwoLineCon = new DbHelperSQLP(PubConnection.TwoLine);
        public User_3D_Test_Good()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(MES.Server.Model.User_3D_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_3D_Test_Good(");
			strSql.Append("SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Name,@Type,@Result,@Curvature,@Curvature_Result,@Spherical,@Spherical_Result,@Planar,@Planar_Result,@Apex_Offset,@Apex_Offset_Result,@Bearing,@Bearing_Result,@Apex_Angle,@Apex_Angle_Result,@Tilt_Offset,@Tilt_Offset_Result,@Tilt_Angle,@Tilt_Angle_Result,@KeyError,@KeyError_Result,@FiberRq,@FiberRq_Result,@FiberRa,@FiberRa_Result,@FerruleRq,@FerruleRq_Result,@FerruleRa,@FerruleRa_Result,@Diameter,@Diameter_Result,@Test_Date,@Test_Time,@D,@E,@F,@A)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Name", SqlDbType.VarChar,35),
					new SqlParameter("@Type", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,8),
					new SqlParameter("@Curvature", SqlDbType.VarChar,15),
					new SqlParameter("@Curvature_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Spherical", SqlDbType.VarChar,15),
					new SqlParameter("@Spherical_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Planar", SqlDbType.VarChar,15),
					new SqlParameter("@Planar_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Bearing", SqlDbType.VarChar,15),
					new SqlParameter("@Bearing_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@KeyError", SqlDbType.VarChar,15),
					new SqlParameter("@KeyError_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRq", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRa", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRq", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRa", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Diameter", SqlDbType.VarChar,15),
					new SqlParameter("@Diameter_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Test_Date", SqlDbType.VarChar,35),
					new SqlParameter("@Test_Time", SqlDbType.VarChar,35),
					new SqlParameter("@D", SqlDbType.VarChar,15),
					new SqlParameter("@E", SqlDbType.VarChar,15),
					new SqlParameter("@F", SqlDbType.VarChar,15),
					new SqlParameter("@A", SqlDbType.VarChar,15)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Curvature;
			parameters[5].Value = model.Curvature_Result;
			parameters[6].Value = model.Spherical;
			parameters[7].Value = model.Spherical_Result;
			parameters[8].Value = model.Planar;
			parameters[9].Value = model.Planar_Result;
			parameters[10].Value = model.Apex_Offset;
			parameters[11].Value = model.Apex_Offset_Result;
			parameters[12].Value = model.Bearing;
			parameters[13].Value = model.Bearing_Result;
			parameters[14].Value = model.Apex_Angle;
			parameters[15].Value = model.Apex_Angle_Result;
			parameters[16].Value = model.Tilt_Offset;
			parameters[17].Value = model.Tilt_Offset_Result;
			parameters[18].Value = model.Tilt_Angle;
			parameters[19].Value = model.Tilt_Angle_Result;
			parameters[20].Value = model.KeyError;
			parameters[21].Value = model.KeyError_Result;
			parameters[22].Value = model.FiberRq;
			parameters[23].Value = model.FiberRq_Result;
			parameters[24].Value = model.FiberRa;
			parameters[25].Value = model.FiberRa_Result;
			parameters[26].Value = model.FerruleRq;
			parameters[27].Value = model.FerruleRq_Result;
			parameters[28].Value = model.FerruleRa;
			parameters[29].Value = model.FerruleRa_Result;
			parameters[30].Value = model.Diameter;
			parameters[31].Value = model.Diameter_Result;
			parameters[32].Value = model.Test_Date;
			parameters[33].Value = model.Test_Time;
			parameters[34].Value = model.D;
			parameters[35].Value = model.E;
			parameters[36].Value = model.F;
			parameters[37].Value = model.A;

			object obj = TwoLineCon.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(MES.Server.Model.User_3D_Test_Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_3D_Test_Good set ");
			strSql.Append("SN=@SN,");
			strSql.Append("Name=@Name,");
			strSql.Append("Type=@Type,");
			strSql.Append("Result=@Result,");
			strSql.Append("Curvature=@Curvature,");
			strSql.Append("Curvature_Result=@Curvature_Result,");
			strSql.Append("Spherical=@Spherical,");
			strSql.Append("Spherical_Result=@Spherical_Result,");
			strSql.Append("Planar=@Planar,");
			strSql.Append("Planar_Result=@Planar_Result,");
			strSql.Append("Apex_Offset=@Apex_Offset,");
			strSql.Append("Apex_Offset_Result=@Apex_Offset_Result,");
			strSql.Append("Bearing=@Bearing,");
			strSql.Append("Bearing_Result=@Bearing_Result,");
			strSql.Append("Apex_Angle=@Apex_Angle,");
			strSql.Append("Apex_Angle_Result=@Apex_Angle_Result,");
			strSql.Append("Tilt_Offset=@Tilt_Offset,");
			strSql.Append("Tilt_Offset_Result=@Tilt_Offset_Result,");
			strSql.Append("Tilt_Angle=@Tilt_Angle,");
			strSql.Append("Tilt_Angle_Result=@Tilt_Angle_Result,");
			strSql.Append("KeyError=@KeyError,");
			strSql.Append("KeyError_Result=@KeyError_Result,");
			strSql.Append("FiberRq=@FiberRq,");
			strSql.Append("FiberRq_Result=@FiberRq_Result,");
			strSql.Append("FiberRa=@FiberRa,");
			strSql.Append("FiberRa_Result=@FiberRa_Result,");
			strSql.Append("FerruleRq=@FerruleRq,");
			strSql.Append("FerruleRq_Result=@FerruleRq_Result,");
			strSql.Append("FerruleRa=@FerruleRa,");
			strSql.Append("FerruleRa_Result=@FerruleRa_Result,");
			strSql.Append("Diameter=@Diameter,");
			strSql.Append("Diameter_Result=@Diameter_Result,");
			strSql.Append("Test_Date=@Test_Date,");
			strSql.Append("Test_Time=@Test_Time,");
			strSql.Append("D=@D,");
			strSql.Append("E=@E,");
			strSql.Append("F=@F,");
			strSql.Append("A=@A");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,25),
					new SqlParameter("@Name", SqlDbType.VarChar,35),
					new SqlParameter("@Type", SqlDbType.VarChar,35),
					new SqlParameter("@Result", SqlDbType.VarChar,8),
					new SqlParameter("@Curvature", SqlDbType.VarChar,15),
					new SqlParameter("@Curvature_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Spherical", SqlDbType.VarChar,15),
					new SqlParameter("@Spherical_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Planar", SqlDbType.VarChar,15),
					new SqlParameter("@Planar_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Bearing", SqlDbType.VarChar,15),
					new SqlParameter("@Bearing_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Apex_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Apex_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Offset", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Offset_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Tilt_Angle", SqlDbType.VarChar,15),
					new SqlParameter("@Tilt_Angle_Result", SqlDbType.VarChar,6),
					new SqlParameter("@KeyError", SqlDbType.VarChar,15),
					new SqlParameter("@KeyError_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRq", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FiberRa", SqlDbType.VarChar,15),
					new SqlParameter("@FiberRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRq", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRq_Result", SqlDbType.VarChar,6),
					new SqlParameter("@FerruleRa", SqlDbType.VarChar,15),
					new SqlParameter("@FerruleRa_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Diameter", SqlDbType.VarChar,15),
					new SqlParameter("@Diameter_Result", SqlDbType.VarChar,6),
					new SqlParameter("@Test_Date", SqlDbType.VarChar,35),
					new SqlParameter("@Test_Time", SqlDbType.VarChar,35),
					new SqlParameter("@D", SqlDbType.VarChar,15),
					new SqlParameter("@E", SqlDbType.VarChar,15),
					new SqlParameter("@F", SqlDbType.VarChar,15),
					new SqlParameter("@A", SqlDbType.VarChar,15),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Curvature;
			parameters[5].Value = model.Curvature_Result;
			parameters[6].Value = model.Spherical;
			parameters[7].Value = model.Spherical_Result;
			parameters[8].Value = model.Planar;
			parameters[9].Value = model.Planar_Result;
			parameters[10].Value = model.Apex_Offset;
			parameters[11].Value = model.Apex_Offset_Result;
			parameters[12].Value = model.Bearing;
			parameters[13].Value = model.Bearing_Result;
			parameters[14].Value = model.Apex_Angle;
			parameters[15].Value = model.Apex_Angle_Result;
			parameters[16].Value = model.Tilt_Offset;
			parameters[17].Value = model.Tilt_Offset_Result;
			parameters[18].Value = model.Tilt_Angle;
			parameters[19].Value = model.Tilt_Angle_Result;
			parameters[20].Value = model.KeyError;
			parameters[21].Value = model.KeyError_Result;
			parameters[22].Value = model.FiberRq;
			parameters[23].Value = model.FiberRq_Result;
			parameters[24].Value = model.FiberRa;
			parameters[25].Value = model.FiberRa_Result;
			parameters[26].Value = model.FerruleRq;
			parameters[27].Value = model.FerruleRq_Result;
			parameters[28].Value = model.FerruleRa;
			parameters[29].Value = model.FerruleRa_Result;
			parameters[30].Value = model.Diameter;
			parameters[31].Value = model.Diameter_Result;
			parameters[32].Value = model.Test_Date;
			parameters[33].Value = model.Test_Time;
			parameters[34].Value = model.D;
			parameters[35].Value = model.E;
			parameters[36].Value = model.F;
			parameters[37].Value = model.A;
			parameters[38].Value = model.ID_Key;

			int rows=TwoLineCon.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_3D_Test_Good ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			int rows=TwoLineCon.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_3D_Test_Good ");
			strSql.Append(" where ID_Key in ("+ID_Keylist + ")  ");
			int rows=TwoLineCon.ExecuteSql(strSql.ToString());
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
		public MES.Server.Model.User_3D_Test_Good GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,ID_Key from User_3D_Test_Good ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			MES.Server.Model.User_3D_Test_Good model=new MES.Server.Model.User_3D_Test_Good();
			DataSet ds=TwoLineCon.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public MES.Server.Model.User_3D_Test_Good DataRowToModel(DataRow row)
		{
			MES.Server.Model.User_3D_Test_Good model=new MES.Server.Model.User_3D_Test_Good();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Curvature"]!=null)
				{
					model.Curvature=row["Curvature"].ToString();
				}
				if(row["Curvature_Result"]!=null)
				{
					model.Curvature_Result=row["Curvature_Result"].ToString();
				}
				if(row["Spherical"]!=null)
				{
					model.Spherical=row["Spherical"].ToString();
				}
				if(row["Spherical_Result"]!=null)
				{
					model.Spherical_Result=row["Spherical_Result"].ToString();
				}
				if(row["Planar"]!=null)
				{
					model.Planar=row["Planar"].ToString();
				}
				if(row["Planar_Result"]!=null)
				{
					model.Planar_Result=row["Planar_Result"].ToString();
				}
				if(row["Apex_Offset"]!=null)
				{
					model.Apex_Offset=row["Apex_Offset"].ToString();
				}
				if(row["Apex_Offset_Result"]!=null)
				{
					model.Apex_Offset_Result=row["Apex_Offset_Result"].ToString();
				}
				if(row["Bearing"]!=null)
				{
					model.Bearing=row["Bearing"].ToString();
				}
				if(row["Bearing_Result"]!=null)
				{
					model.Bearing_Result=row["Bearing_Result"].ToString();
				}
				if(row["Apex_Angle"]!=null)
				{
					model.Apex_Angle=row["Apex_Angle"].ToString();
				}
				if(row["Apex_Angle_Result"]!=null)
				{
					model.Apex_Angle_Result=row["Apex_Angle_Result"].ToString();
				}
				if(row["Tilt_Offset"]!=null)
				{
					model.Tilt_Offset=row["Tilt_Offset"].ToString();
				}
				if(row["Tilt_Offset_Result"]!=null)
				{
					model.Tilt_Offset_Result=row["Tilt_Offset_Result"].ToString();
				}
				if(row["Tilt_Angle"]!=null)
				{
					model.Tilt_Angle=row["Tilt_Angle"].ToString();
				}
				if(row["Tilt_Angle_Result"]!=null)
				{
					model.Tilt_Angle_Result=row["Tilt_Angle_Result"].ToString();
				}
				if(row["KeyError"]!=null)
				{
					model.KeyError=row["KeyError"].ToString();
				}
				if(row["KeyError_Result"]!=null)
				{
					model.KeyError_Result=row["KeyError_Result"].ToString();
				}
				if(row["FiberRq"]!=null)
				{
					model.FiberRq=row["FiberRq"].ToString();
				}
				if(row["FiberRq_Result"]!=null)
				{
					model.FiberRq_Result=row["FiberRq_Result"].ToString();
				}
				if(row["FiberRa"]!=null)
				{
					model.FiberRa=row["FiberRa"].ToString();
				}
				if(row["FiberRa_Result"]!=null)
				{
					model.FiberRa_Result=row["FiberRa_Result"].ToString();
				}
				if(row["FerruleRq"]!=null)
				{
					model.FerruleRq=row["FerruleRq"].ToString();
				}
				if(row["FerruleRq_Result"]!=null)
				{
					model.FerruleRq_Result=row["FerruleRq_Result"].ToString();
				}
				if(row["FerruleRa"]!=null)
				{
					model.FerruleRa=row["FerruleRa"].ToString();
				}
				if(row["FerruleRa_Result"]!=null)
				{
					model.FerruleRa_Result=row["FerruleRa_Result"].ToString();
				}
				if(row["Diameter"]!=null)
				{
					model.Diameter=row["Diameter"].ToString();
				}
				if(row["Diameter_Result"]!=null)
				{
					model.Diameter_Result=row["Diameter_Result"].ToString();
				}
				if(row["Test_Date"]!=null)
				{
					model.Test_Date=row["Test_Date"].ToString();
				}
				if(row["Test_Time"]!=null)
				{
					model.Test_Time=row["Test_Time"].ToString();
				}
				if(row["D"]!=null)
				{
					model.D=row["D"].ToString();
				}
				if(row["E"]!=null)
				{
					model.E=row["E"].ToString();
				}
				if(row["F"]!=null)
				{
					model.F=row["F"].ToString();
				}
				if(row["A"]!=null)
				{
					model.A=row["A"].ToString();
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,ID_Key ");
			strSql.Append(" FROM User_3D_Test_Good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return TwoLineCon.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" SN,Name,Type,Result,Curvature,Curvature_Result,Spherical,Spherical_Result,Planar,Planar_Result,Apex_Offset,Apex_Offset_Result,Bearing,Bearing_Result,Apex_Angle,Apex_Angle_Result,Tilt_Offset,Tilt_Offset_Result,Tilt_Angle,Tilt_Angle_Result,KeyError,KeyError_Result,FiberRq,FiberRq_Result,FiberRa,FiberRa_Result,FerruleRq,FerruleRq_Result,FerruleRa,FerruleRa_Result,Diameter,Diameter_Result,Test_Date,Test_Time,D,E,F,A,ID_Key ");
			strSql.Append(" FROM User_3D_Test_Good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return TwoLineCon.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM User_3D_Test_Good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = TwoLineCon.GetSingle(strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from User_3D_Test_Good T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return TwoLineCon.Query(strSql.ToString());
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
			parameters[0].Value = "User_3D_Test_Good";
			parameters[1].Value = "ID_Key";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return TwoLineCon.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

