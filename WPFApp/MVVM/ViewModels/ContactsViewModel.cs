using Amazon.Route53Domains.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFApp.Models;
using WPFApp.Services;

namespace WPFApp.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
 //        private readonly FileService fileService;

//        public ContactsViewModel()
//        {
//            fileService = new FileService();
//            contacts = fileService.Contacts();
//        }

        [ObservableProperty]
        private string pageTitle = "Alla kontakter";

        [ObservableProperty]
        private ObservableCollection<Contact> contacts = FileService.Contacts();

        [ObservableProperty]
        private Contact selectedContact = null!;

        [RelayCommand]
        public void Remove()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure about deleting it?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                contacts.Remove(selectedContact);
            }
        }
    }
}