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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Holle,world!");
            //this.Title = DateTime.Now.ToString("F");
            //LoadButton.Content = AddressTextBox.Text;
            //NotifacationListBox.Items.Add(TimeSpan.FromMilliseconds(Environment.TickCount));
            //new NotificationProvider().DownloadAllNotifications(AddressTextBox.Text);
            try
            {
                    NotifacationListBox.Items.Clear();
                foreach (var item in new NotificationProvider().DownloadAllNotifications(AddressTextBox.Text))
                {
                    //MessageBox.Show(item.ToString());
                    NotifacationListBox.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void NotifacationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NotifacationListBox.Items.Add("Item1");
            NotifacationListBox.Items.Add("Item2");
            NotifacationListBox.Items.Add("Item3");
        }
    }
}
