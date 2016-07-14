using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;

namespace MES.ModuleHR
{
    class PersonalViewModel : ViewModelBase
    {


        public ICommand ResetPassWord
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ResetPassword f = new ResetPassword();
                    f.ShowDialog();
                });
            }
        }
        
    }
}
