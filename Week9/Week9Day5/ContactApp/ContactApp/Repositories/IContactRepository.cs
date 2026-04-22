using ContactApp.Models;
using System.Collections.Generic;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);

        List<Contact> GetContacts();

        bool RemoveContact(int id);
    }
}