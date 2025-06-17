using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    internal class ViewCViewModel : IDialogAware
    {
        public string Title { get; set; } = "对话框";
        public string P1 { get; set; }
        public string P2 { get; set; }

        public DelegateCommand ConfirmCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public ViewCViewModel()
        {
            ConfirmCommand = new DelegateCommand(ConfirmCommandExecute);
            CancelCommand = new DelegateCommand(CancelCommandExecute);
        }
        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
            P1 = parameters.GetValue<string>("para1");
            P2 = parameters.GetValue<string>("para2");

        }

        private void CancelCommandExecute()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        private void ConfirmCommandExecute()
        {
           if(RequestClose != null)
           {        
                DialogParameters paras = new DialogParameters();
                paras.Add("result1", "张三");
                paras.Add("result2", "李四");
                RequestClose(new DialogResult(ButtonResult.OK,paras));  
           }
        }
    }
}
