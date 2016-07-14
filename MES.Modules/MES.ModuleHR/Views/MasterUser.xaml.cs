using System.Windows.Controls;

namespace MES.ModuleHR
{
    /// <summary>
    /// MasterUser.xaml 的交互逻辑
    /// </summary>
    public partial class MasterUser : UserControl
    {
        public MasterUser()
        {
            InitializeComponent();
            this.DataContext = new MasterUserViewModule();
        }
    }
}
