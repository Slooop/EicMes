using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace MES.ModuleBPM
{
    class PrintFlowViewModel : ViewModelBase
    {
        /*流程卡生成 和打印
         Strat InPut（工单单号)
	     1.从数据库中调取该工单的（产品图号）
	     2.根据产品图号（获取工序信息,筛选出需要管控的工序）
	     3.根据要管控的工序生成待打印的管制流程卡
	     4.调用BT打印第三方DLL进行标签打印（并生成打印记录）
	       END
         */

       
        MES.Server.BLL.BPM_Order bll = new Server.BLL.BPM_Order();

        #region Property
        private string orderid ="512-1504286";
        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID
        {
            get { return orderid; }
            set
            {
                orderid = value;
                this.RaisePropertyChanged("OrderID");
            }
        }


        private MES.Server.Model.BPM_Order order;
        /// <summary>
        /// 工单
        /// </summary>
        public MES.Server.Model.BPM_Order Order
        {
            get { return order;}
            set
            {
                order = value; 
                this.RaisePropertyChanged("Order");
              
            }
        }


        private List<MES.Server.Model.BPM_ProductTemplate> lsControlFlow;
        /// <summary>
        /// 管控工序列表
        /// </summary>
        public List<MES.Server.Model.BPM_ProductTemplate> LsControlFlow
        {
            get { return lsControlFlow; }
            set
            {
                lsControlFlow = value;
                this.RaisePropertyChanged("LsControlFlow");
            }
        }

        

        #endregion


        #region Command
        /// <summary>
        /// 
        /// </summary> 
        public ICommand Test 
        {
            get { return new DelegateCommand(() => { Order = bll.GetModel(orderid);});}
        }

     

        #endregion


        #region Methods
        

      

        //根据工单生成流程卡编号
        private List<string> FlowList(string OrderID)
        {
            return null;
        }
        #endregion
    }
}
