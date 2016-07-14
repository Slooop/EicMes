using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// DailyView.xaml 的交互逻辑
    /// </summary>
    public partial class DailyView : UserControl
    {
        public DailyView()
        {
            InitializeComponent();
            this.DataContext = new DailyOverViewViewModel();
        }
    }
}
