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
    public partial class StatForm : Form
    {
        DB db = new DB();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public StatForm()
        {
            InitializeComponent();
            retrieve();
            stat();
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

        private void buttonSellInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellInfoForm sell = new SellInfoForm();
            sell.Show();
        }

        private void populate(String date, String bill)
        {
            StatdataGridView.Rows.Add(date, bill);
        }

        private void retrieve()
        {

            StatdataGridView.ColumnCount = 2;
            StatdataGridView.Columns[0].Name = "Date";
            StatdataGridView.Columns[1].Name = "Bill";


            StatdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            StatdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StatdataGridView.MultiSelect = false;

            StatdataGridView.Rows.Clear();

            string sql = "SELECT date,sum(bill)as total FROM sell_info GROUP BY date";
            cmd = new MySqlCommand(sql, db.getConnection());
            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString());
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


        private void stat()
        {
            string sql = "SELECT date,sum(bill)as total FROM sell_info GROUP by date; ";

            MySqlCommand cmd = new MySqlCommand(sql, db.getConnection());
            MySqlDataReader myReader;


            try
            {
                db.getConnection().Open();
                myReader = cmd.ExecuteReader();
                while(myReader.Read())
                {
                    this.chartStat.Series["Sell"].Points.AddXY(myReader.GetString("date"), myReader.GetInt32("total"));
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
