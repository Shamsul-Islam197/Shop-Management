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
    public partial class HomeForm : Form
    {

        public HomeForm()
        {
            InitializeComponent();
 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
            EmployeeForm employeeform = new EmployeeForm();
            employeeform.Show();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Log Out", MessageBoxButtons.YesNo);
           if(dialog==DialogResult.Yes )
            {
                this.Hide();
                login login = new login();
                login.Show();
            }
            
        }

        private void CustomerInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customer = new CustomerForm();
            customer.Show();
        }

        private void buttonPointofSale_Click(object sender, EventArgs e)
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
            if(WindowState==FormWindowState.Normal)
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
