using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// Interaction logic for UserFlowCard.xaml
    /// </summary>
    public partial class UserFlowCard : UserControl
    {
        public UserFlowCard()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.UserFlowCard();
        }
    }
}