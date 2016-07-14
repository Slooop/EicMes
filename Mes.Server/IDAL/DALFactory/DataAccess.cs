using System;
using System.Configuration;
using System.Reflection;
using MES.Server.IDAL;

namespace MES.Server.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath_HR = ConfigurationManager.AppSettings["DAL_HR"];
        private static readonly string AssemblyPath_BPM = ConfigurationManager.AppSettings["DAL_BPM"];

        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch (System.Exception ex)
            {
                string str = ex.Message;// 记录错误日志
                return null;
            }

        }

      



        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch (System.Exception ex)
                {
                    string str = ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
      
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}

        public static object Create(string _ClsaaName)
        {
            string ClassNamespace = AssemblyPath_HR + _ClsaaName;
            object objType = CreateObject(AssemblyPath_HR, ClassNamespace);
            return (object)objType;
        }


        /// <summary>
        /// 创建HR_User数据层接口。
        /// </summary>
        public static MES.Server.IDAL.IHR_User CreateHR_User()
        {
           /*
            string ClassNamespace = AssemblyPath_HR + ".HR_User";
            object objType = CreateObject(AssemblyPath_HR, ClassNamespace);
            */
            return (MES.Server.IDAL.IHR_User)new MES.Server.SQLServerDAL.HR_User();
        }


        /// <summary>
        /// 创建BPM_Process数据层接口。
        /// </summary>
        public static MES.Server.IDAL.IBPM_Process CreateBPM_Process()
        {
            return (MES.Server.IDAL.IBPM_Process)new MES.Server.SQLServerDAL.BPM_Process();
        }



        /// <summary>
        /// 创建BPM_Product数据层接口。
        /// </summary>
        public static MES.Server.IDAL.IBPM_Product CreateBPM_Product()
        {
            return (MES.Server.IDAL.IBPM_Product)new MES.Server.SQLServerDAL.BPM_Product();
        }


        /// <summary>
        /// 创建BPM_ProductTemplate数据层接口。
        /// </summary>
        public static MES.Server.IDAL.IBPM_ProductTemplate CreateBPM_ProductTemplate()
        {
            return (MES.Server.IDAL.IBPM_ProductTemplate)new MES.Server.SQLServerDAL.BPM_ProductTemplate();
        }

        public static MES.Server.IDAL.IBPM_Order CreateBPM_Order()
        {
            return (MES.Server.IDAL.IBPM_Order)new MES.Server.SQLServerDAL.BPM_Order();
        }

        public static MES.Server.IDAL.IBPM_Order CreateBPM_Order_ERP()
        {
            return (MES.Server.IDAL.IBPM_Order)new MES.Server.SQLServerDAL.BPM_Order_ERP();
        }


        public static MES.Server.IDAL.IBPM_OrderRelevance CreateBPM_OrderRelevance()
        {
            return (MES.Server.IDAL.IBPM_OrderRelevance)new MES.Server.SQLServerDAL.BPM_OrderRelevance();
        }

        public static MES.Server.IDAL.IBPM_WIP CreateBPM_WIP()
        {
            return (MES.Server.IDAL.IBPM_WIP)new MES.Server.SQLServerDAL.BPM_WIP();
        }

        public static MES.Server.IDAL.IBPM_ReWork CreateBPM_ReWork()
        {
            return (MES.Server.IDAL.IBPM_ReWork)new MES.Server.SQLServerDAL.BPM_ReWork();
        }

        public static MES.Server.IDAL.IBPM_FlowCard CreateBPM_FlowCard()
        {
            return (MES.Server.IDAL.IBPM_FlowCard)new MES.Server.SQLServerDAL.BPM_FlowCard();
        }

      

        public static MES.Server.IDAL.IBPM_ProductionRecords CreateBPM_ProductionRecords()
        {
            return (MES.Server.IDAL.IBPM_ProductionRecords)new MES.Server.SQLServerDAL.BPM_ProductionRecords();
        }

        public static MES.Server.IDAL.IBPM_Daily CreateBPM_Daily()
        {
            return (MES.Server.IDAL.IBPM_Daily)new MES.Server.SQLServerDAL.BPM_Daily();
        }


        

        public static ISYS_TypeList CreateSYS_TypeList()
        {
            return (ISYS_TypeList)new MES.Server.SQLServerDAL.SYS_TypeList();
        }

        public static IV_ProductionRecords CreateV_ProductionRecords()
        {
            return (IV_ProductionRecords)new MES.Server.SQLServerDAL.V_ProductionRecords();
        }


      


       
        #endregion

    }
}
