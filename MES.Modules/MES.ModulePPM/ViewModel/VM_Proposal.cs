using GalaSoft.MvvmLight;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;


namespace MES.ModulePPM
{
    class VM_Proposal : ViewModelBase 
    {
       
        
        private MES.Server.Model.PPM_Proposal module = new Server.Model.PPM_Proposal();

        public MES.Server.Model.PPM_Proposal Module
        {
            get { return module; }
            set
            {
                module = value;
                this.RaisePropertyChanged("Module");
            }
        }


        MES.Server.BLL.HR_User user = new Server.BLL.HR_User();

        public string UserID
        {
            get { return module.Up_User; }
            set
            {
                module.Up_User = value;
                this.RaisePropertyChanged("UserID");
                if (value.Length > 0)
                    if (user.GetModel(value) != null)
                        UserName = user.GetModel(value).Name;
                    else
                    {
                        ZhuifengLib.MessageShow.Message.MessageInfo("未找到用户");
                        UserName = "";
                    }

                else
                {
                    ZhuifengLib.MessageShow.Message.MessageInfo("未找到用户");
                    UserName = "";

                }
            }
        }

        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        public ICommand Add
        {
            get { return new DelegateCommand(() => 
            {
                MES.Server.BLL.PPM_Proposal bal = new Server.BLL.PPM_Proposal();
                if (bal.Add(module))
                {
                    Module.U_Content = null;
                    Module.Title = null;
                    ZhuifengLib.MessageShow.Message.MessageInfo("上报完成！");
                } 
                else
                    ZhuifengLib.MessageShow.Message.MessageInfo("信息不完整！");
            }); } 
        }
       
        
        
    }
}
