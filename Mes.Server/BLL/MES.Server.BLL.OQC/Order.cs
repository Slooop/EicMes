using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.Server.BLL.OQC
{
    class Order
    {
        public object OrderInfo;          //工单信息

        public object SnList;             //SN 列表

        public object InspectStandard;    //检测标准

        public object LabInfo;            //标签信息

        public object PackLotInfo;        //批号信息

        public Action<bool> An_InspectOver; //检测结束时触发 

        public Action An_PrintOver; //打印结束时触发

        public bool StartInspect() { return true; }  //开始检测

        public bool StartPrint() { return true; }  //开始打印
    }

    class Inspect
    {
        public List<string> tiaomaList;    //条码列表

        public List<string> peizhuList;    //配组的列表

        public List<string> jietouList;    //接头列表

        bool peizu; //检测配组是否完成

        bool jietou; //检测接头是否符合标准

        bool pihao; //检测批号是否包装完成

        bool gongdan; //检测工单是否包装完成

    }
}
