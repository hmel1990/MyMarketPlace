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


        private string query2 = "SELECT * FROM login_password WHERE Username = @Username AND Password = @Password";

        private string query3 = "INSERT INTO login_password (Username, Password, Access) VALUES (@Username, @Password, @Access)";



        private string query = "SELECT ID, Access FROM login_password WHERE Username = @Username AND Password = @Password";

        public void GetUser(string loginUser, string passwordUser)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", loginUser);
                        command.Parameters.AddWithValue("@Password", passwordUser);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // проверка, есть ли данные/
                            if (reader.Read())
                            {
                                User.id_id = reader.GetInt32(0);  // чтение id
                            }
                            else
                            {
                                MessageBox.Show("строка пустая");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }        


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
                            // проверка, есть ли данные/
                            x = reader.HasRows;
                            //MessageBox.Show(Convert.ToString(x));
                        }
                    } 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }

            //if (x) {GetUser(loginUser, passwordUser); }
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
