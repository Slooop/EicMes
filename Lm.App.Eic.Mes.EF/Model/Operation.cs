namespace Lm.App.Eic.Mes.EF.Model
{
    public static class Operation
    {
        private static TwoMes dbTwoMes;

        /// <summary>
        /// QQQQ-MS2 MES 数据服务
        /// </summary>
        public static TwoMes DbTwoMes => dbTwoMes = dbTwoMes == null ? new TwoMes() : dbTwoMes;
    }
}