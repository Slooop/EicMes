using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MES.ModuleBPM.ViewModel
{
    public class UserFlowCard : ViewModelBase
    {
        

        private Lm.App.Eic.Mes.EF.Business.UserFlowCard.ModelList_obs flowcardList = new Lm.App.Eic.Mes.EF.Business.UserFlowCard.ModelList_obs();
        /// <summary>
        /// 
        /// </summary>
        public Lm.App.Eic.Mes.EF.Business.UserFlowCard.ModelList_obs FlowCardList
        {
            get { return flowcardList; }
            set
            {
                flowcardList = value;
                this.RaisePropertyChanged(nameof(FlowCardList));
            }
        }



        private Lm.App.Eic.Mes.EF.Business.User user = new Lm.App.Eic.Mes.EF.Business.User();
        /// <summary>
        /// 用户
        /// </summary>
        public Lm.App.Eic.Mes.EF.Business.User User
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged(nameof(User));
            }
        }




        /// <summary>
        /// 输入用户工号
        /// </summary>
        public RelayCommand<string> InpuJobNum => new RelayCommand<string>((str) =>
        {
            User = new Lm.App.Eic.Mes.EF.Business.User(str);
        });


        /// <summary>
        /// 输入流程卡号
        /// </summary>
        public RelayCommand<string> InputFlowCard => new RelayCommand<string>((str) =>
        {
            FlowCardList.Add(new Lm.App.Eic.Mes.EF.Model.BPM_UserFlowCard() {
                 Job_Num=User.Detailed.Job_Num
                 , FlowCard= str
            });
        });


        /// <summary>
        /// 保存到数据
        /// </summary>
        public RelayCommand SavaToDbCommand => new RelayCommand(() =>
        {
            Lm.App.Eic.Mes.EF.Business.UserFlowCard ttt = new Lm.App.Eic.Mes.EF.Business.UserFlowCard();
            ttt.Add(FlowCardList);
            FlowCardList.Clear();
        });

       





    }
}
