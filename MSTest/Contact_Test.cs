using ConsoleApp.Models;
using ConsoleApp.Services;

namespace MSTest
{
    [TestClass]
    public class Contact_Test
    {
        [TestMethod]
        public void Should_Add_Contact_to_List()
        {
            // arrange
            Menu menu = new();
            Contact contact = new();

            // act
            menu.contacts.Add(contact);

            // assert
            Assert.AreEqual(1, menu.contacts.Count);
        }

        [TestMethod]
        public void Should_Remove_Contact_From_List()
        {
            // arrange
            Menu menu = new();
            Contact contact = new();

            // act
            menu.contacts.Remove(contact);

            // assert
            Assert.AreEqual(0, menu.contacts.Count);
        }
    }
}