using System;
using System.Windows.Controls;

namespace MES.ModuleBPM
{
    /// <summary>
    /// FinishedEnter.xaml 的交互逻辑
    /// </summary>
    public partial class FinishedEnter : UserControl
    {
        public FinishedEnter()
        {
            InitializeComponent();
            this.DataContext = new FinishedEnterViewModel();
            this.datagrid.LoadingRow += new EventHandler<DataGridRowEventArgs>(this.DataGridSoftware_LoadingRow);
        }
        private void DataGridSoftware_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
