using System.Windows.Controls;

namespace MES.ModulePPM
{
    /// <summary>
    /// Interaction logic for ProposalOverview.xaml
    /// </summary>
    public partial class ProposalOverview : UserControl
    {
        public ProposalOverview()
        {
            InitializeComponent();
            this.DataContext = new VM_ProposalOverview();
        }
    }
}
