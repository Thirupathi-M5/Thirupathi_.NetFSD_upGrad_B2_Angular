using NUnit.Framework;
using Moq;
using ContactApp.Models;
using ContactApp.Repositories;
using ContactApp.Services;
using System.Collections.Generic;
using System;

namespace ContactApp.Tests
{
    [TestFixture]
    public class ContactServiceTests
    {
        private Mock<IContactRepository> mockRepo;
        private ContactService service;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IContactRepository>();
            service = new ContactService(mockRepo.Object);
        }

        [Test]
        public void AddContact_CallsRepository()
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

            // Assert
            mockRepo.Verify(x => x.AddContact(contact), Times.Once);
        }

        [Test]
        public void GetContacts_ReturnsData()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Raj", Email = "raj@gmail.com" }
            };

            mockRepo.Setup(x => x.GetContacts()).Returns(contacts);

            // Act
            var result = service.GetContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void RemoveContact_ReturnsTrue()
        {
            // Arrange
            mockRepo.Setup(x => x.RemoveContact(1)).Returns(true);

            // Act
            var result = service.RemoveContact(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddContact_ThrowsException()
        {
            // Arrange
            Contact contact = null;

            // Act + Assert
            Assert.Throws<Exception>(() =>
            {
                service.AddContact(contact);
            });
        }
    }
}