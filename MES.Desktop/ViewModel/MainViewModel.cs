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
      
        private Action closeAction; //�ر�
       
        private System.Windows.WindowState windowstate;
         
        /// <summary>
        /// ����״̬
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

        //�رմ���
        public ICommand Close
        {
            get { return new DelegateCommand(() => { this.closeAction.Invoke(); }); }
        }

        //��С������
        public ICommand fromMin
        {
            get { return new DelegateCommand(() => { this.Windowstate = System.Windows.WindowState.Minimized; }); }
        }
        private bool isMax = false;
        //��󻯴���
        public ICommand fromMax
        {
            get { return new DelegateCommand(() => { if (!isMax) { this.Windowstate = System.Windows.WindowState.Maximized; } 
            else { this.Windowstate = System.Windows.WindowState.Normal; } isMax = !isMax; }); }
        }
        /// <summary>
        /// �û���Ϣ
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

        //��ʾ�ձ��ɼ�
        public ICommand ShowBPM_Daily { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, MES.Common.ShowControl.BPM_Daily); }); } }

        //��ʾ����ɼ�
        public ICommand ShowBPM_FinishedEntering { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, MES.Common.ShowControl.BPM_FinishedEntering); }); } }
    }
}