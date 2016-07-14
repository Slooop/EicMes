using GalaSoft.MvvmLight;
using System.Collections.Generic;
using MES.Server.Model;
namespace MES.ModuleOQC
{
    class CheckBagging_ViewModel : ViewModelBase
    {
        private string orderID = string.Empty;
        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID
        {
            get { return orderID; }
            set
            {
                
                orderID = value;
                Order = Business.BpmHelper.Order.GetModel(orderID);
                this.RaisePropertyChanged("OrderID");
            }
        }

        private string serialNumber = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SerialNumber
        {
            get { return serialNumber; }
            set
            {
                serialNumber = value;
                TestData_3D = Business.OqcHelper.User3dTestGood.GetModelList("SN='"+ serialNumber + "'");
                TestDate_Exfo = Business.OqcHelper.UserJdsTestGood.GetModelList("SN='" + serialNumber + "'");
                this.RaisePropertyChanged("SerialNumber");
            }
        }

        private BPM_Order order ;
        /// <summary>
        /// 工单信息
        /// </summary>
        public BPM_Order Order
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }

        private List<User_3D_Test_Good> testData_3D = new List<User_3D_Test_Good>();
        /// <summary>
        /// 3D数据
        /// </summary>
        public List<User_3D_Test_Good> TestData_3D
        {
            get { return testData_3D; }
            set
            {
                testData_3D = value;
                this.RaisePropertyChanged("TestData_3D");
            }
        }

        private List<User_JDS_Test_Good> testDate_Exfo = new List<User_JDS_Test_Good>();
        /// <summary>
        /// Exfo数据
        /// </summary>
        public List<User_JDS_Test_Good> TestDate_Exfo
        {
            get { return testDate_Exfo; }
            set
            {
                testDate_Exfo = value;
                this.RaisePropertyChanged("TestDate_Exfo");
            }
        }



        /// <summary>
        /// 验证条码是否OK
        /// </summary>
        void VF_serialNumber()
        {

        }



    }


   
}
