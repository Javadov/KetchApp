using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
