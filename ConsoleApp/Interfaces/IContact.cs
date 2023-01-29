using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interfaces
{
    internal interface IContact
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
}
