using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person[] persons =
                {
                    new Person("John Smith", "(248) 123-4567", "1234 Sand Hill Dr, Royal Oak, MI"),
                    new Person("Cynthia Smith", "(824) 128-8758", "875 Main St, Ann Arbor, MI")
                };

                DatabaseUtil.InitializeDatabase(null);

                PhoneBook phoneBook = new PhoneBook();
                phoneBook.AddPerson(persons[0]);
                phoneBook.AddPerson(persons[1]);

                for (int i = 0; i < phoneBook.Length; ++i)
                {
                    Console.WriteLine(phoneBook[i].GetInfo);
                }

                Person p = phoneBook.FindPerson("Cynthia Smith");
                Console.WriteLine(p?.GetInfo);

                Console.ReadLine();

                #region Test

                


                //Console.ReadLine();
                ///* TODO: create person objects and put them in the PhoneBook and database
                //* John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                //* Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                //*/

                //// TODO: print the phone book out to System.out
                //// TODO: find Cynthia Smith and print out just her entry
                //// TODO: insert the new person objects into the database


                #endregion

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
