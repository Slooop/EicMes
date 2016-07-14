
using MES.Server.BLL;

namespace MES.Business
{

    /// <summary>
    /// BPM业务层帮助类
    /// </summary>
    public static class BpmHelper
    {
        static  BPM_Daily _daily;
        /// <summary>
        /// 日报业务类
        /// </summary>
        public static BPM_Daily Daily=> _daily = _daily == null ? new BPM_Daily() : _daily;

        static  BPM_Order _order;
        /// <summary>
        /// 工单业务层
        /// </summary>
        public static BPM_Order Order => _order = _order == null ? new BPM_Order() : _order;

        static BPM_Order_ERP _order_erp;
        /// <summary>
        /// 工单业务层-For ERP
        /// </summary>
        public static BPM_Order_ERP Order_ERP => _order_erp = _order_erp == null ? new BPM_Order_ERP() : _order_erp;

        static  BPM_OrderRelevance orderRelevance;
        /// <summary>
        /// 附加工单业务层
        /// </summary>
        public static BPM_OrderRelevance OrderRelevance => orderRelevance = orderRelevance == null ? new BPM_OrderRelevance() : orderRelevance;


        static  BPM_Process process;
        /// <summary>
        /// 工序业务层
        /// </summary>
        public static BPM_Process Process => process = process == null ? new BPM_Process() : process;


        static  BPM_Product product;
        /// <summary>
        /// 产品业务层
        /// </summary>
        public static BPM_Product Product => product = product == null ? new BPM_Product() : product;


        static BPM_ProductionRecords productionRecords;
        /// <summary>
        /// 关键工序日报业务层   
        /// </summary>
        public static BPM_ProductionRecords ProductionRecords => productionRecords = productionRecords ==null ? new BPM_ProductionRecords():productionRecords;


        static  BPM_ProductTemplate productTemplate;
        /// <summary>
        /// 产品模板业务层
        /// </summary>
        public static BPM_ProductTemplate ProductTemplate => productTemplate = productTemplate ==null ? new BPM_ProductTemplate():productTemplate;


        static  BPM_ReWork reWork;
        /// <summary>
        /// 重工业务层
        /// </summary>
        public static BPM_ReWork ReWork => reWork = reWork == null ? new BPM_ReWork():reWork;


      

        static  BPM_WIP wip;
        /// <summary>
        /// Wip业务层
        /// </summary>
        public static BPM_WIP Wip => wip = wip ==null ? new BPM_WIP():wip;


    }


    /// <summary>
    /// ＨＲ业务层帮助类
    /// </summary>
    public static class HrHelper
    {
        static  HR_User user;
        /// <summary>
        /// 用户业务层
        /// </summary>
        public static HR_User User => user = user ==null ? new HR_User():user;
    }


    /// <summary>
    /// 系统配置业务层
    /// </summary>
     public static class SysHelper
    {

        static  SYS_TypeList typeList;
        /// <summary>
        /// 类别列表业务层
        /// </summary>
        public static SYS_TypeList TypeList => typeList = typeList ==null ? new SYS_TypeList():typeList;

    }

 

    
}
