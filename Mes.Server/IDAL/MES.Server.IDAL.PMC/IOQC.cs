namespace MES.Server.IDAL.PMC
{
    public interface IOQC
    {
        void Land(string _orderid);                           //初始化包装检测类

        Model.BPM_Order order { get; set; }       //此工单

        bool Inspect();                                     //进行检测

        Model.BPM_Order SetOrder(string orderid);
    }
}
