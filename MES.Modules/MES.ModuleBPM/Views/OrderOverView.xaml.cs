using System.Windows;
using System.Windows.Controls;


namespace MES.ModuleBPM
{
    /// <summary>
    /// OrderOverView.xaml 的交互逻辑
    /// </summary>
    public partial class OrderOverView : UserControl
    {
        OrderOverViewViewModel vm = new OrderOverViewViewModel();
        public OrderOverView()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.WidthView.onWorkHours_Changed();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.WidthView.onUser_Changed();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            vm.WidthView.onOrderChanged();
        }
    }
}
