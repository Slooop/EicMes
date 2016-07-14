using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using ZhuifengLib;

namespace MES.ModuleHR
{
    internal class MasterUserViewModule : ViewModelBase
    {
        public MasterUserViewModule()
        {
            UserInfo.Model = new Server.Model.HR_User();
            MES.Server.BLL.SYS_TypeList bll = new Server.BLL.SYS_TypeList();
            Factor = bll.GetModelList("Module = 'HR' AND Type='TB'");
        }

        private MES.Server.BLL.HR_User bll = new Server.BLL.HR_User();

        private UserInfoViewModel userinfo = new UserInfoViewModel();

        public UserInfoViewModel UserInfo
        {
            get { return userinfo; }
            set
            {
                userinfo = value;
                this.RaisePropertyChanged("UserInfo");
            }
        }

        private List<MES.Server.Model.HR_User> lsuser;

        public List<MES.Server.Model.HR_User> LsUser
        {
            get { return lsuser; }
            set
            {
                lsuser = value;
                this.RaisePropertyChanged("LsUser");
            }
        }

        private int myHegit = 0;

        public int MyHegit
        {
            get { return myHegit; }
            set
            {
                myHegit = value;
                this.RaisePropertyChanged("MyHegit");
            }
        }

        private List<MES.Server.Model.SYS_TypeList> factor;

        public List<MES.Server.Model.SYS_TypeList> Factor
        {
            get { return factor; }
            set
            {
                factor = value;
                this.RaisePropertyChanged("Factor");
            }
        }

        private MES.Server.Model.SYS_TypeList selectfactor = new Server.Model.SYS_TypeList();

        public MES.Server.Model.SYS_TypeList SelectFacrot
        {
            get { return selectfactor; }
            set
            {
                selectfactor = value;
                this.RaisePropertyChanged("SelectFacrot");
            }
        }

        private string serachValue;

        public string SerachValue
        {
            get { return serachValue; }
            set
            {
                serachValue = value;
                this.RaisePropertyChanged("SerachValue");
            }
        }

        public ICommand Edit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MyHegit = 328;
                });
            }
        }

        public ICommand Search
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        if (selectfactor != null && !SerachValue.IsNullOrEmpty())
                            LsUser = bll.GetModelList(selectfactor.Remarks + "= '" + SerachValue + "'");
                        else
                            LsUser = bll.GetModelList("");
                        UserInfo = new UserInfoViewModel();
                    }
                    catch
                    {
                        LsUser = bll.GetModelList("");
                        UserInfo = new UserInfoViewModel();
                    }
                });
            }
        }

        public ICommand InPut          //从Excel中导入
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    // @"D:\模板\ProcessTemplate.xlsx"
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = "D:\\";//注意这里写路径时要用c:\\而不是c:\
                    openFileDialog.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        LsUser = bll.GetModelList_forExcel(openFileDialog.FileName);
                        Thread td = new Thread(() =>
                        {
                            foreach (MES.Server.Model.HR_User user in LsUser)
                                bll.Add(user);
                            ZhuifengLib.MessageShow.Message.MessageInfo("导入完成！");
                        });
                        td.IsBackground = true;
                        td.Start();
                    }
                });
            }
        }

        /// <summary>
        /// 人员转班导入
        /// </summary>
        public GalaSoft.MvvmLight.Command.RelayCommand InPutUserChangeClass => new GalaSoft.MvvmLight.Command.RelayCommand(() =>
        {
            // @"D:\模板\ProcessTemplate.xlsx"
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Thread td = new Thread(() =>
                //{
                //    changeuserList= bll.UserChangeClass(LsUser);
                //    ZhuifengLib.MessageShow.Message.MessageInfo("导入完成！");
                //});
                //td.IsBackground = true;
                //td.Start();

                /*td.Join()*/
                ;

                MES.Com.MyUserControl.Landing load = new MES.Com.MyUserControl.Landing(() =>
                {
                    LsUser = bll.UserChangeClass(bll.GetModelList_forExcel(openFileDialog.FileName));
                    ZhuifengLib.MessageShow.Message.MessageInfo("导入完成！");
                });
                load.Msg = "稍等。。。";
                load.Start();
            }
        });

        public ICommand Export     //导出至Excel
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LsUser.ExportToExcel(true, 1);
                });
            }
        }
    }
}