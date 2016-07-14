using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// ProductSet.xaml 的交互逻辑
    /// </summary>
    public partial class ProductSet : UserControl
    {
        public ProductSet()
        {
            InitializeComponent();
            DataContext = new ProductSet_ViewModel();
        }
    }
}
