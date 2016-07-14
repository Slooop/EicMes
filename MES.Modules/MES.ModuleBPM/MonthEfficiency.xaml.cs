using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MES.ModuleBPM
{
    /// <summary>
    /// MonthEfficiency.xaml 的交互逻辑
    /// </summary>
    public partial class MonthEfficiency : UserControl
    {
        public MonthEfficiency()
        {
            InitializeComponent();
            this.DataContext = new MonthEfficiencyViewModel();
        }
    }
}
