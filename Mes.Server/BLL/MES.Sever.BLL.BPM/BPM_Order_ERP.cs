using MES.Server.DALFactory;
using MES.Server.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ZhuifengLib;

namespace MES.Server.BLL
{
    public class BPM_Order_ERP
    {
        private readonly IBPM_Order dal = DataAccess.CreateBPM_Order_ERP();

        #region  Order_MESdb
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderID)
        {
            return dal.Exists(OrderID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BPM_Order GetModel(string OrderID)
        {
            if (!OrderID.IsNullOrEmpty() && OrderID.Length > 7)
            {
                var tem = dal.GetModel(OrderID);
                if (tem == null) return null;
                tem.Relax = double.Parse("1.20");
                return tem;
            }
            else
            {
                ZhuifengLib.MessageShow.Message.
                    MessageInfo("输入不合法！");
                return new Model.BPM_Order();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.BPM_Order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.BPM_Order> DataTableToList(DataTable dt)
        {
            List<Model.BPM_Order> modelList = new List<Model.BPM_Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.BPM_Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        #endregion  BasicMethod

    }
}
