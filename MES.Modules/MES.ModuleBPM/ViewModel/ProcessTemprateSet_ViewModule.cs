using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ZhuifengLib;
using msg = ZhuifengLib.MessageShow.Message;

namespace MES.ModuleBPM
{
    class ProcessTemprateSetViewModel : ViewModelBase
    {
        public ProcessTemprateSetViewModel()
        {
            //PtNameList = pt_bll.GetPTName();
            //PtNameList.Sort();
        }

        private List<MES.Server.Model.BPM_Product> lsProduct;
        public List<MES.Server.Model.BPM_Product> LsProduct                                           //产品列表
        {
            get { return lsProduct; }
            set
            {
                lsProduct = value;
                this.RaisePropertyChanged("LsProduct");
            }
        }

        private List<MES.Server.Model.BPM_ProductTemplate> lsPt;
        public List<MES.Server.Model.BPM_ProductTemplate> LsPt                                      //所选工序模板中的工序列表
        {
            get { return lsPt; }
            set
            {
                lsPt = value;
                this.RaisePropertyChanged("LsPt");
            }
        }

        private List<string> _ptNameList;
        public List<string> PtNameList                                                              //模板名称列表
        {
            get { return _ptNameList; }
            set
            {
                value.Sort();
                _ptNameList = value;
                this.RaisePropertyChanged("PtList");
            }
        }

        private List<string> workShopList = new List<string>() {"跳线","散件" };
        /// <summary>
        /// 
        /// </summary>
        public List<string> WorkShopList
        {
            get { return workShopList; }
        }

        private string workShop = string.Empty;
        /// <summary>
        /// 车间
        /// </summary>
        public string WorkShop
        {
            get { return workShop; }
            set
            {
                workShop = value;
                var tem = Business.BpmHelper.ProductTemplate.GetPTName("制六部", value);
                tem.Sort();
                PtNameList = tem;
                this.RaisePropertyChanged("WorkShop");
            }
        }



        MES.Server.BLL.BPM_ProductTemplate pt_bll = new Server.BLL.BPM_ProductTemplate();
        MES.Server.BLL.BPM_Product prodult_bll = new Server.BLL.BPM_Product();
       
        private string _ptname;
        public string PtName                                                                  //所选择的模板名称
        {
            get { return _ptname; }
            set
            {
                _ptname = value;
                this.RaisePropertyChanged("SelectPtName");
            }
        }

        /// <summary>
        /// 获取模板工序列表和使用此模板的工序
        /// </summary>
        public ICommand GetPtAndPd 
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LsPt = pt_bll.GetModelList("PtID='" + _ptname + "'");
                    LsProduct = prodult_bll.GetModelList("PtID='" + _ptname + "'");
                });
            }
        }

        #region 模板操作

        public ICommand PtAddCmd                                                                   //编辑
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        MES.Com.MyUserControl.Landing loading = new Com.MyUserControl.Landing(() => {
                            if (lsPt.IsNullOrEmpty())
                            {
                                LsPt.ExportToExcel(@"D:\模板\ProcessTemplate.xlsx", true, 1);
                                System.Diagnostics.Process.Start(@"D:\模板\ProcessTemplate.xlsx");
                                LsPt.Clear();
                            }
                        });
                    }
                    catch(Exception ex) { msg.MessageInfo(ex.Message); }
                  
                });
            }
        }


        public ICommand PtEditCmd                                                                   //编辑
        { 
            get
            {
                return new DelegateCommand(() =>
                {
                    Com.MyUserControl.Landing loading = new Com.MyUserControl.Landing(() => {
                        try
                        {
                            if (lsPt.IsNullOrEmpty())
                            {
                                LsPt.ExportToExcel(@"D:\模板\ProcessTemplate.xlsx", true, 1);
                                System.Diagnostics.Process.Start(@"D:\模板\ProcessTemplate.xlsx");
                                LsPt.Clear();
                            }
                        }catch(System.Exception ex) { MyMessage.MessageInfo(ex.ToString()); }
                       
                    });
                    loading.Start();
                });
            }
        }

        public ICommand PtInPutCmd                                                                  //导入
        { 
            get
            {
                return new DelegateCommand(() =>
                {
                    MES.Com.MyUserControl.Landing loading = new Com.MyUserControl.Landing(() =>
                    {
                        try
                        {
                            List<MES.Server.Model.BPM_ProductTemplate> tempt = pt_bll.GetModelList_forExcel(@"D:\模板\ProcessTemplate.xlsx");
                            PtNameList.Add(tempt[0].PtID);
                            if (LsPt.IsNullOrEmpty()) { PtName = tempt[0].PtID; }
                            LsPt = tempt;
                        }catch (System.Exception ex) { MyMessage.MessageInfo(ex.ToString()); }

                });
                    loading.Start();
                 
                });
            }
        }


        public ICommand PtSaveCmd                                                                   //保存
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (LsPt.IsNullOrEmpty())
                    {
                        pt_bll.Delete(LsPt[0].PtID); //先从数据库中清除该列表
                        foreach (MES.Server.Model.BPM_ProductTemplate pt in LsPt)
                            pt_bll.Add(pt);
                        MyMessage.MessageInfo("添加或更新完成！");
                    }
                });
            }
        }


        public ICommand PtDeleteCmd                                                                   //保存
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (_ptname == null || _ptname.IsNullOrEmpty()) return;
                    if (MyMessage.IsOkMessage("确定要删除此模板麽，删除此模板将会导致调用该模板的产品不可用！"))
                    {
                        pt_bll.Delete(_ptname);
                        foreach (var pd in lsProduct)
                        {
                            pd.PtID = null;
                            prodult_bll.Update(pd);
                        }
                        lsProduct.Clear();
                        LsPt.Clear();
                        MyMessage.MessageInfo("删除成功！");
                    }
                });
            }
        }



        #endregion


        #region 产品操作

        private MES.Server.Model.BPM_Product productModel;
        public MES.Server.Model.BPM_Product ProductModel                        //产品
        {
            get { return productModel; }
            set
            {
                productModel = value;
                this.RaisePropertyChanged("ProductModel");
            }
        }

        private bool isEditProduct = false;
        public bool IsEditProduct                                                 //是否启用编辑
        {
            get { return isEditProduct; }
            set
            {
                isEditProduct = value;
                this.RaisePropertyChanged("IsEditProduct");
            }
        }

        public ICommand ProductAdd                                                 //新增
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (_ptname.IsNullOrEmpty())
                        ZhuifengLib.MyMessage.MessageInfo("请先选择模板！");
                    else
                    {
                        ProductModel = new Server.Model.BPM_Product();
                        IsEditProduct = true;
                    }
                });
            }
        }
        
        public ICommand ProductEdit                                                //编辑产品
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsEditProduct = true;
                });
            }
        }

        public ICommand ProductDelete                                               //删除
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (MyMessage.IsOkMessage("您的操作将删除该记录！\r\n确定要继续执行么？"))
                    {
                        prodult_bll.Delete(ProductModel.ProductID);
                        MyMessage.MessageInfo("操作完成！");
                        LsProduct = prodult_bll.GetModelList("PtID='" + _ptname + "'");
                    }
                       
                });
            }
        }

        public ICommand ProductSava                                                  //保存
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ProductModel.PtID = PtName; //模板等于所选择的模板
                    if (prodult_bll.Add(ProductModel)) ZhuifengLib.MyMessage.MessageInfo("添加或更新成功！");
                    IsEditProduct = false;
                    LsProduct = prodult_bll.GetModelList("PtID='" + _ptname + "'");
                });
            }
        }
        

        #endregion








    }

   
}
