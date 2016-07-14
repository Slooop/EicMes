using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.Toolkit;

namespace MES.Desktop
{
    /// <summary>
    /// 消息管理器
    /// </summary>
    public class MyMessage : ViewModelBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public MyMessage() { DefaultMessage(); }


        private static LayoutDocumentPane myDocumentPane;

        //内容显示区域
        public LayoutDocumentPane MyDocumentPane
        {
            get { return myDocumentPane; }
            set
            {
                myDocumentPane = value;
                this.RaisePropertyChanged("MyDocumentPane");
            }
        }
        
        //注册消息
        private void DefaultMessage()
        {
            Messenger.Default.Unregister(this);
            Messenger.Default.Register<string>(this, Common.ShowControl.ShowMessage, (p) => { MessageBox.Show(p); }); //显示消息
           
            /*************** PPM ***************/
            Messenger.Default.Register<object>(this, Common.ShowControl.HR_Personal, (obj) => { ShowUserControl("个人中心", new ModuleHR.HR_Personal()); });
            Messenger.Default.Register<object>(this, Common.ShowControl.HR_MasterUser, (obj) => { ShowUserControl("人员管理", new ModuleHR.MasterUser()); });
           
           
            /*************** BPM ***************/
           

            Messenger.Default.Register<object>(this, Common.ShowControl.BPM_OrderSet, ((obj) => { ShowUserControl("工单设置", new ModuleBPM.OrderSet()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.BPM_Daily, ((obj) => { ShowUserControl("日报录入", new ModuleBPM.Daily()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.BPM_DailyView, ((obj) => { ShowUserControl("日报管理", new ModuleBPM.DailyView()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.BPM_ProcessSet, ((obj) => { ShowUserControl("工序设置", new ModuleBPM.ProcessSet()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.BPM_ProcessTemprateSet, ((obj) => { ShowUserControl("模板设置", new ModuleBPM.ProcessTemprateSet()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.BPM_OrderOverView, ((obj) => { ShowUserControl("工单执行", new ModuleBPM.OrderOverView()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.ShowBPM_MonthEfficiency, ((obj) => { ShowUserControl("月效率", new ModuleBPM.MonthEfficiency()); }));
            Messenger.Default.Register<object>(this, Common.ShowControl.ShowBPM_UserFlowCardSet, ((obj) => { ShowUserControl("流程卡绑定", new ModuleBPM.UserFlowCard()); }));

         
        }

      
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="usercontrol">要显示的窗体</param>
        private void ShowUserControl(string title,UserControl usercontrol)
        {
            try
            {
                LayoutDocument newDocument = new LayoutDocument();
                newDocument.Title = title;
                newDocument.IsActive = true;
                newDocument.Content = usercontrol;
                myDocumentPane.Children.Add(newDocument);
            }
            catch (Exception ex)
            {
               ZhuifengLib.MessageShow.Message.MessageErr("未能加载指定界面，请重试或联系管理员！\r\n"+ex.Message);
            }
          
        }

       
    }
}
