using System.Windows.Controls;

namespace MES.Desktop
{
    /// <summary>
    /// V_Menu.xaml 的交互逻辑
    /// </summary>
    public partial class V_Menu : UserControl
    {
        public V_Menu()
        {
            InitializeComponent();
            this.DataContext = new V_MenuModule();
        }
    }
}
