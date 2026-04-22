using NUnit.Framework;
using ContactManagementApp.Services;
using ContactManagementApp.Models;

namespace ContactManagementTests
{
    [TestFixture]
    public class ContactServiceTests
    {
        private ContactService service;

        [SetUp]
        public void Setup()
        {
            service = new ContactService();
        }

        [Test]
        public void AddContact_ShouldAddSuccessfully()
        {
            // Arrange
            Contact contact = new Contact
            {
                Id = 1,
                Name = "Thiru",
                Email = "thiru@gmail.com"
            };

            // Act
            service.AddContact(contact);
            var result = service.GetAllContacts();

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetAllContacts_ShouldReturnList()
        {
            // Arrange
            service.AddContact(new Contact
            {
                Id = 1,
                Name = "Ram",
                Email = "ram@gmail.com"
            });

            // Act
            var contacts = service.GetAllContacts();

            // Assert
            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count > 0);
        }

        [Test]
        public void GetContactById_ShouldReturnCorrectContact()
        {
            // Arrange
            service.AddContact(new Contact
            {
                Id = 2,
                Name = "Raj",
                Email = "raj@gmail.com"
            });

            // Act
            var result = service.GetContactById(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Raj"));
        }

        [Test]
        public void DeleteContact_ShouldRemoveSuccessfully()
        {
            // Arrange
            service.AddContact(new Contact
            {
                Id = 3,
                Name = "Kiran",
                Email = "kiran@gmail.com"
            });

            // Act
            bool deleted = service.DeleteContact(3);

            // Assert
            Assert.IsTrue(deleted);
            Assert.AreEqual(0, service.GetAllContacts().Count);
        }
    }
}