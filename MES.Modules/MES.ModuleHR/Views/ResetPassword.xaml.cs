using System.Windows;

namespace MES.ModuleHR
{
    /// <summary>
    /// ResetPassword.xaml 的交互逻辑
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }



        //修改密码
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_OldPasd.Text == ((MES.Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo).Password)
            {
                ((MES.Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo).Password = tb_NewPasd.Text;
                MES.Server.BLL.HR_User bll = new Server.BLL.HR_User();
                bll.Add((MES.Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo);
                ZhuifengLib.MessageShow.Message.MessageInfo("密码修改成功\r\n点击确定退出!");
                this.Close();
            }
            else { ZhuifengLib.MessageShow.Message.MessageInfo("密码验证错误，请重新输入旧密码！"); tb_OldPasd.SelectAll(); }
        }

        //取消
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
