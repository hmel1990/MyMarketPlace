using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;


namespace FormMarket
{
    internal class DataBaseManager
    {
        private string connectionString = "Server=localhost; Database=UsersData; Integrated Security=True; TrustServerCertificate=True;";

        private string query = "SELECT ID, Username, Password, Access FROM login_password";

        private string query2 = "SELECT * FROM login_password WHERE Username = @Username AND Password = @Password";

        private string query3 = "INSERT INTO login_password (Username, Password, Access) VALUES (@Username, @Password, @Access)";




        public LoginPassword GetUser()
        {
           LoginPassword dataUser = new LoginPassword();
            // создание подключения
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    // открытие соединения с базой данных
                    connection.Open();

                    // создание команды для выполнения запроса
                    using (var command = new SqlCommand(query, connection))
                    {
                        // выполнение команды и чтение данных с помощью SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // проверка, есть ли данные
                            if (reader.HasRows)
                            {
                                // чтение строк данных и вывод на экран
                                while (reader.Read())
                                {
                                    // чтение значений из текущей строки
                                    dataUser.userID = Convert.ToString(reader.GetInt32(0));  // чтение id
                                    dataUser.login = reader.GetString(1);  // чтение Username
                                    dataUser.password = reader.GetString(2);  // чтение password
                                    dataUser.access = reader.GetString(3);  // чтение Access
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нема данных в таблице.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
            return dataUser;


        }


        public bool Autorization (string loginUser, string passwordUser)
        {
            bool x = true;

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    
                   
                    using (var command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@Username", loginUser);
                        command.Parameters.AddWithValue("@Password", passwordUser);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // проверка, есть ли данные
                            x = reader.HasRows;
                        }
                    } 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }


            return x;
        }


        public bool Registration(string loginUser, string passwordUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (!Autorization(loginUser, passwordUser))
                    {
                        using (var command = new SqlCommand(query3, connection))
                        {
                            command.Parameters.AddWithValue("@Username", loginUser);
                            command.Parameters.AddWithValue("@Password", passwordUser);
                            command.Parameters.AddWithValue("@Access", "customer");

                            command.ExecuteNonQuery();
                        }

                        return true;
                    }
                    else return false;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
