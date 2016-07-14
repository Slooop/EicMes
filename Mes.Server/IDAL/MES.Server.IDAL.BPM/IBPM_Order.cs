using System.Data;

namespace MES.Server.IDAL
{
    public interface IBPM_Order
    {
       
       #region  Order_MESdb
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       bool Exists(string OrderID);
       /// <summary>
       /// 增加一条数据
       /// </summary>
       bool Add(Model.BPM_Order model);
       /// <summary>
       /// 更新一条数据
       /// </summary>
       bool Update(Model.BPM_Order model);
       /// <summary>
       /// 删除一条数据
       /// </summary>
       bool Delete(string OrderID);
       bool DeleteList(string OrderIDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.BPM_Order GetModel(string OrderID);
        Model.BPM_Order DataRowToModel(DataRow row);
       /// <summary>
       /// 获得数据列表
       /// </summary>
       DataSet GetList(string strWhere);
       /// <summary>
       /// 获得前几行数据
       /// </summary>
       DataSet GetList(int Top, string strWhere, string filedOrder);
       int GetRecordCount(string strWhere);
       DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
       #endregion  Order_MESdb


    }
}
