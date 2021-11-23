using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void InitializeDatabase()
        {
            var dbConnection = new SqlConnection(GetConnectionString());
            dbConnection.Open();

            try
            {
                SqlCommand command =
                    new SqlCommand(
                        "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SqlCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SqlCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static SqlConnection GetConnection()
        {
            var dbConnection = new SqlConnection(GetConnectionString());
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SqlConnection(GetConnectionString());
            dbConnection.Open();

            try
            {
                SqlCommand command = new SqlCommand("drop table PHONEBOOK", dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}