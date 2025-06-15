using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Mvvm;
using Prism.Regions;
using WpfAForPrism.Views;

namespace WpfAForPrism.ViewModels
{
     public class MainWindowViewModel : BindableBase
    {


        private readonly  IRegionManager RegionManager;
        private RegionNavigationJournal Journal;
        public DelegateCommand<string> ShowContentCmm { get; set; }
        public DelegateCommand BackCmm { get; set; }


        public MainWindowViewModel(IRegionManager _RegionManager)
        {

             RegionManager = _RegionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowcContentFunc);
           
            BackCmm = new DelegateCommand(Back);
        }
        private void Back() {

            if (Journal!=null&&Journal.CanGoBack) { 
            
            Journal.GoBack();
            }

        }
        private void ShowcContentFunc(string viewName) {


            NavigationParameters   paras    = new NavigationParameters();
            paras.Add("MsgA", "大家好，我是A");
            RegionManager.Regions["ContentRegion"].RequestNavigate(viewName,callback=> { 
                Journal = (RegionNavigationJournal)callback.Context.NavigationService.Journal;
            }, paras);
        }
        
    }
	
}
