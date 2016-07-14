using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MES.Desktop
{
    class LandingModule : NotificationObject
    {
        /// <summary>
        /// 窗体关闭方法
        /// </summary>
        private Action closeAction;

        /// <summary>
        /// 初始化ViewModule类
        /// </summary>
        /// <param name="closeAction">窗体关闭方法</param>
        public LandingModule(Action closeAction)
        {
            this.closeAction = closeAction;
        }


        private string tipinfo;

        public string TipInfo
        {
            get { return tipinfo; }
            set
            {
                tipinfo = value;
                this.RaisePropertyChanged("TipInfo");
            }
        }
        
        private string name;
        private string password;

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                TipInfo = "";
                name = value;
                RaisePropertyChanged("Name");
            }
        }
      
        
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            get { return password; }
            set
            {
               password = value;
               this.RaisePropertyChanged("PassWord");
            }
        }

        #region CloseBtn
        /// <summary>
        /// 关闭窗体命令
        /// </summary>
        public ICommand Close
        {
            get { return new DelegateCommand(() => { this.closeAction.Invoke(); }); }
        }

        /// <summary>
        /// 鼠标移入处理
        /// </summary>
        public ICommand Close_MouseLeave
        {
            get { return new DelegateCommand<Label>(Close_mouse); }
        }

        /// <summary>
        /// 鼠标按下处理
        /// </summary>
        public ICommand Close_MouseEnter
        {
            get { return new DelegateCommand<Label>(Close_mouseEnter); }
        }


        private void Close_mouse(Label tem)
        {
            try
            {
                //pack://application:,,,/你的dll名称;component/文件夹/1.jpg 
                Uri uri = new Uri("pack://application:,,,/MES.Resource.Image;Component/ImageList/cancel.png", UriKind.RelativeOrAbsolute);
                ImageBrush berriesBrush = new ImageBrush();
                berriesBrush.ImageSource = new BitmapImage(uri);

                tem.Background = berriesBrush;
            }
            catch (Exception ef)
            {
                MessageBox.Show("出现错误！：" + ef.ToString());
            }
        }

        private void Close_mouseEnter(Label tem)
        {
            try
            {
                //pack://application:,,,/你的dll名称;component/文件夹/1.jpg 
                Uri uri = new Uri("pack://application:,,,/MES.Resource.Image;Component/ImageList/cancel_1.png", UriKind.RelativeOrAbsolute);
                ImageBrush berriesBrush = new ImageBrush();
                berriesBrush.ImageSource = new BitmapImage(uri);

                tem.Background = berriesBrush;
            }
            catch (Exception ef)
            {
                MessageBox.Show("出现错误！：" + ef.ToString());
            }
        }

        #endregion

        #region LoginBtn
        /// <summary>
        /// 登陆按钮 鼠标移入处理
        /// </summary>
        public ICommand Login_MouseLeave
        {
            get { return new DelegateCommand<Button>(Login_Mouse); }
        }

        /// <summary>
        /// 登陆按钮 鼠标按下处理
        /// </summary>
        public ICommand Login_MouseEnter
        {
            get { return new DelegateCommand<Button>(login_MouseEnter); }
        }

        private void Login_Mouse(Button btn)
        {
            Label lb1 = (Label)btn.Template.FindName("tips_for_login", btn);
            lb1.Foreground = new SolidColorBrush(Colors.White);
        }

        private void login_MouseEnter(Button btn)
        {
            Label lb1 = (Label)btn.Template.FindName("tips_for_login", btn);
            lb1.Foreground = new SolidColorBrush(Colors.Red); 
        }
        #endregion

        #region KeyEnter
        public ICommand PasswordKeyCommand  
        {
            get { return new DelegateCommand<PasswordBox>((pbr) => { PassWord = pbr.Password;  UserLand(); }); }
        }

        public ICommand UserKeyCommand
        {
            get { return new DelegateCommand<PasswordBox>((pbr) => { pbr.Focus(); }); }
        }
        #endregion



        /// <summary>
        /// 登陆
        /// </summary>
        public ICommand Land
        {
            get
            {
                return new DelegateCommand<PasswordBox>((pbr) => { PassWord = pbr.Password; UserLand(); });
            }
        }

        /// <summary>
        /// 验证用户登陆
        /// </summary>
        private void UserLand()
        {
            MES.Server.BLL.HR_User uer = new Server.BLL.HR_User();
           // ObservableCollection<MES.Server.Model.HR_User> _userList = new ObservableCollection<Server.Model.HR_User>(uer.GetModelList(""));
            if (uer.Exists(name, password))
            {
                Messenger.Default.Send<MES.Server.Model.HR_User>(uer.GetModel(name), "LandOK");
                this.closeAction.Invoke();
            }
            else
                TipInfo = "用户名或密码错误！";
        }


        public ICommand MoveFrom
        {
            get { return new DelegateCommand(() => {  }); }
        }


    }
}
