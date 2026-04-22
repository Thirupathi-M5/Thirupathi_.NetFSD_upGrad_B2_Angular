using ContactApp.Models;
using ContactApp.Repositories;
using System;
using System.Collections.Generic;

namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository repo;

        public ContactService(IContactRepository repo)
        {
            this.repo = repo;
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new Exception("Contact cannot be null");

            repo.AddContact(contact);
        }

        public List<Contact> GetContacts()
        {
            return repo.GetContacts();
        }

        public bool RemoveContact(int id)
        {
            return repo.RemoveContact(id);
        }
    }
}