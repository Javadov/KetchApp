using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ConsoleApp.Services;

internal class Menu
{
    private List<Contact> contacts = new();
    private readonly File file = new();

    public string FilePath { get; set; } = null!;

    public void WelcomeMenu()
    {
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        Console.WriteLine();

        Console.Write("Välj ett av alternativen ovan: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                    Console.Clear();
                    CreateContact();            // Skapa en kontakt
                break;
            case "2":
                    Console.Clear();
                    LoadContacts();             // Visa alla kontakter
                break;
            case "3":
                    Console.Clear();
                    SearchContact();            // Visa en specifik kontakt
                break;
            case "4":
                    Console.Clear();
                    RemoveContact();            // Ta bort en specifik kontakt
                 break;
            default:
                    Console.Clear();
                    Console.WriteLine("Ogiltigt alternativ. Var god skriv 1-4!");
                break;
        }
    }

    public void Done()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("____________________________________________________________________________");
        Console.WriteLine("Tryck på någon för att gå till menyn eller tryck på ESC för att stänga appen.");
        var key = Console.ReadKey();
        if (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            WelcomeMenu();
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }

    public void CreateContact()
    {
        Console.Clear();

        Contact contact = new();

        Console.WriteLine("*******************");
        Console.WriteLine("Skapa en ny kontakt");
        Console.WriteLine("*******************");
        Console.WriteLine();

        Console.Write("Förnamn: ");
        contact.FirstName = Console.ReadLine() ?? ""; 

        Console.Write("Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";

        Console.Write("E-postadress: ");
        string email = Console.ReadLine() ?? "";

            while (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Console.WriteLine(">> Ogiltig e-postadress. Försök igen. (Ex: Name@domain.com)");
                Console.WriteLine();
                Console.Write("E-postadress: ");
                email = Console.ReadLine() ?? "";
            }

            contact.Email = email;

        Console.Write("Telefonnummer: ");
        string phonenumber = Console.ReadLine() ?? "";

            while (!Regex.IsMatch(phonenumber, @"^\d{10}$"))
            {
                Console.WriteLine(">> Ogiltig telefonnummer. Försök igen.  (Ex: 0760010101)");
                Console.WriteLine();
                Console.Write("Telefonnummer: ");
                phonenumber = Console.ReadLine() ?? "";
            }

            contact.PhoneNumber = phonenumber;

        Console.Write("Gatuadress: ");
        string streetaddress = Console.ReadLine() ?? "";

            while (!Regex.IsMatch(streetaddress, @"^[a-zA-Z\d\s]+$"))
            {
                Console.WriteLine(">> Ogiltig gatuadress. Försök igen. (Ex: Streetvägen 1)");
                Console.WriteLine();
                Console.Write("Gatuadress: ");
                streetaddress = Console.ReadLine() ?? "";
            }

            contact.StreetAddress = streetaddress;

        Console.Write("Postnummer: ");
        string postnummer = Console.ReadLine() ?? "";

            while (!Regex.IsMatch(postnummer, @"^\d{6}$"))
            {
                Console.WriteLine(">> Ogiltig postnummer. Försök igen.  (Ex: 701 01)");
                Console.WriteLine();
                Console.Write("Postnummer: ");
                postnummer = Console.ReadLine() ?? "";
            }

            contact.PostalCode = postnummer;

        Console.Write("Ort: ");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);

        file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));

        Console.WriteLine();
        Console.WriteLine(">> Att skapa kontakten lyckades!");

        Done();
    }

    public void LoadContacts()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;
        }
        catch { }

        ShowContacts();
    }

    public void ShowContacts()
    {
        Console.WriteLine("********************");
        Console.WriteLine("Lista över kontakter");
        Console.WriteLine("********************");
        Console.WriteLine();

        foreach (var contact in contacts)
        {
            Console.WriteLine($"Förnamn: {contact.FirstName}");
            Console.WriteLine($"Efternamn: {contact.LastName}");
            Console.WriteLine($"E-postadress: {contact.Email}");
            Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
            Console.WriteLine($"Adress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
            Console.WriteLine("----------------------------");
        }

        Done();
    }

    public void SearchContact()
    {
        Console.WriteLine("*****************");
        Console.WriteLine("Sök efter kontakt");
        Console.WriteLine("*****************");
        Console.WriteLine();
        Console.Write("Ange förnamn, efternamn eller e-postadress: ");

        string search = Console.ReadLine() ?? "";

        var filteredContacts = contacts.Where(c => c.FirstName.Contains(search) || c.LastName.Contains(search) || c.Email.Contains(search));

        if (filteredContacts.Any())
            {
                Console.WriteLine("----------------------------");
                foreach (var contact in filteredContacts)
                {
                    Console.WriteLine($"Förnamn: {contact.FirstName}");
                    Console.WriteLine($"Efternamn: {contact.LastName}");
                    Console.WriteLine($"E-postadress: {contact.Email}");
                    Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                    Console.WriteLine($"Adress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
                    Console.WriteLine("----------------------------");
                }
            }
        else
            {
                Console.WriteLine(">> Ingen kontakt hittades.");
            }

        Done();
    }

    public void RemoveContact()
    {
        Console.WriteLine("******************");
        Console.WriteLine("Ta bort en kontakt");
        Console.WriteLine("******************");
        Console.WriteLine();

        bool find = true;
        while (find)
        {
            Console.Write("Ange e-postadress: ");
            string mail = Console.ReadLine() ?? "";

            Contact remove = contacts.Find(x => x.Email == mail);

            if (remove == null)
            {
                Console.WriteLine(">> Ingen kontakt hittades. Försök igen!");
                Console.WriteLine();
                find = true;
            }
            else
            {
                find = false;
                Console.Clear();

                bool confirm = true;
                while (confirm)
                {
                    Console.WriteLine("Är du säker på att du vill ta bort den här kontakten? >> " + remove.DisplayName);
                    Console.WriteLine();
                    Console.Write("Skriv j (JA) eller n (NEJ): ");
                    string confirmation = Console.ReadLine() ?? "";

                    if (confirmation == "j")
                    {
                        contacts.Remove(remove);
                        string json = JsonConvert.SerializeObject(contacts);
                        file.Save(FilePath, json);
                        Console.WriteLine(">> Kontakten har tagits bort.");
                        confirm = false;

                        Done();
                    }
                    else if (confirmation == "n")
                    {
                        Console.WriteLine(">> Kontakten har inte tagits bort.");
                        confirm = false;

                        Done();
                    }
                    else
                    {
                        Console.WriteLine(">> Ogiltigt alternativ. Försök igen.");
                        Console.WriteLine();
                        confirm = true;
                    }
                }
            }
        }
    }
}