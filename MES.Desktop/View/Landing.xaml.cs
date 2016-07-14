using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace MES.Desktop
{
    /// <summary>
    /// Landing.xaml 的交互逻辑
    /// </summary>
    public partial class Landing : Window
    {
        public Landing()
        {
            InitializeComponent();
            this.DataContext = new LandingModule(this.Close);
            this.txb_UserID.Focus();
            Messenger.Default.Unregister(this);
            Messenger.Default.Register<MES.Server.Model.HR_User>(this, "LandOK", ShowMain);          //显示主窗体
        }
        //显示主窗体
        private void ShowMain(MES.Server.Model.HR_User user)
        {
            MES.Common.UserInfo.MyUserInfo = user;
            MainWindow f = new MainWindow();
            f.Show();
            Messenger.Default.Send<object>("", "ShowHome"); //发送打开Home页消息
        }

       // MyMessage Message = new MyMessage();
      
     
    }
}
