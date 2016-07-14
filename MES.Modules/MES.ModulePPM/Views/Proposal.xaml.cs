using System.Windows.Controls;

namespace MES.ModulePPM
{
    /// <summary>
    /// Interaction logic for Proposal.xaml
    /// </summary>
    public partial class Proposal : UserControl
    {
        public Proposal()
        {
            InitializeComponent();
            this.DataContext = new VM_Proposal();
        }
    }
}
