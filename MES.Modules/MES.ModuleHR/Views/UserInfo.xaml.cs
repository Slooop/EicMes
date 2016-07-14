using System.Windows.Controls;

namespace MES.ModuleHR
{
    /// <summary>
    /// UserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
            this.DataContext = new UserInfoViewModel();
        }
        
    }
}
