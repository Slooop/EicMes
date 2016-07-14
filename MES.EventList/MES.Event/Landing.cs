using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Event
{
    public static class Landing
    {
       
        /// <summary>
        /// 传递用户
        /// </summary>
        /// <param name="e">登陆</param>
        public  delegate void LandEventHadler(MES.Server.Model.HR_User e);

        /// <summary>
        /// 用户登陆成功时触发
        /// </summary>
        public static event LandEventHadler Land;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="e"></param>
        public static void onLand(MES.Server.Model.HR_User e)
        {
            if (Land != null) { Land(e); }
        }
        
    }
}
