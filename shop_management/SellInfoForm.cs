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
    public partial class SellInfoForm : Form
    {
        DB db = new DB();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public SellInfoForm()
        {
            InitializeComponent();
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productform = new ProductForm();
            productform.Show();
        }

        private void buttonEmployeeInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm employee = new EmployeeForm();
            employee.Show();
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

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeForm home = new HomeForm();
            home.Show();
        }

        private void populate(string transaction, String date, String time, string employee_id, string customer_id, String bill)
        {
            SellInfodataGridView.Rows.Add(transaction, date, time, employee_id, customer_id, bill);
        }

        private void retrieve()
        {

            SellInfodataGridView.ColumnCount = 6;
            SellInfodataGridView.Columns[0].Name = "Transaction ID";
            SellInfodataGridView.Columns[1].Name = "Date";
            SellInfodataGridView.Columns[2].Name = "Time";
            SellInfodataGridView.Columns[3].Name = "Employee ID";
            SellInfodataGridView.Columns[4].Name = "Customer ID";
            SellInfodataGridView.Columns[5].Name = "Bill";

            SellInfodataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SellInfodataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SellInfodataGridView.MultiSelect = false;

            SellInfodataGridView.Rows.Clear();

            string sql = "SELECT * FROM sell_info";
            cmd = new MySqlCommand(sql, db.getConnection());
            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
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

        private void update(int transaction, String bill)
        {
            String sql = "UPDATE sell_info SET bill='" + bill + "' WHERE transaction=" + transaction + " ";

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

        private void delete(int transaction)
        {
            string sql = "DELETE FROM sell_info WHERE transaction=" + transaction + "";
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

            textBoxBill.Text = "";
           
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String selected = SellInfodataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int transaction = Convert.ToInt32(selected);

            update(transaction, textBoxBill.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String selected = SellInfodataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int transaction = Convert.ToInt32(selected);
            delete(transaction);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cleartxt();
        }

        private void buttonRetrieve_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void SellInfodataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxBill.Text = SellInfodataGridView.SelectedRows[0].Cells[5].Value.ToString();
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
