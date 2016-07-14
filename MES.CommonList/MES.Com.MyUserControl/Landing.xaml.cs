using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace MES.Com.MyUserControl
{
    /// <summary>
    /// Landing.xaml 的交互逻辑
    /// </summary>
    public partial class Landing : Window
    {
        public Landing()
        {
            InitializeComponent();
        }
                  /* 使用方法
          Control.Loading load = new Control.Loading(Test);
          load.Msg = "稍等。。。";
          load.Start();

         
          private void Test()
          {
              System.Threading.Thread.Sleep(15000);
          }
         */
        public Action WorkMethod;

        private string _msg = "正在加载...";
        private string _message = string.Empty;
        private Storyboard _storyboard;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            this._storyboard.Begin(this.image, true);
        }

        public void Stop()
        {
            base.Dispatcher.BeginInvoke(new Action(() =>
            {
                this._storyboard.Pause(this.image);
                base.Visibility = System.Windows.Visibility.Collapsed;
            }));
        }

        public Landing(Action workMethod)
        {
            InitializeComponent();
            this._storyboard = (base.Resources["waiting"] as Storyboard);

            this.lblMsg.Content = this.Msg;
            this.WorkMethod = workMethod;
        }

        public void Start()
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.DoWork += (obj, e) =>
                {
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
                    {
                       
                        this.WorkMethod();
                    });    
                  
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    this.Close();
                };
                bw.RunWorkerAsync();
            }
            this.ShowDialog();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}