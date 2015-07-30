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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChangeDNS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] dns = NetworkSetting.GetCurrentDNS();
            UpdateCurrentDNS(dns);
        }

        private void ButtonRefreshDNS_Click(object sender, RoutedEventArgs e)
        {
            string[] dns = NetworkSetting.GetCurrentDNS();
            UpdateCurrentDNS(dns);
        }

        private void UpdateCurrentDNS(string[] dns)
        {
            //try
            //{
            //    CurrentDNS.Text = string.Join(",", dns);
            //}
            //catch
            //{
            //    CurrentDNS.Text = "hehe";
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NetworkSetting.SetDNS(new string[]{"114.114.114.114","8.8.8.8"});
        }

        
    }
}
