using System;

namespace WPFApp.Models
{
    public interface IContact
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string StreetAddress { get; set; }
        string PostalCode { get; set; }
        string City { get; set; }

        string DisplayName => $"{FirstName} {LastName}";
    }

    public class Contact : IContact
    {
        public Guid Id { get ; set ; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string DisplayName => $"{FirstName} {LastName}";
    }
}

