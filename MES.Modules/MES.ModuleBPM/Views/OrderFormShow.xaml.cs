using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// OrderFormShow.xaml 的交互逻辑
    /// </summary>
    public partial class OrderFormShow : UserControl
    {
        public OrderFormShow()
        {
            InitializeComponent();
            this.DataContext = new OrderFormShowViewModule();
        }
    }
}
