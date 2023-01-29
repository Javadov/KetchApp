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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateContactButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow.Navigate(new Uri("NewPage.xaml", UriKind.Relative));
        }

        private void ShowAllContactsButton_CConsoleApplick(object sender, RoutedEventArgs e)
        {
            // Kod för att visa alla kontakter
        }

        private void ShowSpecificContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Kod för att visa en specifik kontakt
        }

        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Kod för att ta bort en specifik kontakt
        }
    }
}
