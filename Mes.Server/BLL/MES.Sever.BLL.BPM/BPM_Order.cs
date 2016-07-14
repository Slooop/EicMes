using MES.Server.DALFactory;
using MES.Server.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using ZhuifengLib;

namespace MES.Server.BLL
{
    public class BPM_Order
    {
        private readonly IBPM_Order dal = DataAccess.CreateBPM_Order();
        private readonly IBPM_Order dal_ERP = DataAccess.CreateBPM_Order_ERP();


        /// <summary>
        /// 获取一个工单
        /// </summary>
        /// <param name="orderID">工单编号</param>
        /// <returns></returns>
        private Model.BPM_Order GetModel_ERP(string orderID) 
        {
            return dal_ERP.GetModel(orderID);
        }


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
            if (OrderID != null && OrderID.Length > 7)
            {
                if (dal.Exists(OrderID))
                    return dal.GetModel(OrderID);
                else
                {
                    try
                    {
                        var tem = dal_ERP.GetModel(OrderID);
                        if (tem == null) return null;
                        tem.Relax = double.Parse("1.20");
                        return tem;
                    }

                    catch (Exception ex)
                    {
                        ZhuifengLib.MessageShow.Message.
                            MessageInfo($"未能获取工单{OrderID}的信息\r\n{ex.Message}");
                        return new Model.BPM_Order();
                    }
                    
                       
                }
            }
            else return null;
              
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.BPM_Order model)
        {

            if (model.State == "已完工" && model.ActualStartDate.IsNullOrEmpty())
            {
                model.ActualEndDate = DateTime.Now.Date.ToString("yyyyMMdd");
            }

            BPM_Daily daily = new BPM_Daily();
            daily.UpdateOrderState(model);
            if (!dal.Exists(model.OrderID))
            {
                model.IsRemind = true;
                model.Relax = 1.2;
                return dal.Add(model);
            }
            else
            {
                //if (!MyMessage.IsOkMessage("本地已存在此工单，继续将更新本地工单，是否继续！")) return false;
                return dal.Update(model);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.BPM_Order model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string OrderID)
        {

            return dal.Delete(OrderID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OrderIDlist)
        {
            return dal.DeleteList(OrderIDlist);
        }


        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.BPM_Order GetModelByCache(string OrderID)
        {

            var CacheKey = "BPM_OrderModel-" + OrderID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel != null) return (Model.BPM_Order) objModel;
            try
            {
                objModel = dal.GetModel(OrderID);
                if (objModel != null)
                {
                    int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                    Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                }
            }
            catch { }
            return (Model.BPM_Order)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

        #region  ExtensionMethod
      
        //定义隐式转换
        //BPM_Order order =  "512-1504286";

        //public static implicit operator BPM_Order(string orderID)
        //{
        //    BPM_Order temOrder = new BPM_Order();
        //    return temOrder;
        //}
        #endregion  ExtensionMethod
    }
}
