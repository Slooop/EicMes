using MES.Desktop.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace MES.Desktop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MyMessage Messageserver = new MyMessage();                            //启动消息管理器
      
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this.Close);
            Messageserver.MyDocumentPane = this.firstDocumentPane;
        }

        //移动窗体
        private void grd_Head_MouseDown(object sender, MouseButtonEventArgs e) { DragMove();}

       
    }
}
