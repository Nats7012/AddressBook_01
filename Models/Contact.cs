using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02_AddressBook.Models
{
    internal class Contact
    {
        public Contact()
        {

        }

        public Contact(Guid id, string firstName, string lastName,  string streetName, string postalCode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;

        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }


        public string FullName => $"{FirstName} {LastName}";
        public string Address => $"{StreetName}, {PostalCode} {City}";

    }
    

}
