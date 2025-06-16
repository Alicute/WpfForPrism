using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ModuleA.ViewModels;
using Prism.Regions;


namespace WpfAForPrism.Tests
{

    [TestFixture]
    public class ViewAViewModuleTests
    {

        [Test]
        public void Msg_Property_SetAndGet_Works()
        {
            var vm = new ViewAViewModel();
            vm.Msg = "Hello";
            Assert.That(vm.Msg, Is.EqualTo("Hello"));


        }
        [Test]
        public void Msg_Property_RaisesPropertyChanged()
        {
            var vm = new ViewAViewModel();
            string propertyName = null;
            vm.PropertyChanged += (s, e) => propertyName = e.PropertyName;

            vm.Msg = "Hello";

            Assert.That(propertyName, Is.EqualTo("Msg"));
        }
        [Test]
        public void OnNavigatedTo_SetMsg_WhenParameterExists()
        {
            //Arrange
            var vm = new ViewAViewModel();
            var parameters = new NavigationParameters();
            parameters.Add("MsgA", "TestMsg");
            var context = new NavigationContext(null, new Uri("ViewA", UriKind.Relative), parameters);


            //Act
            ((INavigationAware)vm).OnNavigatedTo(context);

            //Assert
            Assert.That(vm.Msg, Is.EqualTo("TestMsg"));

        }
        [Test]
        public void OnNavigatedTo_DoesNotSetMsg_WhenParameterNotExists()
        {
            // Arrange
            var vm = new ViewAViewModel();
            vm.Msg = "原始值";
            var parameters = new NavigationParameters(); // 没有加 "MsgA"
            var context = new NavigationContext(null, new Uri("ViewA", UriKind.Relative), parameters);

            // Act
            ((INavigationAware)vm).OnNavigatedTo(context);

            // Assert
            Assert.That(vm.Msg, Is.EqualTo("原始值"));
        }

    }
}
