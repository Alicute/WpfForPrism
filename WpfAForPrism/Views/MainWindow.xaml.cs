using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Prism.Events;


namespace WpfAForPrism.Views
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

            private  readonly IEventAggregator EventAggregator;
        public MainWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            EventAggregator = eventAggregator;

        }

        private void BtnPubClick(object sender,RoutedEventArgs e){

            EventAggregator.GetEvent<MsgEvent>().Publish("出去玩！");
        }   

        private void BtnSubClick(object sender,RoutedEventArgs e){

            EventAggregator.GetEvent<MsgEvent>().Subscribe(Sub);
        }
        private void Sub(string obj){
            MessageBox.Show($"订阅事件：{obj}");
        }

        private void BtnUnSubClick(object sender,RoutedEventArgs e){

            EventAggregator.GetEvent<MsgEvent>().Unsubscribe(Sub);
        }
    }
}
