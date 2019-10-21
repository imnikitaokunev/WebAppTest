using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void InitializeDatabase(params Person[] persons)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandText = "Create table PhoneBook(Name varchar(255), PhoneNumber varchar(255), Address varchar(255))";
                command.ExecuteNonQuery();
                if (persons != null)
                {
                    foreach (var person in persons)
                    {
                        command.CommandText =
                            $"Insert into PhoneBook values('{person.Name}', '{person.PhoneNumber}', '{person.Address}')";
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CleanUp()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Drop table PhoneBook";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}