using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        private List<Person> phoneBook;

        public int Length => phoneBook.Count;

        public Person this[int index]
        {
            get => phoneBook[index];
            set => phoneBook[index] = value;
        }

        public PhoneBook()
        {
            phoneBook = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            if (person != null)
            {
                phoneBook.Add(person);
            }
        }

        public Person FindPerson(string name)
        {
            Person person = null;

            foreach (var item in phoneBook)
            {
                if (item.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    person = item;
                    break;
                }
            }

            return person;
        }
    }
}