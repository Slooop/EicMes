/* HR_User.cs
*
* 功 能： N/A
* 类 名： HR_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/15 9:26:43   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace MES.Server.Model
{
	/// <summary>
	/// HR_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HR_User
	{
		public HR_User()
		{}
        #region Model
        private decimal _usi_id;
        private string _department;
        private string _workshop;
        private string _workstation;
        private string _classtype;
        private string _job_title;
        private string _is_job;
        private string _job_num;
        private string _name;
        private string _password;
        private string _photopath;
        private string _age;
        private string _sex;
        private string _iswedding;
        private string _politics;
        private string _id_card;
        private string _nation;
        private string _native_place;
        private string _degree;
        private string _major;
        private string _school;
        private DateTime? _date_of_birth;
        private DateTime? _entry_date;
        private DateTime? _termination_date;
        private string _iswork;
        private string _qq;
        private string _email_address;
        private string _phone;
        private string _present_assress;
        private string _emergency_contact;
        private string _emergency_phone;
        private string _resume;
        private string _remark;
        private string _permission;
        private string _r1;
        private string _r2;
        private string _r3;
        private string _r4;
        private string _r5;
        /// <summary>
        /// 
        /// </summary>
        public decimal USI_ID
        {
            set { _usi_id = value; }
            get { return _usi_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Workshop
        {
            set { _workshop = value; }
            get { return _workshop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Workstation
        {
            set { _workstation = value; }
            get { return _workstation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassType
        {
            set { _classtype = value; }
            get { return _classtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Job_Title
        {
            set { _job_title = value; }
            get { return _job_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Is_Job
        {
            set { _is_job = value; }
            get { return _is_job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Job_Num
        {
            set { _job_num = value; }
            get { return _job_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoPath
        {
            set { _photopath = value; }
            get { return _photopath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsWedding
        {
            set { _iswedding = value; }
            get { return _iswedding; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Politics
        {
            set { _politics = value; }
            get { return _politics; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID_Card
        {
            set { _id_card = value; }
            get { return _id_card; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Native_Place
        {
            set { _native_place = value; }
            get { return _native_place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Degree
        {
            set { _degree = value; }
            get { return _degree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Major
        {
            set { _major = value; }
            get { return _major; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string School
        {
            set { _school = value; }
            get { return _school; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date_Of_Birth
        {
            set { _date_of_birth = value; }
            get { return _date_of_birth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Entry_Date
        {
            set { _entry_date = value; }
            get { return _entry_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Termination_Date
        {
            set { _termination_date = value; }
            get { return _termination_date; }
        }
        /// <summary>
        /// 是否在职
        /// </summary>
        public string IsWork
        {
            set { _iswork = value; }
            get { return _iswork; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email_Address
        {
            set { _email_address = value; }
            get { return _email_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Present_Assress
        {
            set { _present_assress = value; }
            get { return _present_assress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Emergency_Contact
        {
            set { _emergency_contact = value; }
            get { return _emergency_contact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Emergency_Phone
        {
            set { _emergency_phone = value; }
            get { return _emergency_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Resume
        {
            set { _resume = value; }
            get { return _resume; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Permission
        {
            set { _permission = value; }
            get { return _permission; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R1
        {
            set { _r1 = value; }
            get { return _r1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R2
        {
            set { _r2 = value; }
            get { return _r2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R3
        {
            set { _r3 = value; }
            get { return _r3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R4
        {
            set { _r4 = value; }
            get { return _r4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R5
        {
            set { _r5 = value; }
            get { return _r5; }
        }
        #endregion Model


    }
}

