using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.Models;
using WPFApp.Services;

namespace WPFApp.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public AddContactViewModel() 
        { 
            fileService = new FileService();
        }

        [ObservableProperty]
        private string pageTitle = "Skapa en kontakt";

        [ObservableProperty]
        private string firstname = string.Empty;

        [ObservableProperty]
        private string lastname = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phonenumber = string.Empty;

        [ObservableProperty]
        private string streetaddress = string.Empty;

        [ObservableProperty]
        private string postalcode = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;

        [RelayCommand]

        private void Add()
        {
            fileService.AddToContacts(new Contact
            {
                FirstName = Firstname,
                LastName = Lastname,
                Email = Email,
                PhoneNumber = Phonenumber,
                StreetAddress = Streetaddress,
                PostalCode = Postalcode,
                City = City
            }) ;

            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Phonenumber = string.Empty;
            Streetaddress = string.Empty;
            Postalcode = string.Empty;
            City = string.Empty;
        }
    }
}
