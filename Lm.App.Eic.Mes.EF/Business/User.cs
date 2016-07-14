using Lm.App.Eic.Mes.EF.Model;

namespace Lm.App.Eic.Mes.EF.Business
{
    public class User : Orm<Model.HR_User>
    {
        public User() : base(Operation.DbTwoMes)
        {
        }

        public User(string jobNum) : base(Operation.DbTwoMes)
        {
            Detailed = GetModel(m => m.Job_Num == jobNum);
        }

        public override HR_User Detailed { get; set; } = new HR_User();
    }
}