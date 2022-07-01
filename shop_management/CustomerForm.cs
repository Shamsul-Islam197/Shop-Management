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
    public partial class CustomerForm : Form
    {
        DB db = new DB();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void populate(String id, String customer_name, String customer_address, String customer_phone, String customer_bill)
        {
            CustomerdataGridView.Rows.Add(id, customer_name, customer_address, customer_phone, customer_bill);
        }

        private void add(String customer_name, String customer_address, String customer_phone, String customer_bill)
        {
            string sql = "INSERT INTO customer_info(customer_name, customer_address, customer_phone,customer_bill) VALUES(@cname,@cadd,@cphone,@cbill)";
            cmd = new MySqlCommand(sql, db.getConnection());

            cmd.Parameters.AddWithValue("@cname", customer_name);
            cmd.Parameters.AddWithValue("@cadd", customer_address);
            cmd.Parameters.AddWithValue("@cphone", customer_phone);
            cmd.Parameters.AddWithValue("@cbill", customer_bill);
            

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

            CustomerdataGridView.ColumnCount = 5;
            CustomerdataGridView.Columns[0].Name = "Customer ID";
            CustomerdataGridView.Columns[1].Name = "Customer Name";
            CustomerdataGridView.Columns[2].Name = "Customer Address";
            CustomerdataGridView.Columns[3].Name = "Customer Phone";
            CustomerdataGridView.Columns[4].Name = "Customer Bill";


            CustomerdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CustomerdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerdataGridView.MultiSelect = false;

            CustomerdataGridView.Rows.Clear();

            string sql = "SELECT * FROM customer_info";
            cmd = new MySqlCommand(sql, db.getConnection());
            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
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

        private void delete(int id)
        {
            string sql = "DELETE FROM customer_info WHERE id=" + id + "";
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

            textBoxCustomerName.Text = "";
            textBoxCustomerAddress.Text = "";
            textBoxCustomerPhone.Text = "";
            textBoxCustomerBill.Text = "";
           
        }

        private void update(int id, String customer_name, String customer_address, String customer_phone, String customer_bill)
        {
            String sql = "UPDATE customer_info SET customer_name='" + customer_name + "',customer_address='" + customer_address + "', customer_phone='" + customer_phone + "',  customer_bill='" + customer_bill + "' WHERE id=" + id + " ";

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

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeForm home = new HomeForm();
            home.Show();
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm product = new ProductForm();
            product.Show();

        }

        private void buttonEmployeeInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
           EmployeeForm employee = new EmployeeForm();
            employee.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            add(textBoxCustomerName.Text, textBoxCustomerAddress.Text, textBoxCustomerPhone.Text, textBoxCustomerBill.Text);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String selected = CustomerdataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            update(id, textBoxCustomerName.Text, textBoxCustomerAddress.Text, textBoxCustomerPhone.Text, textBoxCustomerBill.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String selected = CustomerdataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cleartxt();
        }

        

        private void CustomerdataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxCustomerName.Text = CustomerdataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBoxCustomerAddress.Text = CustomerdataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBoxCustomerPhone.Text = CustomerdataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBoxCustomerBill.Text = CustomerdataGridView.SelectedRows[0].Cells[4].Value.ToString();
      
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

        private void buttonRetrieve_Click(object sender, EventArgs e)
        {
            retrieve();
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
