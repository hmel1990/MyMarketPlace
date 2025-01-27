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
                fileManager.deleteProductFromBasket(index,pathToBusket);
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
            FileManager fm = new FileManager();
            fm.writeUsersGridViewToFile(tableBasketProducts, pathToBusket);
        }

    }
}
