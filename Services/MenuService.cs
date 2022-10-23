using _02_AddressBook.Interfaces;
using _02_AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AddressBook.Services
{
    internal interface IMenuService
    {
        public void Create(Contact contact);
        public void Update(Contact contact);
        public void Delete(Guid id);


        public Contact Get(Guid id); // Hämta en kontakt
        public IEnumerable<Contact> GetAll(); // Hämta alla kontakter
        void Update(Func<string?> uContacts);
        Contact Update(string? v);
    }
    internal class MenuService : IMenuService
    {
        private List<Contact> _contacts = new List<Contact>();

        public void Create(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void Delete(Guid id)
        {
            _contacts = _contacts.Where(x => x.Id != id).ToList(); // x är kontakten.
                                                                  
        }


        public Contact Get(Guid id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? Update(Guid id, Contact contact)
        {
            return null;
        }
        public void Update(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Update(string? v)
        {
            throw new NotImplementedException();
        }

        public void Update(Func<string?> uContacts)
        {
            throw new NotImplementedException();
        }
    }
}
