using ContactManagementApp.Models;

namespace ContactManagementApp.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);

        void UpdateContact(Contact contact);

        bool DeleteContact(int id);

        List<Contact> GetAllContacts();

        Contact? GetContactById(int id);

    }
}