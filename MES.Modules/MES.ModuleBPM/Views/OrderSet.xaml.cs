using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// OrderSet.xaml 的交互逻辑
    /// </summary>
    public partial class OrderSet : UserControl
    {
        public OrderSet()
        {
            InitializeComponent();
            this.DataContext = new OrderSetViewModel();
        }
    }
}
