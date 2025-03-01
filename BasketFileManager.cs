using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormMarket
{
    internal class BasketFileManager : FileManager
    {
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
            fileManager.writeLinesToFile(pathToFile, lines);

        }

        public void addProductToBasket(User user, DataGridView dataGridView1, string cellValue, string pathToBasket)
        {
            // Проверяем, что выбрана строка
            if (dataGridView1.CurrentRow != null)
            {
                // Сохраняем значение первой ячейки выбранной строки
                for (int i = 0; i < (dataGridView1.Columns.Count); i++)
                {
                    cellValue += dataGridView1.CurrentRow.Cells[i].Value?.ToString() + "\t";//!!!!!!! значение и которое потом запишется в тхт файл корзины)
                }
                MessageBox.Show($"Товар добавлен в корзину: {cellValue}");
                FileManager fm = new FileManager();
                //int number = fm.readStringsFromFile(pathToBasket).Length+1;
                var bbasket = new Basket();
                cellValue = (user.currentUserLoginPassword.userID + "\t" + cellValue + (bbasket.tableProductsInBasket.Rows.Count + 1));//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                fm.addStringToFile(pathToBasket, cellValue);
                cellValue = "";
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку.");
            }
        }
    }


}



