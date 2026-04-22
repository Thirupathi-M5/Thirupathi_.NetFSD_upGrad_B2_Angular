using ContactApp.Models;
using System.Collections.Generic;

namespace ContactApp.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);

        List<Contact> GetContacts();

        bool RemoveContact(int id);
    }
}