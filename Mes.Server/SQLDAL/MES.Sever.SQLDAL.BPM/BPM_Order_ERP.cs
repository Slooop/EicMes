using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MES.Server.Model;
using MES.Server.DBUtility;
using System.Data.SqlClient;

namespace MES.Server.SQLServerDAL
{
  public  class BPM_Order_ERP : IDAL.IBPM_Order
    {
        DbHelperSQLP ligMat = new DbHelperSQLP(PubConnection.lig);
        BPM_Order order = new BPM_Order();

        public bool Add(Model.BPM_Order model)
        {
            return false;
        }
        public bool Delete(string OrderID)
        {
            return false;
        }
        public bool DeleteList(string OrderIDlist)
        {
            return false;
        }
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return null;
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return null;
        }
        public int GetRecordCount(string strWhere)
        {
            return 0;
        }

        public bool Update(Model.BPM_Order model)
        {
            return false;
        }

        public Model.BPM_Order DataRowToModel(DataRow row)
        {
            Model.BPM_Order model = new Model.BPM_Order();
            if (row != null)
            {
                if (row["TA001"] != null && row["TA002"] != null)
                {
                    model.OrderID = row["TA001"].ToString().Replace(" ", "") + "-"+ row["TA002"].ToString().Replace(" ", "");
                }
                if (row["TA006"] != null)
                {
                    model.ProductID = row["TA006"].ToString();
                }
                if (row["TA034"] != null)
                {
                    model.ProductName = row["TA034"].ToString();
                }
                if (row["TA035"] != null)
                {
                    model.Spec = row["TA035"].ToString();
                }
                if (row["TA015"] != null)
                {
                    model.Count = double.Parse(row["TA015"].ToString());
                }
                if (row["TA009"] != null)
                {
                    model.StartDate = row["TA009"].ToString();
                }
                if (row["TA010"] != null)
                {
                    model.EndDate = row["TA010"].ToString();
                }
                if (row["TA011"] != null)
                {
                    string state = row["TA011"].ToString();
                    switch (state)
                    {
                        case "1":
                            model.State = "未生产"; break;
                        case "2":
                            model.State = "已发料"; break;
                        case "3":
                            model.State = "生产中"; break;
                        case "Y":
                            model.State = "已完工"; break;
                        case "y":
                            model.State = "指定完工"; break;
                        default:
                            break;
                    }
                }
                if (row["TA012"] != null)
                {
                    model.ActualStartDate = row["TA012"].ToString();
                }
                if (row["TA014"] != null)
                {
                    model.ActualEndDate = row["TA014"].ToString();
                }

                if (row["TA017"] != null)
                {
                    model.InStorageCount = double.Parse(row["TA017"].ToString());
                }

                model.IsRemind = false;
            }
            BPM_Product product = new BPM_Product();
            model.Product = product.GetModel(model.ProductID);  //产品信息
            return model;
        }

      

      /// <summary>
      /// 工单是否存在
      /// </summary>
      /// <param name="OrderID"></param>
      /// <returns></returns>
        public bool Exists(string OrderID)
        {
            if (OrderID.Length > 10)
            {
                string _orderTyep = OrderID.Substring(0, 3);
                string _orderid = OrderID.Substring(4,OrderID.Length-4 );
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from MOCTA");
                strSql.Append(" where TA001='" + _orderTyep + "' and TA002='" + _orderid + "'");
                return ligMat.Exists(strSql.ToString());
            }
            else return false;
        }

        /// <summary>
        /// 获取工单列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            return ligMat.Query("select * from MOCTA WHERE " + strWhere);
        }

     
        /// <summary>
        /// 获取一个工单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Model.BPM_Order GetModel(string orderID)
        {
            if (orderID.Length > 10)
            {
                string _orderTyep = orderID.Substring(0, 3);
                string _orderid = orderID.Substring(4, orderID.Length-4);
                DataSet ds = ligMat.Query("select * from MOCTA where TA001='" + _orderTyep + "' and TA002='" + _orderid + "'");
                if (ds.Tables[0].Rows.Count > 0)
                    return DataRowToModel(ds.Tables[0].Rows[0]);
                else return null;
            }
            else return null;
        }
    }
}
