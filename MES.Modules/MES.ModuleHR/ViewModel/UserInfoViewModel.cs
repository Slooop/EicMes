using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;

namespace MES.ModuleHR
{
    class UserInfoViewModel : ViewModelBase
    {
        public UserInfoViewModel(){
            model = (MES.Server.Model.HR_User)MES.Common.UserInfo.MyUserInfo;}

        public UserInfoViewModel(MES.Server.Model.HR_User model)
        {
            this.model = model;
        }

        private MES.Server.BLL.SYS.ListSource option = new MES.Server.BLL.SYS.ListSource();

        public MES.Server.BLL.SYS.ListSource Option
        {
            get { return option; }
            set
            {
                option = value;
                this.RaisePropertyChanged("Option");
            }
        }
        

        /// <summary>
        /// 实体类
        /// </summary>
        private MES.Server.Model.HR_User model;       
        public MES.Server.Model.HR_User Model
        {
            get { return model; }
            set
            {
                model = value;
                this.RaisePropertyChanged("Model");
            }
        }

        /// <summary>
        /// 是否编辑
        /// </summary>
        private bool isEdit = false;
        public bool IsEdit
        {
            get { return isEdit; }
            set
            {
                isEdit = value;
                this.RaisePropertyChanged("IsEdit");
            }
        }



        public ICommand Add
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsEdit = true;
                    Model = new Server.Model.HR_User();
                });
            }
        }
        


        public ICommand Edit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsEdit = true;
                });
            }
        }
        

        /// <summary>
        /// 编辑
        /// </summary>
        public ICommand Sava
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MES.Server.BLL.HR_User bll_hr = new Server.BLL.HR_User();
                    bll_hr.Add(model);
                    IsEdit = false;
                    Model = bll_hr.GetModel(model.Job_Num);
                });
            }
        }
        
        
    }


}
