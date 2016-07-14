using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lm.App.Eic.Mes.EF
{
    public class Obs<T> : ObservableCollection<T>
    {
        public Obs()
        {
        }

        public Obs(List<T> list) : base(list)
        {
        }

        public void Add(List<T> list)
        {
            this.Clear();
            foreach (var tem in list)
            {
                this.Add(tem);
            }
        }
    }

}
