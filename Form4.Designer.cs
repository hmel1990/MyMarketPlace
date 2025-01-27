namespace FormMarket
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonSwitchToMain = new Button();
            dataGridViewBasket = new DataGridView();
            BasketSellerLabel = new Label();
            RefreshBasketProductsGrid = new Button();
            saveUsersToFile = new Button();
            deleteProductFromBasket = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBasket).BeginInit();
            SuspendLayout();
            // 
            // ButtonSwitchToMain
            // 
            ButtonSwitchToMain.BackColor = Color.Goldenrod;
            ButtonSwitchToMain.Location = new Point(61, 69);
            ButtonSwitchToMain.Name = "ButtonSwitchToMain";
            ButtonSwitchToMain.Size = new Size(262, 46);
            ButtonSwitchToMain.TabIndex = 1;
            ButtonSwitchToMain.Text = "Back to main";
            ButtonSwitchToMain.UseVisualStyleBackColor = false;
            ButtonSwitchToMain.Click += ButtonSwitchToMain_Click;
            // 
            // dataGridViewBasket
            // 
            dataGridViewBasket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBasket.BackgroundColor = Color.Gainsboro;
            dataGridViewBasket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBasket.Location = new Point(869, 351);
            dataGridViewBasket.Name = "dataGridViewBasket";
            dataGridViewBasket.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewBasket.Size = new Size(1564, 390);
            dataGridViewBasket.TabIndex = 6;
            // 
            // BasketSellerLabel
            // 
            BasketSellerLabel.AutoSize = true;
            BasketSellerLabel.FlatStyle = FlatStyle.Flat;
            BasketSellerLabel.Font = new Font("Times New Roman", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            BasketSellerLabel.ForeColor = Color.FromArgb(255, 128, 0);
            BasketSellerLabel.Location = new Point(1524, 144);
            BasketSellerLabel.Name = "BasketSellerLabel";
            BasketSellerLabel.Size = new Size(181, 61);
            BasketSellerLabel.TabIndex = 10;
            BasketSellerLabel.Text = "Basket";
            BasketSellerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RefreshBasketProductsGrid
            // 
            RefreshBasketProductsGrid.Location = new Point(1425, 255);
            RefreshBasketProductsGrid.Name = "RefreshBasketProductsGrid";
            RefreshBasketProductsGrid.Size = new Size(222, 46);
            RefreshBasketProductsGrid.TabIndex = 7;
            RefreshBasketProductsGrid.Text = "Refresh";
            RefreshBasketProductsGrid.UseVisualStyleBackColor = true;
            RefreshBasketProductsGrid.Click += RefreshBasketProductsGrid_Click;
            // 
            // saveUsersToFile
            // 
            saveUsersToFile.Location = new Point(1157, 255);
            saveUsersToFile.Name = "saveUsersToFile";
            saveUsersToFile.Size = new Size(222, 46);
            saveUsersToFile.TabIndex = 8;
            saveUsersToFile.Text = "Save";
            saveUsersToFile.UseVisualStyleBackColor = true;
            saveUsersToFile.Click += saveProductsToBascketFile_Click;
            // 
            // deleteProductFromBasket
            // 
            deleteProductFromBasket.Location = new Point(869, 255);
            deleteProductFromBasket.Name = "deleteProductFromBasket";
            deleteProductFromBasket.Size = new Size(222, 46);
            deleteProductFromBasket.TabIndex = 9;
            deleteProductFromBasket.Text = "Delete";
            deleteProductFromBasket.UseVisualStyleBackColor = true;
            deleteProductFromBasket.Click += deleteProductFromBasket_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(2967, 1711);
            Controls.Add(BasketSellerLabel);
            Controls.Add(RefreshBasketProductsGrid);
            Controls.Add(saveUsersToFile);
            Controls.Add(deleteProductFromBasket);
            Controls.Add(dataGridViewBasket);
            Controls.Add(ButtonSwitchToMain);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBasket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonSwitchToMain;
        private DataGridView dataGridViewBasket;
        private Label BasketSellerLabel;
        private Button RefreshBasketProductsGrid;
        private Button saveUsersToFile;
        private Button deleteProductFromBasket;
    }
}