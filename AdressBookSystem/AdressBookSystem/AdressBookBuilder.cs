using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdressBookSystem
{
    class AdressBookBuilder : IContacts
    {
        public List<Contact> contactList;
        /// <summary>
        /// Initializes a new instance of the list <see cref="AdressBookBuilder"/> class.
        /// </summary>
        public AdressBookBuilder()
        {
            this.contactList = new List<Contact>();
        }
        /// <summary>
        /// Adds the contact but contact is not be duplicated
        /// </summary>
        /// <param name="firstName">The first name of person</param>
        /// <param name="lastName">The last name of person</param>
        /// <param name="address">The address of person</param>
        /// <param name="city">The city of person</param>
        /// <param name="state">The state of person</param>
        /// <param name="zip">The zip code of person</param>
        /// <param name="phoneNumber">The phone number of person</param>
        /// <param name="email">The email of person</param>
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            bool duplicate = equals(firstName);
            if (!duplicate)
            {
                Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                contactList.Add(contact);
            }
            else
            {
                Console.WriteLine("Cannot add duplicate contacts when you give first name same");
            }
        }
        /// <summary>
        /// Equalses the specified first name for duplicate name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        private bool equals(string firstName)
        {
            if (this.contactList.Any(e => e.firstName == firstName))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Edits the contact with the help of first name of person
        /// </summary>
        /// <param name="firstName">The first nameof person</param>
        public void editContact(string firstName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
                {
                    flag = 0;
                    Console.WriteLine("Enter last name = ");
                    contact.lastName = Console.ReadLine();
                    Console.WriteLine("Enter address= ");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter city= ");
                    contact.city = Console.ReadLine();
                    Console.WriteLine("Enter state= ");
                    contact.state = Console.ReadLine();
                    Console.WriteLine("Enter zip= ");
                    contact.zip = Console.ReadLine();
                    Console.WriteLine("Enter phoneNumber= ");
                    contact.phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter email= ");
                    contact.email = Console.ReadLine();
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }
        /// <summary>
        /// Deletes the contact of person with the help of first name
        /// </summary>
        /// <param name="firstName">The first name of person</param>
        public void deleteContact(string firstName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
                {
                    flag = 0;
                    contactList.Remove(contact);
                    Console.WriteLine("Sucessfully deleted");
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }
        /// <summary>
        /// Displays the contact of persons
        /// </summary>
        public void displayContact()
        {
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\nFirst name = " + contact.firstName);
                Console.WriteLine("Last name = " + contact.lastName);
                Console.WriteLine("Address = " + contact.address);
                Console.WriteLine("city = " + contact.city);
                Console.WriteLine("state = " + contact.state);
                Console.WriteLine("zip = " + contact.zip);
                Console.WriteLine("phoneNumber = " + contact.phoneNumber);
                Console.WriteLine("email = " + contact.email);
            }
        }
        public List<string> findPersons(string place)
        {
            List<string> personFounded = new List<string>();
            foreach (Contact contacts in contactList.FindAll(e => (e.city.Equals(place))).ToList())
            {
                string name = contacts.firstName + " " + contacts.lastName;
                personFounded.Add(name);
            }
            if (personFounded.Count == 0)
            {
                foreach (Contact contacts in contactList.FindAll(e => (e.state.Equals(place))).ToList())
                {
                    string name = contacts.firstName + " " + contacts.lastName;
                    personFounded.Add(name);
                }
            }
            return personFounded;
        }
    }
}