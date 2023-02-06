using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WPFApp.Models;

namespace WPFApp.Services
{
    public class FileService
    {
        private static string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";
        private static List<Contact> contacts;

        public FileService()
        {
            Read();
        }

        private static void Save()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        private static void Read()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd())!;
            }
            catch
            {
                contacts = new List<Contact>();
            }
        }

        public void AddToContacts(Contact contact) 
        { 
            contacts.Add(contact);
            Save();
        }

        public static void Remove(Contact contact)
        {
            contacts.Remove(contact);
            Save();
            Contacts();
        }

        private static void Edit(Contact selectedContact, Contact newContact)
        {
            int index = contacts.IndexOf(selectedContact);
            contacts[index] = newContact;
            Save();
            Contacts();
        }

        public static ObservableCollection<Contact> Contacts()
        { 
            var items = new ObservableCollection<Contact>();
            foreach (var contact in contacts)
                items.Add(contact);
            Save();
            return items;
        }
    }
}
