namespace shop_management
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.buttonStat = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.buttonSellInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.Home = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.CustomerInfo = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonEmployeeInfo = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.ProductdataGridView = new System.Windows.Forms.DataGridView();
            this.panelproduct = new System.Windows.Forms.Panel();
            this.buttonRetrieve = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxProductAvailable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.productprice = new System.Windows.Forms.Label();
            this.productname = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelMaximized = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductdataGridView)).BeginInit();
            this.panelproduct.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel6.Controls.Add(this.panel14);
            this.panel6.Controls.Add(this.buttonStat);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.buttonSellInfo);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.Home);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.CustomerInfo);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.buttonEmployeeInfo);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.buttonProduct);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 510);
            this.panel6.TabIndex = 4;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Orange;
            this.panel14.Location = new System.Drawing.Point(16, 298);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 29);
            this.panel14.TabIndex = 17;
            // 
            // buttonStat
            // 
            this.buttonStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStat.FlatAppearance.BorderSize = 0;
            this.buttonStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStat.ForeColor = System.Drawing.Color.White;
            this.buttonStat.Location = new System.Drawing.Point(0, 300);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(200, 29);
            this.buttonStat.TabIndex = 16;
            this.buttonStat.Text = "Statistical View";
            this.buttonStat.UseVisualStyleBackColor = true;
            this.buttonStat.Click += new System.EventHandler(this.buttonStat_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Orange;
            this.panel11.Location = new System.Drawing.Point(16, 253);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(10, 29);
            this.panel11.TabIndex = 15;
            // 
            // buttonSellInfo
            // 
            this.buttonSellInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSellInfo.FlatAppearance.BorderSize = 0;
            this.buttonSellInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSellInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSellInfo.ForeColor = System.Drawing.Color.White;
            this.buttonSellInfo.Location = new System.Drawing.Point(0, 251);
            this.buttonSellInfo.Name = "buttonSellInfo";
            this.buttonSellInfo.Size = new System.Drawing.Size(200, 29);
            this.buttonSellInfo.TabIndex = 14;
            this.buttonSellInfo.Text = "Sell Info";
            this.buttonSellInfo.UseVisualStyleBackColor = true;
            this.buttonSellInfo.Click += new System.EventHandler(this.buttonSellInfo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::shop_management.Properties.Resources.Untitled_1;
            this.pictureBox1.Location = new System.Drawing.Point(69, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Orange;
            this.panel10.Location = new System.Drawing.Point(13, 343);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 29);
            this.panel10.TabIndex = 10;
            // 
            // Home
            // 
            this.Home.FlatAppearance.BorderSize = 0;
            this.Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.Color.White;
            this.Home.Location = new System.Drawing.Point(0, 349);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(200, 23);
            this.Home.TabIndex = 9;
            this.Home.Text = "Go to Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Orange;
            this.panel9.Location = new System.Drawing.Point(16, 208);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 29);
            this.panel9.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Point of Sale";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Orange;
            this.panel8.Location = new System.Drawing.Point(16, 163);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 29);
            this.panel8.TabIndex = 6;
            // 
            // CustomerInfo
            // 
            this.CustomerInfo.FlatAppearance.BorderSize = 0;
            this.CustomerInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerInfo.ForeColor = System.Drawing.Color.White;
            this.CustomerInfo.Location = new System.Drawing.Point(0, 165);
            this.CustomerInfo.Name = "CustomerInfo";
            this.CustomerInfo.Size = new System.Drawing.Size(200, 23);
            this.CustomerInfo.TabIndex = 5;
            this.CustomerInfo.Text = "Customer Info";
            this.CustomerInfo.UseVisualStyleBackColor = true;
            this.CustomerInfo.Click += new System.EventHandler(this.CustomerInfo_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Orange;
            this.panel7.Location = new System.Drawing.Point(16, 118);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 29);
            this.panel7.TabIndex = 4;
            // 
            // buttonEmployeeInfo
            // 
            this.buttonEmployeeInfo.FlatAppearance.BorderSize = 0;
            this.buttonEmployeeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmployeeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmployeeInfo.ForeColor = System.Drawing.Color.White;
            this.buttonEmployeeInfo.Location = new System.Drawing.Point(0, 122);
            this.buttonEmployeeInfo.Name = "buttonEmployeeInfo";
            this.buttonEmployeeInfo.Size = new System.Drawing.Size(200, 23);
            this.buttonEmployeeInfo.TabIndex = 3;
            this.buttonEmployeeInfo.Text = "Employee Info";
            this.buttonEmployeeInfo.UseVisualStyleBackColor = true;
            this.buttonEmployeeInfo.Click += new System.EventHandler(this.buttonEmployeeInfo_Click_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Orange;
            this.panel5.Location = new System.Drawing.Point(16, 73);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 29);
            this.panel5.TabIndex = 2;
            // 
            // buttonProduct
            // 
            this.buttonProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProduct.FlatAppearance.BorderSize = 0;
            this.buttonProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProduct.ForeColor = System.Drawing.Color.White;
            this.buttonProduct.Location = new System.Drawing.Point(0, 79);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(200, 23);
            this.buttonProduct.TabIndex = 0;
            this.buttonProduct.Text = "Product Info";
            this.buttonProduct.UseVisualStyleBackColor = true;
            // 
            // ProductdataGridView
            // 
            this.ProductdataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.ProductdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductdataGridView.Location = new System.Drawing.Point(200, 29);
            this.ProductdataGridView.Name = "ProductdataGridView";
            this.ProductdataGridView.Size = new System.Drawing.Size(443, 481);
            this.ProductdataGridView.TabIndex = 5;
            this.ProductdataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductdataGridView_MouseClick);
            // 
            // panelproduct
            // 
            this.panelproduct.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelproduct.Controls.Add(this.buttonRetrieve);
            this.panelproduct.Controls.Add(this.buttonClear);
            this.panelproduct.Controls.Add(this.buttonDelete);
            this.panelproduct.Controls.Add(this.buttonUpdate);
            this.panelproduct.Controls.Add(this.buttonAdd);
            this.panelproduct.Controls.Add(this.textBoxProductAvailable);
            this.panelproduct.Controls.Add(this.label1);
            this.panelproduct.Controls.Add(this.textBoxProductPrice);
            this.panelproduct.Controls.Add(this.productprice);
            this.panelproduct.Controls.Add(this.productname);
            this.panelproduct.Controls.Add(this.textBoxProductName);
            this.panelproduct.Location = new System.Drawing.Point(640, 0);
            this.panelproduct.Name = "panelproduct";
            this.panelproduct.Size = new System.Drawing.Size(246, 510);
            this.panelproduct.TabIndex = 18;
            // 
            // buttonRetrieve
            // 
            this.buttonRetrieve.Location = new System.Drawing.Point(137, 393);
            this.buttonRetrieve.Name = "buttonRetrieve";
            this.buttonRetrieve.Size = new System.Drawing.Size(75, 23);
            this.buttonRetrieve.TabIndex = 19;
            this.buttonRetrieve.Text = "Retrieve";
            this.buttonRetrieve.UseVisualStyleBackColor = true;
            this.buttonRetrieve.Click += new System.EventHandler(this.buttonRetrieve_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(56, 393);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 26;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click_1);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Location = new System.Drawing.Point(165, 354);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 25;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.Location = new System.Drawing.Point(84, 354);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 24;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click_1);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.Location = new System.Drawing.Point(3, 354);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 23;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
            // 
            // textBoxProductAvailable
            // 
            this.textBoxProductAvailable.Location = new System.Drawing.Point(51, 287);
            this.textBoxProductAvailable.Name = "textBoxProductAvailable";
            this.textBoxProductAvailable.Size = new System.Drawing.Size(146, 20);
            this.textBoxProductAvailable.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = " Product Available";
            this.label1.UseMnemonic = false;
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(51, 197);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(146, 20);
            this.textBoxProductPrice.TabIndex = 20;
            // 
            // productprice
            // 
            this.productprice.AutoSize = true;
            this.productprice.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.productprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productprice.Location = new System.Drawing.Point(64, 152);
            this.productprice.Name = "productprice";
            this.productprice.Size = new System.Drawing.Size(121, 20);
            this.productprice.TabIndex = 19;
            this.productprice.Text = " Product Price";
            this.productprice.UseMnemonic = false;
            // 
            // productname
            // 
            this.productname.AutoSize = true;
            this.productname.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.productname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productname.Location = new System.Drawing.Point(61, 62);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(127, 20);
            this.productname.TabIndex = 18;
            this.productname.Text = " Product Name";
            this.productname.UseMnemonic = false;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(51, 107);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(146, 20);
            this.textBoxProductName.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Controls.Add(this.labelMaximized);
            this.panel3.Controls.Add(this.labelMinimize);
            this.panel3.Controls.Add(this.labelHeader);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(687, 29);
            this.panel3.TabIndex = 19;
            // 
            // labelMaximized
            // 
            this.labelMaximized.AutoSize = true;
            this.labelMaximized.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaximized.Location = new System.Drawing.Point(658, 1);
            this.labelMaximized.Name = "labelMaximized";
            this.labelMaximized.Size = new System.Drawing.Size(27, 29);
            this.labelMaximized.TabIndex = 24;
            this.labelMaximized.Text = "+";
            this.labelMaximized.Click += new System.EventHandler(this.labelMaximized_Click);
            this.labelMaximized.MouseEnter += new System.EventHandler(this.labelMaximized_MouseEnter);
            this.labelMaximized.MouseLeave += new System.EventHandler(this.labelMaximized_MouseLeave);
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.Location = new System.Drawing.Point(628, -2);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(24, 31);
            this.labelMinimize.TabIndex = 23;
            this.labelMinimize.Text = "-";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            this.labelMinimize.MouseEnter += new System.EventHandler(this.labelMinimize_MouseEnter);
            this.labelMinimize.MouseLeave += new System.EventHandler(this.labelMinimize_MouseLeave);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(246, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(108, 20);
            this.labelHeader.TabIndex = 19;
            this.labelHeader.Text = "Product Info";
            // 
            // panel12
            // 
            this.panel12.Location = new System.Drawing.Point(0, 29);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(685, 498);
            this.panel12.TabIndex = 18;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 510);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelproduct);
            this.Controls.Add(this.ProductdataGridView);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductForm";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductdataGridView)).EndInit();
            this.panelproduct.ResumeLayout(false);
            this.panelproduct.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button CustomerInfo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button buttonEmployeeInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.DataGridView ProductdataGridView;
        private System.Windows.Forms.Panel panelproduct;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxProductAvailable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProductPrice;
        private System.Windows.Forms.Label productprice;
        private System.Windows.Forms.Label productname;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Button buttonRetrieve;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button buttonSellInfo;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button buttonStat;
        private System.Windows.Forms.Label labelMaximized;
        private System.Windows.Forms.Label labelMinimize;
    }
}