using ContactManagementApp.Models;

namespace ContactManagementApp.Services
{
    public class ContactService : IContactService
    {


        private readonly List<Contact> contacts = new();

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            var existingContact = contacts.FirstOrDefault(x => x.Id == contact.Id);

            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.Email = contact.Email;
                existingContact.Phone = contact.Phone;
            }
        }

        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
        public Contact? GetContactById(int id)
        {
            return contacts.FirstOrDefault(x => x.Id == id);
        }

    }
}