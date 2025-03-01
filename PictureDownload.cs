using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FormMarket
{
    internal class PictureDownload
    {
        private string connectionString = "Server=localhost; Database=UsersData; Integrated Security=True; TrustServerCertificate=True;";

        // функция для записи изображения в базу данных
        public void SaveImageToDatabase(string filePath, int id)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Ошибка: файл не найден.");
                return;
            }

            try
            {
                byte[] imageData = File.ReadAllBytes(filePath);  // считываем файл в массив байтов

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // запрос на добавление данных в таблицу
                    string query = "UPDATE login_password SET FilePath = @FilePath, ProfilePicture = @ProfilePicture WHERE ID = @ID";

                    using (var command = new SqlCommand(query, connection))
                    {
                        // параметры для запроса
                        command.Parameters.AddWithValue("@FilePath", filePath);  // путь к файлу
                        command.Parameters.AddWithValue("@ProfilePicture", imageData);  // двоичные данные изображения
                        command.Parameters.AddWithValue("@ID", id);  // двоичные данные изображения

                        // выполнение запроса
                        command.ExecuteNonQuery();
                        MessageBox.Show("Изображение успешно сохранено в базу данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения в базу: " + ex.Message);

            }
        }

        // функция для чтения изображения из базы данных
        public void ReadImageFromDatabase(int imageId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // запрос для получения изображения по ID
                    string query = "SELECT ImageData, FilePath FROM Images WHERE ImageId = @ImageId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ImageId", imageId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] imageData = (byte[])reader["ImageData"];
                                string filePath = (string)reader["FilePath"];

                                // путь, куда сохранить извлечённое изображение
                                string savePath = ("C:/Users/Alex/Desktop/image.jpg");

                                // сохраняем файл обратно в файловую систему
                                File.WriteAllBytes(savePath, imageData);
                                Console.WriteLine($"Изображение извлечено и сохранено по пути: {savePath}");
                            }
                            else
                            {
                                Console.WriteLine("Изображение с таким ID не найдено.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при извлечении изображения из базы: " + ex.Message);
            }
        }
    }
}
