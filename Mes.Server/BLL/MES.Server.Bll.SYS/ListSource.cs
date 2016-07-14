using System.Collections.Generic;

namespace MES.Server.BLL.SYS
{
    public class ListSource
    {
        public ListSource()
        {
            Workstation = bll_typelist.lsType(TypeList.Workstation);
        }
        SYS_TypeList bll_typelist = new Server.BLL.SYS_TypeList();

        /// <summary>
        /// 部门
        /// </summary>
        public List<string> Department => bll_typelist.lsType(TypeList.Department);

        /// <summary>
        /// 生产车间
        /// </summary>
        public List<string> WorkShop => bll_typelist.lsType(TypeList.Workshop);


        //  public List<string> Workstation => bll_typelist.lsType(TypeList.Workstation);
        /// <summary>
        /// 站别
        /// </summary>
        private List<string> workstation = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public List<string> Workstation
        {
            get { return workstation; }
            set
            {
                workstation = value;
            }
        }


        /// <summary>
        /// 班别
        /// </summary>
        public List<string> ClassType => bll_typelist.lsType(TypeList.ClassType);

        /// <summary>
        /// 性别
        /// </summary>
        public List<string> Sex => bll_typelist.lsType(TypeList.Sex);

        /// <summary>
        /// 职位
        /// </summary>
        public List<string> JobTitle => bll_typelist.lsType(TypeList.JobTitle);

        /// <summary>
        /// 是否在职
        /// </summary>
        public List<string> IsJob => bll_typelist.lsType(TypeList.TrueOrFalse);

        /// <summary>
        /// 是否在职
        /// </summary>
        public List<string> Is_Job => bll_typelist.lsType(TypeList.Is_Job);

        /// <summary>
        /// 是否已婚
        /// </summary>
        public List<string> IsWedding => bll_typelist.lsType(TypeList.IsWedding);

        /// <summary>
        /// 政治面貌
        /// </summary>
        public List<string> Politics => bll_typelist.lsType(TypeList.Politics);

        /// <summary>
        /// 学历
        /// </summary>
        public List<string> Degree => bll_typelist.lsType(TypeList.Degree);

        /// <summary>
        /// 工单状态
        /// </summary>
        public List<string> OrderState => bll_typelist.lsType(TypeList.OrderState);

        /// <summary>
        /// 客户列表
        /// </summary>
        public List<string> Client => bll_typelist.lsType(TypeList.Client);

      
    }
}
