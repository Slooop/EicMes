namespace MES.Server.BLL
{
    public class Toslink
    {
        SerialNumber sr = new LiuShuiMa();
        LiuShuiMa ls = new LiuShuiMa();
        void tes()
        {
          
        }
    }


    public class SerialNumber
    {
        public string Sn { get; set; }            
    }

    public class BiaoZhi : SerialNumber
    {
        public string Biaozhi { get; set; }
    }

    public class LiuShuiMa : BiaoZhi
    {
        public string Liushuima { get { return Biaozhi; } set {} }
    }
}