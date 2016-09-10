namespace PriceCompare.View
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnExcelChart = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panelItems = new System.Windows.Forms.Panel();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dataGridItems = new System.Windows.Forms.DataGridView();
            this.panelCompare = new System.Windows.Forms.Panel();
            this.lblMostExpensiveItems = new System.Windows.Forms.Label();
            this.lblCheapestItems = new System.Windows.Forms.Label();
            this.lblChainCompare = new System.Windows.Forms.Label();
            this.listBoxMostExpensiveItems = new System.Windows.Forms.ListBox();
            this.listBoxCheapesetItems = new System.Windows.Forms.ListBox();
            this.listBoxChainCompare = new System.Windows.Forms.ListBox();
            this.panelShoppingCart = new System.Windows.Forms.Panel();
            this.btnLoadCartFromFile = new System.Windows.Forms.Button();
            this.btnSaveCartToFile = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.panelExcelChart = new System.Windows.Forms.Panel();
            this.pictureBoxChart = new System.Windows.Forms.PictureBox();
            this.btnResetSelectedItem = new System.Windows.Forms.Button();
            this.pictureBoxHeader = new System.Windows.Forms.PictureBox();
            this.panelSide.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).BeginInit();
            this.panelCompare.SuspendLayout();
            this.panelShoppingCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.panelExcelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panelSide.Controls.Add(this.btnExcelChart);
            this.panelSide.Controls.Add(this.btnLogout);
            this.panelSide.Controls.Add(this.btnCart);
            this.panelSide.Controls.Add(this.btnCompare);
            this.panelSide.Controls.Add(this.btnItems);
            this.panelSide.Controls.Add(this.panelLogo);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(148, 484);
            this.panelSide.TabIndex = 1;
            // 
            // btnExcelChart
            // 
            this.btnExcelChart.FlatAppearance.BorderSize = 0;
            this.btnExcelChart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnExcelChart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.btnExcelChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelChart.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelChart.ForeColor = System.Drawing.Color.White;
            this.btnExcelChart.Location = new System.Drawing.Point(3, 232);
            this.btnExcelChart.Name = "btnExcelChart";
            this.btnExcelChart.Size = new System.Drawing.Size(148, 42);
            this.btnExcelChart.TabIndex = 5;
            this.btnExcelChart.Text = "Excel Chart";
            this.btnExcelChart.UseVisualStyleBackColor = true;
            this.btnExcelChart.Click += new System.EventHandler(this.btnExcelChart_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 280);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(148, 42);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "LogOut";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCart
            // 
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnCart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(0, 184);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(148, 42);
            this.btnCart.TabIndex = 3;
            this.btnCart.Text = "MyCart";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.FlatAppearance.BorderSize = 0;
            this.btnCompare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnCompare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.ForeColor = System.Drawing.Color.White;
            this.btnCompare.Location = new System.Drawing.Point(0, 136);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(148, 42);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnItems
            // 
            this.btnItems.FlatAppearance.BorderSize = 0;
            this.btnItems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnItems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(55)))));
            this.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItems.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.ForeColor = System.Drawing.Color.White;
            this.btnItems.Location = new System.Drawing.Point(0, 88);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(148, 42);
            this.btnItems.TabIndex = 1;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(148, 88);
            this.panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(3, 33);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(145, 21);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Price Comparison";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.pictureBoxHeader);
            this.panelHeader.Controls.Add(this.lblUserName);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(148, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(756, 88);
            this.panelHeader.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(25, 57);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 18);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "username";
            // 
            // panelItems
            // 
            this.panelItems.BackColor = System.Drawing.Color.Gainsboro;
            this.panelItems.Controls.Add(this.btnResetSelectedItem);
            this.panelItems.Controls.Add(this.btnAddToCart);
            this.panelItems.Controls.Add(this.dataGridItems);
            this.panelItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItems.Location = new System.Drawing.Point(148, 88);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(756, 396);
            this.panelItems.TabIndex = 3;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Enabled = false;
            this.btnAddToCart.Location = new System.Drawing.Point(43, 342);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(109, 47);
            this.btnAddToCart.TabIndex = 1;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dataGridItems
            // 
            this.dataGridItems.AllowUserToAddRows = false;
            this.dataGridItems.AllowUserToDeleteRows = false;
            this.dataGridItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridItems.Location = new System.Drawing.Point(43, 35);
            this.dataGridItems.Name = "dataGridItems";
            this.dataGridItems.Size = new System.Drawing.Size(588, 288);
            this.dataGridItems.TabIndex = 0;
            // 
            // panelCompare
            // 
            this.panelCompare.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCompare.Controls.Add(this.lblMostExpensiveItems);
            this.panelCompare.Controls.Add(this.lblCheapestItems);
            this.panelCompare.Controls.Add(this.lblChainCompare);
            this.panelCompare.Controls.Add(this.listBoxMostExpensiveItems);
            this.panelCompare.Controls.Add(this.listBoxCheapesetItems);
            this.panelCompare.Controls.Add(this.listBoxChainCompare);
            this.panelCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCompare.Location = new System.Drawing.Point(148, 88);
            this.panelCompare.Name = "panelCompare";
            this.panelCompare.Size = new System.Drawing.Size(756, 396);
            this.panelCompare.TabIndex = 4;
            // 
            // lblMostExpensiveItems
            // 
            this.lblMostExpensiveItems.AutoSize = true;
            this.lblMostExpensiveItems.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostExpensiveItems.Location = new System.Drawing.Point(516, 15);
            this.lblMostExpensiveItems.Name = "lblMostExpensiveItems";
            this.lblMostExpensiveItems.Size = new System.Drawing.Size(129, 16);
            this.lblMostExpensiveItems.TabIndex = 3;
            this.lblMostExpensiveItems.Text = "Most expensive items";
            // 
            // lblCheapestItems
            // 
            this.lblCheapestItems.AutoSize = true;
            this.lblCheapestItems.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheapestItems.Location = new System.Drawing.Point(270, 15);
            this.lblCheapestItems.Name = "lblCheapestItems";
            this.lblCheapestItems.Size = new System.Drawing.Size(96, 16);
            this.lblCheapestItems.TabIndex = 3;
            this.lblCheapestItems.Text = "Cheapest items";
            // 
            // lblChainCompare
            // 
            this.lblChainCompare.AutoSize = true;
            this.lblChainCompare.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChainCompare.Location = new System.Drawing.Point(25, 15);
            this.lblChainCompare.Name = "lblChainCompare";
            this.lblChainCompare.Size = new System.Drawing.Size(102, 16);
            this.lblChainCompare.TabIndex = 3;
            this.lblChainCompare.Text = "Chains Compare";
            // 
            // listBoxMostExpensiveItems
            // 
            this.listBoxMostExpensiveItems.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMostExpensiveItems.FormattingEnabled = true;
            this.listBoxMostExpensiveItems.ItemHeight = 15;
            this.listBoxMostExpensiveItems.Location = new System.Drawing.Point(519, 35);
            this.listBoxMostExpensiveItems.Name = "listBoxMostExpensiveItems";
            this.listBoxMostExpensiveItems.Size = new System.Drawing.Size(218, 304);
            this.listBoxMostExpensiveItems.TabIndex = 2;
            // 
            // listBoxCheapesetItems
            // 
            this.listBoxCheapesetItems.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCheapesetItems.FormattingEnabled = true;
            this.listBoxCheapesetItems.ItemHeight = 15;
            this.listBoxCheapesetItems.Location = new System.Drawing.Point(273, 35);
            this.listBoxCheapesetItems.Name = "listBoxCheapesetItems";
            this.listBoxCheapesetItems.Size = new System.Drawing.Size(218, 304);
            this.listBoxCheapesetItems.TabIndex = 1;
            // 
            // listBoxChainCompare
            // 
            this.listBoxChainCompare.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxChainCompare.FormattingEnabled = true;
            this.listBoxChainCompare.ItemHeight = 15;
            this.listBoxChainCompare.Location = new System.Drawing.Point(28, 35);
            this.listBoxChainCompare.Name = "listBoxChainCompare";
            this.listBoxChainCompare.Size = new System.Drawing.Size(218, 304);
            this.listBoxChainCompare.TabIndex = 0;
            // 
            // panelShoppingCart
            // 
            this.panelShoppingCart.BackColor = System.Drawing.Color.Gainsboro;
            this.panelShoppingCart.Controls.Add(this.btnLoadCartFromFile);
            this.panelShoppingCart.Controls.Add(this.btnSaveCartToFile);
            this.panelShoppingCart.Controls.Add(this.dataGridViewCart);
            this.panelShoppingCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShoppingCart.Location = new System.Drawing.Point(148, 88);
            this.panelShoppingCart.Name = "panelShoppingCart";
            this.panelShoppingCart.Size = new System.Drawing.Size(756, 396);
            this.panelShoppingCart.TabIndex = 4;
            // 
            // btnLoadCartFromFile
            // 
            this.btnLoadCartFromFile.Location = new System.Drawing.Point(172, 342);
            this.btnLoadCartFromFile.Name = "btnLoadCartFromFile";
            this.btnLoadCartFromFile.Size = new System.Drawing.Size(109, 47);
            this.btnLoadCartFromFile.TabIndex = 4;
            this.btnLoadCartFromFile.Text = "Load From File";
            this.btnLoadCartFromFile.UseVisualStyleBackColor = true;
            this.btnLoadCartFromFile.Click += new System.EventHandler(this.btnLoadCartFromFile_Click);
            // 
            // btnSaveCartToFile
            // 
            this.btnSaveCartToFile.Enabled = false;
            this.btnSaveCartToFile.Location = new System.Drawing.Point(43, 342);
            this.btnSaveCartToFile.Name = "btnSaveCartToFile";
            this.btnSaveCartToFile.Size = new System.Drawing.Size(109, 47);
            this.btnSaveCartToFile.TabIndex = 3;
            this.btnSaveCartToFile.Text = "Save To File";
            this.btnSaveCartToFile.UseVisualStyleBackColor = true;
            this.btnSaveCartToFile.Click += new System.EventHandler(this.btnSaveCartToFile_Click);
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AllowUserToAddRows = false;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(43, 35);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.Size = new System.Drawing.Size(588, 288);
            this.dataGridViewCart.TabIndex = 2;
            // 
            // panelExcelChart
            // 
            this.panelExcelChart.Controls.Add(this.pictureBoxChart);
            this.panelExcelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExcelChart.Location = new System.Drawing.Point(148, 88);
            this.panelExcelChart.Name = "panelExcelChart";
            this.panelExcelChart.Size = new System.Drawing.Size(756, 396);
            this.panelExcelChart.TabIndex = 4;
            // 
            // pictureBoxChart
            // 
            this.pictureBoxChart.Location = new System.Drawing.Point(43, 35);
            this.pictureBoxChart.Name = "pictureBoxChart";
            this.pictureBoxChart.Size = new System.Drawing.Size(588, 349);
            this.pictureBoxChart.TabIndex = 0;
            this.pictureBoxChart.TabStop = false;
            // 
            // btnResetSelectedItem
            // 
            this.btnResetSelectedItem.Location = new System.Drawing.Point(172, 342);
            this.btnResetSelectedItem.Name = "btnResetSelectedItem";
            this.btnResetSelectedItem.Size = new System.Drawing.Size(109, 47);
            this.btnResetSelectedItem.TabIndex = 2;
            this.btnResetSelectedItem.Text = "Reset";
            this.btnResetSelectedItem.UseVisualStyleBackColor = true;
            this.btnResetSelectedItem.Click += new System.EventHandler(this.btnResetSelectedItem_Click);
            // 
            // pictureBoxHeader
            // 
            this.pictureBoxHeader.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHeader.Image")));
            this.pictureBoxHeader.Location = new System.Drawing.Point(156, 5);
            this.pictureBoxHeader.Name = "pictureBoxHeader";
            this.pictureBoxHeader.Size = new System.Drawing.Size(442, 83);
            this.pictureBoxHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHeader.TabIndex = 1;
            this.pictureBoxHeader.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 484);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.panelExcelChart);
            this.Controls.Add(this.panelCompare);
            this.Controls.Add(this.panelShoppingCart);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSide.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItems)).EndInit();
            this.panelCompare.ResumeLayout(false);
            this.panelCompare.PerformLayout();
            this.panelShoppingCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.panelExcelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.DataGridView dataGridItems;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Panel panelCompare;
        private System.Windows.Forms.Label lblMostExpensiveItems;
        private System.Windows.Forms.Label lblCheapestItems;
        private System.Windows.Forms.Label lblChainCompare;
        private System.Windows.Forms.ListBox listBoxMostExpensiveItems;
        private System.Windows.Forms.ListBox listBoxCheapesetItems;
        private System.Windows.Forms.ListBox listBoxChainCompare;
        private System.Windows.Forms.Panel panelShoppingCart;
        private System.Windows.Forms.Button btnLoadCartFromFile;
        private System.Windows.Forms.Button btnSaveCartToFile;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnExcelChart;
        private System.Windows.Forms.Panel panelExcelChart;
        private System.Windows.Forms.PictureBox pictureBoxChart;
        private System.Windows.Forms.Button btnResetSelectedItem;
        private System.Windows.Forms.PictureBox pictureBoxHeader;
    }
}

