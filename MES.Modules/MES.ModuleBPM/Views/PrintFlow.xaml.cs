using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// Interaction logic for PintFlow.xaml
    /// </summary>
    public partial class PrintFlow : UserControl
    {
        public PrintFlow()
        {
            InitializeComponent();
            this.DataContext = new PrintFlowViewModel();
        }

        
    }
}
