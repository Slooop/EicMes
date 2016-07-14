using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lm.App.Eic.Mes.EF.Model;

namespace Lm.App.Eic.Mes.EF.Business
{
   public class UserFlowCard : Orm<Model.BPM_UserFlowCard>
    {
        private string str;

        public UserFlowCard() : base(Operation.DbTwoMes) { }

        public UserFlowCard(string str):base(Operation.DbTwoMes)
        {
            Detailed = GetModel(m => m.FlowCard == str);
        }

        public override BPM_UserFlowCard Detailed { get; set; } = new BPM_UserFlowCard();
       
    }
}
