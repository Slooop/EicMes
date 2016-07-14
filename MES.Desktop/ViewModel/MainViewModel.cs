using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;

namespace MES.Desktop.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        
        public MainViewModel(Action close)
        {
            this.closeAction = close;
            Windowstate = System.Windows.WindowState.Maximized;
            this.isMax = false;
            User = ((MES.Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo);
        }

        private MES.Server.Model.HR_User user;
      
        private Action closeAction; //关闭
       
        private System.Windows.WindowState windowstate;
         
        /// <summary>
        /// 窗体状态
        /// </summary>
        public System.Windows.WindowState Windowstate
        {
            get { return windowstate; }
            set
            {
                windowstate = value;
                this.RaisePropertyChanged("Windowstate");
            }
        }

        //关闭窗体
        public ICommand Close
        {
            get { return new DelegateCommand(() => { this.closeAction.Invoke(); }); }
        }

        //最小化窗体
        public ICommand fromMin
        {
            get { return new DelegateCommand(() => { this.Windowstate = System.Windows.WindowState.Minimized; }); }
        }
        private bool isMax = false;
        //最大化窗体
        public ICommand fromMax
        {
            get { return new DelegateCommand(() => { if (!isMax) { this.Windowstate = System.Windows.WindowState.Maximized; } 
            else { this.Windowstate = System.Windows.WindowState.Normal; } isMax = !isMax; }); }
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        public MES.Server.Model.HR_User User
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged("User");
            }
        }

        public ICommand ShowPPM_HR_Personal { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, MES.Common.ShowControl.HR_Personal); }); } }

        //显示日报采集
        public ICommand ShowBPM_Daily { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, MES.Common.ShowControl.BPM_Daily); }); } }

        //显示工序采集
        public ICommand ShowBPM_FinishedEntering { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, MES.Common.ShowControl.BPM_FinishedEntering); }); } }
    }
}