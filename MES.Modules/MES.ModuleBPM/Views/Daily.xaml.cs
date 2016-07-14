using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// Daily.xaml 的交互逻辑
    /// </summary>
    public partial class Daily : UserControl
    {
        public Daily()
        {
            InitializeComponent();
            DailyViewModule vm = new DailyViewModule(grd_Control);
            this.DataContext = vm;
        }
    }
}