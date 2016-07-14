using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MES.Desktop
{
   public class V_MenuModule : NotificationObject
    {
        public V_MenuModule()
        {

        }
       
       Popup mypopup; 
       
        public ICommand OpenPopup
        {
            get { return new DelegateCommand<Popup>((popup) =>
            {
                mypopup = popup; mypopup.IsOpen = true; });
            }
        }

       //显示提案上报
        public ICommand ShowPPM_Proposal { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.PPM_Proposal); mypopup.IsOpen = false; }); } }
       //显示提案大厅
       public ICommand ShowPPM_ProposaOverviewl { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.PPM_ProposalOverview); mypopup.IsOpen = false; }); } }

       //显示个人中心
        public ICommand ShowHR_Personal { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.HR_Personal); mypopup.IsOpen = false; }); } }
        public ICommand ShowHR_MasterUser { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.HR_MasterUser); mypopup.IsOpen = false; }); } }
      
       
       //显示日报采集
       public ICommand ShowBPM_Daily { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_Daily); mypopup.IsOpen = false; }); } }
        
       public ICommand ShowBPM_DailyView { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_DailyView); mypopup.IsOpen = false; }); } }

        public ICommand ShowBPM_MonthEfficiency { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.ShowBPM_MonthEfficiency); mypopup.IsOpen = false; }); } }
        //显示工序采集
        public ICommand ShowBPM_FinishedEntering { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_FinishedEntering); mypopup.IsOpen = false; }); } }
       //显示工单进度
       public ICommand ShowBPM_OrderFormShow { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_OrderFormShow); mypopup.IsOpen = false; }); } } 

       //显示打印模块 
        public ICommand ShowMainViewPrint  { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.Print_MainViewPrint); mypopup.IsOpen = false; }); } }
       //显示重打
        public ICommand ShowAnewPrint { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.Print_AnewPrint); mypopup.IsOpen = false; }); } }

       //显示工单设置
        public ICommand ShowBPM_OrderSet { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_OrderSet); mypopup.IsOpen = false; }); } }
        //显示工序设置
        public ICommand ShowBPM_ProcessSet { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_ProcessSet); mypopup.IsOpen = false; }); } }

        public ICommand ShowBPM_ProductSet { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_ProductSet); mypopup.IsOpen = false; }); } }

        //显示工序设置
        public ICommand ShowBPM_ProcessTemprateSet { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_ProcessTemprateSet); mypopup.IsOpen = false; }); } }

        public ICommand ShowBPM_OrderOverView { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.BPM_OrderOverView); mypopup.IsOpen = false; }); } }

        public ICommand ShowOQC_CheckBagging { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.OQC_CheckBagging); mypopup.IsOpen = false; }); } }

        public ICommand ShowBPM_UserFlowCardSet { get { return new DelegateCommand(() => { Messenger.Default.Send<object>(null, Common.ShowControl.ShowBPM_UserFlowCardSet); mypopup.IsOpen = false; }); } }
        



    }
} 
 