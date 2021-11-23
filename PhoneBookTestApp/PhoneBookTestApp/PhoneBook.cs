using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        private readonly ILogger _logger;

        public PhoneBook(ILogger logger)
        {
            _logger = logger;
        }

        public List<Person> GetAll()
        {
            var connection = DatabaseUtil.GetConnection();
            using (connection)
            {
                var command = new SqlCommand($"Select * from PhoneBook", connection);
                var result = new List<Person>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var person = new Person
                        {
                            Name = reader.GetString(0),
                            PhoneNumber = reader.GetString(1),
                            Address = reader.GetString(2)
                        };
                        result.Add(person);
                    }
                }

                return result;
            }
        }

        public void AddPerson(Person person)
        {
            var connection = DatabaseUtil.GetConnection();
            using (connection)
            {
                var command = new SqlCommand($"Insert into PhoneBook (Name, PhoneNumber, Address) values (@Name, @PhoneNumber, @Address)", connection);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                command.Parameters.AddWithValue("@Address", person.Address);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex, "An error occurred");
                }
            }
        }

        public Person FindPerson(string name)
        {
            var connection = DatabaseUtil.GetConnection();
            using (connection)
            {
                var command = new SqlCommand("Select * from PhoneBook where Name like @Name", connection);
                command.Parameters.AddWithValue("@Name", name);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new Person
                    {
                        Name = reader.GetString(0),
                        PhoneNumber = reader.GetString(1),
                        Address = reader.GetString(2)
                    };
                }
            }
        }
    }
}