using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneBook
    {
        Dictionary<string, string> contacts = new Dictionary<string, string>();
        public void addContact(string _name, string _number)
        {
            contacts.Add(_name, _number);
        }

        public void deleteContact(string _name)
        {
            if (!contacts.Remove(_name))
                Console.WriteLine("No such contact");
        }

        public void searchNumber(string _name)
        {
            if (contacts.ContainsKey(_name))
                Console.WriteLine("Name: {0}\nPhone: {1}", _name, contacts[_name]);
            else
                Console.WriteLine("No such contact");
        }
        public void showAllContacts()
        {
            foreach(var contact in contacts)
            {
                Console.WriteLine("Name: {0}\nNumber: {1}", contact.Key, contact.Value);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook myPhoneBook = new PhoneBook();
            myPhoneBook.addContact("Tom", "8908721211");
            myPhoneBook.addContact("Tod", "8908721212");
            myPhoneBook.addContact("Bred", "8908721213");
            myPhoneBook.addContact("Angela", "8908721214");
            myPhoneBook.addContact("Frank", "8908721215");
            myPhoneBook.addContact("Tad", "8908721216");
            myPhoneBook.addContact("Bill", "8908721217");

            myPhoneBook.showAllContacts();
            Console.WriteLine("\n");

            myPhoneBook.searchNumber("Bill");
            myPhoneBook.searchNumber("Angela");
            myPhoneBook.searchNumber("Biln");
            Console.WriteLine("\n");

            myPhoneBook.deleteContact("Tod");
            myPhoneBook.deleteContact("Frank");
            Console.WriteLine("\n");

            myPhoneBook.showAllContacts();

            Console.ReadLine();
        }
    }
}
