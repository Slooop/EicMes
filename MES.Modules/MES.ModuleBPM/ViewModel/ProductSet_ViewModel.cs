using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using msg = ZhuifengLib.MessageShow.Message;
using ZhuifengLib;
using System.Threading;
using MES.Server.Model;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using GalaSoft.MvvmLight.Command;

namespace MES.ModuleBPM
{
    class ProductSet_ViewModel :ViewModelBase
    {

        public ProductSet_ViewModel()
        {

        }

        public List<string> ProcessTemplateNameList => Business.BpmHelper.ProductTemplate.GetPTName();

        string productID;

        private List<BPM_ProductTemplate> processList;

        public List<BPM_ProductTemplate> ProcessList
        {
            get { return processList; }
            set
            {
                processList = value;
                this.RaisePropertyChanged("ProcessList");
            }
        }



        BPM_Order order = new BPM_Order();

        private string orderid;
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

        private string productInfo;

        public string ProductInfo
        {
            get { return productInfo; }
            set
            {
                productInfo = value;
                this.RaisePropertyChanged("ProductInfo");
            }
        }


        private string processTemprateName;
        /// <summary>
        /// 模板名称
        /// </summary>
        public string ProcessTemprateName
        {
            get { return processTemprateName; }
            set
            {
                processTemprateName = value;
                this.RaisePropertyChanged("ProcessTemprateName");
                ProcessList = Business.BpmHelper.ProductTemplate.GetProcessTemprate(processTemprateName);
            }
        }
        
        /// <summary>
        /// 获取信息
        /// </summary>
        public RelayCommand GetInfoForDbCommand => new RelayCommand(() =>
        {
            order = Business.BpmHelper.Order.GetModel(OrderID);
            if (!OrderID.IsNullOrEmpty() && order != null && order.Product != null)
            {
                ProductInfo = string.Format("品号：{0} 品名：{1} 规格：{2}", order.Product.ProductID, order.Product.Name, order.Product.Spec);
                productID = order.ProductID;
                ProcessTemprateName = order.Product.PtID;
            }
            else msg.MessageInfo("未找到相应的信息！");
        });


    }



}
