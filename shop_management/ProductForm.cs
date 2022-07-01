using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_management
{
    public partial class ProductForm : Form
    {
        DB db = new DB();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public ProductForm()
        {
            InitializeComponent();
        }
        private void populate(String id, String product_name, String product_price, String product_avail)
        {
            ProductdataGridView.Rows.Add(id, product_name, product_price, product_avail);
        }

        private void add(String product_name, String product_price, String product_avail)
        {
            string sql = "INSERT INTO product_info(product_name,product_price,product_avail) VALUES(@pname,@pprice,@pavail)";
            cmd = new MySqlCommand(sql, db.getConnection());

            cmd.Parameters.AddWithValue("@pname", product_name);
            cmd.Parameters.AddWithValue("@pprice", product_price);
            cmd.Parameters.AddWithValue("@pavail", product_avail);

            try
            {
                db.getConnection().Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cleartxt();
                    MessageBox.Show("Successfully Inserted");
                    db.getConnection().Close();
                    retrieve();
                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();
            }
        }
        private void retrieve()
        {
            
            ProductdataGridView.ColumnCount = 4;
            ProductdataGridView.Columns[0].Name = "Product ID";
            ProductdataGridView.Columns[1].Name = "Product Name";
            ProductdataGridView.Columns[2].Name = "Product Price";
            ProductdataGridView.Columns[3].Name = "Product Available";

            ProductdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ProductdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProductdataGridView.MultiSelect = false;

            ProductdataGridView.Rows.Clear();

            string sql = "SELECT * FROM product_info";
            cmd = new MySqlCommand(sql, db.getConnection());
            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
                db.getConnection().Close();
                table.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();
            }
        }
        private void buttonProduct_Click(object sender, EventArgs e)
        {


            
            retrieve();

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void update(int id, string product_name, String product_price, String product_avail)
        {
            String sql = "UPDATE product_info SET product_name='" + product_name + "',product_price='" + product_price + "',product_avail='" + product_avail + "' WHERE id=" + id + " ";

            cmd = new MySqlCommand(sql, db.getConnection());

            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = db.getConnection().CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    cleartxt();
                    MessageBox.Show("Successfully Updated");
                    db.getConnection().Close();
                    retrieve();
                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();

            }
        }


        private void delete(int id)
        {
            string sql = "DELETE FROM product_info WHERE id=" + id + "";
            cmd = new MySqlCommand(sql, db.getConnection());

            try
            {
                db.getConnection().Open();

                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = db.getConnection().CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Are you sure??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        cleartxt();
                        MessageBox.Show("Successfully Deleted");
                    }
                }

                db.getConnection().Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();

            }
        }

        private void cleartxt()
        {

            textBoxProductName.Text = "";
            textBoxProductPrice.Text = "";
            textBoxProductAvailable.Text = "";
        }

        private void ProductdataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxProductName.Text = ProductdataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBoxProductPrice.Text = ProductdataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBoxProductAvailable.Text = ProductdataGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            add(textBoxProductName.Text, textBoxProductPrice.Text, textBoxProductAvailable.Text);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String selected = ProductdataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            update(id, textBoxProductName.Text, textBoxProductPrice.Text, textBoxProductAvailable.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String selected = ProductdataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cleartxt();
        }

        private void buttonEmployeeInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm employeeform = new EmployeeForm();
            employeeform.Show();

        }

        

        private void buttonEmployeeInfo_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm employeeform = new EmployeeForm();
            employeeform.Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeForm home = new HomeForm();
            home.Show();
        }

        private void buttonRetrieve_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            add(textBoxProductName.Text, textBoxProductPrice.Text, textBoxProductAvailable.Text);
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            String selected = ProductdataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            update(id, textBoxProductName.Text, textBoxProductPrice.Text, textBoxProductAvailable.Text);
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            String selected = ProductdataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            cleartxt();
        }

        private void CustomerInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customer = new CustomerForm();
            customer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaleForm sale = new SaleForm();
            sale.Show();
        }

        private void buttonSellInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellInfoForm sell = new SellInfoForm();
            sell.Show();
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            this.Hide();
            StatForm stat = new StatForm();
            stat.Show();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void labelMaximized_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
           else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void labelMinimize_MouseEnter(object sender, EventArgs e)
        {
            labelMinimize.ForeColor = Color.Black;
        }

        private void labelMinimize_MouseLeave(object sender, EventArgs e)
        {
            labelMinimize.ForeColor = Color.White;
        }

        private void labelMaximized_MouseEnter(object sender, EventArgs e)
        {
            labelMaximized.ForeColor = Color.Black;
        }

        private void labelMaximized_MouseLeave(object sender, EventArgs e)
        {
            labelMaximized.ForeColor = Color.White;
        }
    }
}
