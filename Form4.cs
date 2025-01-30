using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMarket
{
    public partial class Form4 : Form
    {
        internal DataTable tableBasketProducts;
        private string pathToBusket = "market_goods_korzina.txt";
        internal Shop shop;
        internal Basket basket;
        internal User user;
        internal FileManager fileManager;

        public Form4()
        {
            InitializeComponent();

            basket = new Basket();
            fileManager = new FileManager();
            tableBasketProducts = basket.tableProductsInBasket;
            basket.ProductsInBasketByUserId(User.id_id, dataGridViewBasket);
        }

        private void ButtonSwitchToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteProductFromBasket_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана строка
            if (dataGridViewBasket.CurrentRow != null)
            {
                int index = Convert.ToInt32(dataGridViewBasket.CurrentRow.Cells[7].Value);
                fileManager.deleteProductFromBasket(index, pathToBusket);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку.");
            }
        }

        private void RefreshBasketProductsGrid_Click(object sender, EventArgs e)
        {
            RefreshBasketProductsGridView();
        }

        private void RefreshBasketProductsGridView()
        {
            if (tableBasketProducts != null)
            {
                // Обновляем данные в таблице
                tableBasketProducts.Clear();
                basket.tableProductsInBasket.Clear();
                basket.fillBasket(tableBasketProducts);

                // Привязываем обновленную таблицу к DataGridView
                basket.ProductsInBasketByUserId(User.id_id, dataGridViewBasket);
            }
            else
            {
                MessageBox.Show("Таблица не инициализирована.");
            }
        }

        private void saveProductsToBascketFile_Click(object sender, EventArgs e)
        {
            //FileManager fm = new FileManager();
            //fm.writeUsersGridViewToFile(tableBasketProducts, pathToBusket);
            //MessageBox.Show("Ваш заказ принят");
            var dgv = basket.ProductsInBasketByUserId(User.id_id, dataGridViewBasket);
            ShowDataGridViewContent(dgv);

        }

        public static void ShowDataGridViewContent(DataView dv)
        {
            StringBuilder sb = new StringBuilder();
            decimal totalSum = 0; // Переменная для хранения суммы

            int firstColumnIndex = 0; // Первый столбец (не включаем)
            int lastColumnIndex = dv.Table.Columns.Count - 1; // Последний столбец (не включаем)
            int priceColumnIndex = lastColumnIndex - 1; // Предпоследний столбец (где цена)

            // Заголовки столбцов (без первого и последнего)
            for (int i = 1; i < lastColumnIndex; i++)
            {
                sb.Append(dv.Table.Columns[i].ColumnName + "\t");
            }
            sb.AppendLine();

            // Данные строк + подсчет суммы
            foreach (DataRowView rowView in dv)
            {
                for (int i = 1; i < lastColumnIndex; i++) // Начинаем с 1, не включаем последний
                {
                    sb.Append(rowView[i]?.ToString() + "\t");
                }
                sb.AppendLine();

                // Добавляем к сумме значение предпоследнего столбца
                if (decimal.TryParse(rowView[priceColumnIndex]?.ToString(), out decimal price))
                {
                    totalSum += price;
                }
            }

            // Добавляем итоговую сумму в сообщение
            sb.AppendLine($"ИТОГОВАЯ СУММА: {totalSum} $"); // {totalSum:C} форматирует сумму в валюту

            // Вывод данных в MessageBox
            MessageBox.Show(sb.ToString(), "Содержимое DataView", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
