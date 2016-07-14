using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace MES.ModulePPM
{
    class VM_ProposalOverview : ViewModelBase
    {
        public VM_ProposalOverview()
        {
            LsProposal = bll_Proposal.GetModelList("");
        }

        MES.Server.BLL.PPM_Proposal bll_Proposal = new Server.BLL.PPM_Proposal();

        private List<MES.Server.Model.PPM_Proposal> lsProposal;
        public List<MES.Server.Model.PPM_Proposal> LsProposal                                         //列表
        {
            get { return lsProposal; }
            set
            {
                lsProposal = value;
                this.RaisePropertyChanged("LsProposal");
            }
        }



        
    }
}
