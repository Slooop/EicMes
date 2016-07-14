using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// ProcessSet.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessSet : UserControl
    {
        public ProcessSet()
        {
            InitializeComponent();
            this.DataContext = new ProcessSetViewModel();
        }
    }
}
