using System.Windows.Controls;

namespace MES.ModuleHR
{
    /// <summary>
    /// Interaction logic for HR_Personal.xaml
    /// </summary>
    public partial class HR_Personal : UserControl
    {
        public HR_Personal()
        {
            InitializeComponent();
            this.DataContext = new PersonalViewModel();
        }
    }
}
