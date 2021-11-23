using System;
using Microsoft.Extensions.Logging;

namespace PhoneBookTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.CleanUp();
                DatabaseUtil.InitializeDatabase();
                var factory = new LoggerFactory();
                var phoneBook = new PhoneBook(factory.CreateLogger("Default"));

                Console.WriteLine("Phone book");

                var persons = phoneBook.GetAll();
                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Name}, {person.PhoneNumber}, {person.Address}");
                }

                var john = new Person
                {
                    Name = "John Smith",
                    PhoneNumber = "(248) 123-4567",
                    Address = "1234 Sand Hill Dr, Royal Oak, MI"
                };

                var cynthia = new Person
                {
                    Name = "Cynthia Smith",
                    PhoneNumber = "(824) 128-8758",
                    Address = "875 Main St, Ann Arbor, MI"
                };

                phoneBook.AddPerson(john);
                phoneBook.AddPerson(cynthia);

                Console.WriteLine("-- Added 2 persons --");
                Console.WriteLine("Phone book");

                persons = phoneBook.GetAll();
                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Name}, {person.PhoneNumber}, {person.Address}");
                }

                var cynth = phoneBook.FindPerson("Cynthia Smith");
                Console.WriteLine($"{cynth.Name}, {cynth.PhoneNumber}, {cynth.Address}");

                Console.ReadLine();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
