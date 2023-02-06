using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using WPFApp.Models;

namespace WPFApp.Services
{
    class ContactService
    {
        private static ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        public static void Remove(Contact contact)
        { 
            contacts.Remove(contact);
        }

        public static ObservableCollection<Contact> Contacts() 
        { 
            return contacts; 
        }
    }

    public class NullVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
