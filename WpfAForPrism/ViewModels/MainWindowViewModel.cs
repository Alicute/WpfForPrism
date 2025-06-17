using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using WpfAForPrism.Views;

namespace WpfAForPrism.ViewModels
{
     public class MainWindowViewModel : BindableBase
    {

        /// <summary>
        /// 区域管理
        /// </summary>
        private readonly  IRegionManager RegionManager;


        private RegionNavigationJournal Journal;
        public DelegateCommand<string> ShowContentCmm { get; set; }
        public DelegateCommand BackCmm { get; set; }
        public DelegateCommand<string> ShowDialogCmm { get; set; }

        /// <summary>
        /// 对话框服务
        /// </summary>
        private readonly  IDialogService DialogService;

        public MainWindowViewModel(IRegionManager _RegionManager, IDialogService dialogService)
        {

            RegionManager = _RegionManager;
            DialogService = dialogService;
            ShowContentCmm = new DelegateCommand<string>(ShowcContentFunc);
            ShowDialogCmm  =   new DelegateCommand<string>(ShowDialogFunc);
            BackCmm = new DelegateCommand(Back);
        }
        private void Back() {

            if (Journal!=null&&Journal.CanGoBack) { 
            
            Journal.GoBack();
            }

        }
        private void ShowcContentFunc(string viewName) {




            // 给命令换一个，之前是导航，现在换成对话框
            NavigationParameters paras = new NavigationParameters();
            paras.Add("MsgA", "大家好，我是A");
            RegionManager.Regions["ContentRegion"].RequestNavigate(viewName, callback =>
            {
                Journal = (RegionNavigationJournal)callback.Context.NavigationService.Journal;
            }, paras);



        }


        private void ShowDialogFunc(string viewName) 
        {

            DialogParameters paras = new DialogParameters();
            paras.Add("Title","动态传递的标题");
            paras.Add("para1","业务参数1");
            paras.Add("para2", "业务参数2");
            DialogService.ShowDialog(viewName,paras, 
            callback => { 

                if(callback.Result == ButtonResult.OK)
                {

                    string r1 = callback.Parameters.GetValue<string>("result1");
                    string r2 = callback.Parameters.GetValue<string>("result2");
                    MessageBox.Show($"结果1：{r1}，结果2：{r2}");
                }
            });

        }

    }
	
}
