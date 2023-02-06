using Amazon.CloudTrail.Model;
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
using WPFApp.Models;
using WPFApp.MVVM.ViewModels;
using WPFApp.Services;

namespace WPFApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        private Contact btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (Contact)button.DataContext;
            return contact;
        }
    }
}
