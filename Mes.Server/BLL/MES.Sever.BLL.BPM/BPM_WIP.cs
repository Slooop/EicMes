/**  版本信息模板在安装目录下，可自行修改。
* BPM_WIP.cs
*
* 功 能： N/A
* 类 名： BPM_WIP
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/7 星期一 16:36:51   张文明    初版
*
* Copyright (c) 2015 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using MES.Server.DALFactory;
using MES.Server.IDAL;
using System.Linq;

namespace MES.Server.BLL
{
    /// <summary>
    /// BPM_WIP
    /// </summary>
    public partial class BPM_WIP
	{
		private readonly IBPM_WIP dal=DataAccess.CreateBPM_WIP();
		public BPM_WIP()
		{}

        #region  BasicMethod
        
        /// <summary>
        /// 是否有此工单的WIP档案
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        public bool Exists(Model.BPM_Order Order)
        {
            return GetModelList("OrderID='" + Order.OrderID + "'").Count > 0 ? true:false;
        }

        /// <summary>
        /// 创建工单WIP
        /// </summary>
        /// <param name="Order"></param>
        public void CreateOrderWip(Model.BPM_Order Order)
        {
            BPM_Daily bll_Daily = new BPM_Daily();
            var lsDaily = bll_Daily.GetModelList("OrderID='" + Order.OrderID + "'");
            if(Order!=null && Order.Product!=null && Order.Product.ProcessList.Count>0)
            {
                foreach (var process in Order.Product.ProcessList)
                {
                    var Model = new Model.BPM_WIP()
                    {
                        OrderID = Order.OrderID,
                        ClientName = Order.ClientName,
                        ProductName = Order.ProductName,
                        Spec = Order.Spec,
                        Count = Convert.ToInt32(Order.Count),
                        ProcessCount = Convert.ToInt32(Order.Count) * process.ConnectorQty,
                        ProcessID = process.ProcessID,
                        ProcessName = process.ProcessName,
                        StandardHours = Convert.ToDouble(process.StandardHours),
                        ConnectorQty = process.ConnectorQty,
                        ProcessSign = process.ProcessSign,
                        TotalStandatdHours = Order.Count * process.ConnectorQty * Convert.ToDouble(process.StandardHours),
                        Qty_OK = lsDaily.Where(x => x.ProcessID == process.ProcessID).Sum(p => p.QtyOK),
                        Qty_NG = lsDaily.Where(x => x.ProcessID == process.ProcessID).Sum(p => p.QtyNG),
                        Qty = lsDaily.Where(x => x.ProcessID == process.ProcessID).Sum(p => p.Qty),
                        WorkHours = Convert.ToDouble(lsDaily.Where(x => x.ProcessID == process.ProcessID).Sum(p => p.WorkHours)),
                    };
                    Model.Qty_NotInput = Model.ProcessCount - Model.Qty;
                    Model.GetTime = Model.Qty * Model.StandardHours;
                    if (Model.GetTime == 0 || Model.WorkHours == 0)
                        Model.Efficiency = 0;
                    else Model.Efficiency = Convert.ToDouble(Model.GetTime / Model.WorkHours);

                    dal.Add(Model);
                }
            }
        }


        /// <summary>
        /// 录入日报
        /// </summary>
        /// <param name="Daily"></param>
        public void EnterDaily(Model.BPM_Daily Daily)
        {
            var orderWipList = GetOrderWIPList(Daily.OrderID);
            var wip = orderWipList.FirstOrDefault(x => x.ProcessID == Daily.ProcessID);
            var WipIdx = orderWipList.IndexOf(wip);
            BPM_Daily bll_Daily = new BPM_Daily();
            var lsDaily = bll_Daily.GetModelList("OrderID='" + Daily.OrderID + "'");
            if (wip != null)
            {
              
                wip.Qty_NG = lsDaily.Where(x => x.ProcessID == Daily.ProcessID).Sum(p => p.QtyNG);
                wip.Qty_OK = lsDaily.Where(x => x.ProcessID == Daily.ProcessID).Sum(p => p.QtyOK);
                wip.WorkHours += Convert.ToDouble(lsDaily.Where(x => x.ProcessID == Daily.ProcessID).Sum(p => p.WorkHours));

                wip.Qty = wip.Qty_NG + wip.Qty_OK;
                wip.Qty_NotInput = wip.ProcessCount - wip.Qty;
                wip.GetTime = wip.Qty * wip.StandardHours;
                wip.Efficiency = Convert.ToDouble( wip.GetTime / wip.WorkHours);

                Update(wip);
            }
           
        }

        /// <summary>
        /// 获取工单WIP
        /// </summary>
        public List<Model.BPM_WIP> GetOrderWIPList(Model.BPM_Order Order)
        {
            if (!Exists(Order))
            {
                CreateOrderWip(Order);
            }
            DataSet ds = dal.GetList("OrderID='"+Order.OrderID+"'");
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获取工单WIP
        /// </summary>
         List<Model.BPM_WIP> GetOrderWIPList(string OrderID)
        {
            
            DataSet ds = dal.GetList("OrderID='" + OrderID + "'");
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BPM_WIP model)
        {
            return dal.Update(model);
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MES.Server.Model.BPM_WIP GetModel(decimal ID_Key)
        {

            return dal.GetModel(ID_Key);
        }


        public bool Delete(string orderID)
        {
            return dal.Delete(orderID);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.BPM_WIP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		private List<Model.BPM_WIP> DataTableToList(DataTable dt)
        {
            List<Model.BPM_WIP> modelList = new List<Model.BPM_WIP>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.BPM_WIP model;
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

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

