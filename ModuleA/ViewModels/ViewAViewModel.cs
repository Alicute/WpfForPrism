using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    class ViewAViewModel : BindableBase,IConfirmNavigationRequest
    {
		/// <summary>
		/// 绑定的内容
		/// </summary>
		private string msg;

		public string Msg
		{
			get { return msg; }
			set { 
				msg = value;
                RaisePropertyChanged();
            }
			
		}

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            if (MessageBox.Show("确定切换吗？", "温馨提示", MessageBoxButton.YesNo) == MessageBoxResult.No) { 
            
                result = false;
            }
            continuationCallback(result);
        }

        /// <summary>
        /// 是否重用上次的实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }


        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
           
            
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("MsgA"))
            {
                Msg = navigationContext.Parameters.GetValue<string>("MsgA");
            }
                
        
        }
    }
}
