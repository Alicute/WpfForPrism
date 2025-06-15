using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
//using ModuleA;
//using ModuleB;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using WpfAForPrism.Views;

namespace WpfAForPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {


        /// <summary>
        /// 设置启动页
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override MainWindow CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //containerRegistry.RegisterForNavigation<UCA>();
            //containerRegistry.RegisterForNavigation<UCB>();
            //containerRegistry.RegisterForNavigation<UCC>();

        }

        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    moduleCatalog.AddModule<ModuleAProfile>();
        //    moduleCatalog.AddModule<ModuleBProfile>();
        //    base.ConfigureModuleCatalog(moduleCatalog);
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() {  ModulePath=@".\Modules"};
        }
    }

}
