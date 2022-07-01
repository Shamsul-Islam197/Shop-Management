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
    public partial class EmployeeForm : Form
    {
        DB db = new DB();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public EmployeeForm()
        {
            
            InitializeComponent();
        }

        private void populate(String id, String employee_name, String employee_address, String employee_phone, String employee_email, String employee_sale)
        {
            EmployeedataGridView.Rows.Add(id, employee_name, employee_address, employee_phone, employee_email, employee_sale);
        }

        private void add(String employee_name, String employee_address, String employee_phone, String employee_email, String employee_sale)
        {
            string sql = "INSERT INTO employee_info(employee_name, employee_address, employee_phone,employee_email,employee_sale) VALUES(@ename,@eadd,@ephone,@eemail,@esale)";
            cmd = new MySqlCommand(sql, db.getConnection());

            cmd.Parameters.AddWithValue("@ename", employee_name);
            cmd.Parameters.AddWithValue("@eadd", employee_address);
            cmd.Parameters.AddWithValue("@ephone", employee_phone);
            cmd.Parameters.AddWithValue("@eemail", employee_email);
            cmd.Parameters.AddWithValue("@esale", employee_sale);

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
            
            EmployeedataGridView.ColumnCount = 6;
            EmployeedataGridView.Columns[0].Name = "Employee ID";
            EmployeedataGridView.Columns[1].Name = "Employee Name";
            EmployeedataGridView.Columns[2].Name = "Employee Address";
            EmployeedataGridView.Columns[3].Name = "Employee Phone";
            EmployeedataGridView.Columns[4].Name = "Employee Email";
            EmployeedataGridView.Columns[5].Name = "Employee Sale";

            EmployeedataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            EmployeedataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EmployeedataGridView.MultiSelect = false;

            EmployeedataGridView.Rows.Clear();

            string sql = "SELECT * FROM employee_info";
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

        private void delete(int id)
        {
            string sql = "DELETE FROM employee_info WHERE id=" + id + "";
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

            textBoxEmployeeName.Text = "";
            textBoxEmployeeAddress.Text = "";
            textBoxEmployeePhone.Text = "";
            textBoxEmployeeEmail.Text = "";
            textBoxEmployeeSale.Text = "";
        }

        private void update(int id,String employee_name, String employee_address, String employee_phone, String employee_email, String employee_sale)
        {
            String sql = "UPDATE employee_info SET employee_name='" + employee_name + "',employee_address='" + employee_address + "', employee_phone='" + employee_phone + "',  employee_email='" + employee_email + "', employee_sale='" + employee_sale + "' WHERE id=" + id + " ";

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
        private void buttonProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productform = new ProductForm();
            productform.Show();
        }

        private void EmployeedataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxEmployeeName.Text = EmployeedataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBoxEmployeeAddress.Text =EmployeedataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBoxEmployeePhone.Text = EmployeedataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBoxEmployeeEmail.Text = EmployeedataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBoxEmployeeSale.Text = EmployeedataGridView.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            add(textBoxEmployeeName.Text, textBoxEmployeeAddress.Text, textBoxEmployeePhone.Text, textBoxEmployeeEmail.Text, textBoxEmployeeSale.Text);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String selected = EmployeedataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            update(id, textBoxEmployeeName.Text, textBoxEmployeeAddress.Text, textBoxEmployeePhone.Text, textBoxEmployeeEmail.Text, textBoxEmployeeSale.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            String selected = EmployeedataGridView.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cleartxt();
        }

        private void buttonEmployeeInfo_Click(object sender, EventArgs e)
        {
            retrieve();
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
