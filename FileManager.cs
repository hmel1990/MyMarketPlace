using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace FormMarket
{
    internal class FileManager
    {

        public string[] readStringsFromFile(string path)
        {
            // Проверяем, существует ли файл////
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }
            string[] lines;
            try
            {
                // Считываем все строки из файла
                lines = File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            // Проверяем, есть ли строки в файле
            if (lines.Length == 0)
            {
                throw new InvalidOperationException("Файл пуст.");
            }

            return lines;
        }

        public void addStringToFile(string path, string newLine)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(newLine);
            }
        }


        public void writeUsersGridViewToFile(DataTable tableUsers, string pathToProducts)
        {
            using (var writer = new StreamWriter(pathToProducts, false))//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                // Запись заголовков
                var headers = string.Join("\t", tableUsers.Columns.Cast<DataColumn>().Select(column => column.ColumnName));
                writer.WriteLine(headers);

                // Запись данных строк
                foreach (DataRow row in tableUsers.Rows)
                {
                    var values = string.Join("\t", row.ItemArray);
                    writer.WriteLine(values);
                }
            }
        }

        public void writeLinesToFile(string pathToFile, List<string> lst)
        {
            File.WriteAllLines(pathToFile, lst);
        }


        public void deleteProductFromBasket(int index, string pathToFile)
        {
            FileManager fileManager = new FileManager();

            var lines = fileManager.readStringsFromFile(pathToFile).ToList();

            // Проверяем, корректен ли номер строки
            if (index < 1 || index > lines.Count)
            {
                Console.WriteLine("Номер строки вне диапазона.");
                return;
            }

            // Удаляем строку с указанным номером (индекс на 1 меньше, так как индексация с 0)
            lines.RemoveAt(index);

            // Перезаписываем файл без удалённой строки
            //File.WriteAllLines(pathToBasket, lines);
            fileManager.writeLinesToFile(pathToFile, lines);

            //Console.WriteLine($"Строка {index} успешно удалена.");
        }

    }

}
