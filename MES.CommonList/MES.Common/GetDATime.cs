using System;
using MES.Server.DBUtility;
using System.Data;

namespace MES.Common
{
    public static class GetDATime
    {
       public static DateTime GetTime()
       {
           DataSet ds = DbHelperSQL.Query("SELECT GETDATE() AS CurrentDateTime");
           return DateTime.Parse(ds.Tables[0].Rows[0]["CurrentDateTime"].ToString());
       }
    }
}
