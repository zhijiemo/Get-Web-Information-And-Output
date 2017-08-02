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
                    //ResponseListBox.Items.Add(item);
                    NotifacationListBox.Items.Add(item);
                    //MessageBox.Show(item.Name);
                    //Notification x =(Notification) item.Name;
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
        //private void NotifationListBox_leave(object sender, EventArgs e)
        //{
        //    this.NotifacationListBox.Items.Add(this.NotifacationListBox.Items + Environment.NewLine);
        //}


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //foreach (var item in new NotificationProvider().DownloadAllNotifications(AddressTextBox.Text))
            //{
            //    //MessageBox.Show(item.ToString());
            //    //NotifacationListBox.Items.Add(item);
            //}
            //NotifacationListBox.Items.Add("Item1");
            //ResponseListBox.Items.Add("Item1");
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //NotifacationListBox.Items.Clear();
                //ResponseListBox.Items.Clear();
                //foreach (var item in new NotificationProvider().DownloadAllNotifications(AddressTextBox.Text))
                //{
                //    //var x = new NotificationProvider().DownloadAllNotifications(AddressTextBox.Text);
                //    //x.ToList();
                //    //MessageBox.Show(item.ToString());
                //    ResponseListBox.Items.Add(item);
                //}
                ResponseListBox.Items.Add(NotifacationListBox.SelectedItem );
                NotifacationListBox.Items.RemoveAt(NotifacationListBox.SelectedIndex);
                //NotifacationListBox.SelectedItems.Remove(NotifacationListBox.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void ResponseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
