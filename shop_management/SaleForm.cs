using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_management
{
    public partial class SaleForm : Form
    {
        DB db = new DB();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();

        public SaleForm()
        {
            InitializeComponent();
            fillcombobox();
        }

        public void fillcombobox()
        {
            String sql = "SELECT * FROM product_info ORDER BY product_name ASC";
            cmd = new MySqlCommand(sql, db.getConnection());

            MySqlDataReader myreader;

            try
            {
                db.getConnection().Open();

                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    String sname = myreader.GetString(1);
                    comboBoxSelectItem.Items.Add(sname);
                    
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
            ProductForm product = new ProductForm();
            product.Show();
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

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeForm home = new HomeForm();
            home.Show();
        }

        private void comboBoxSelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM product_info WHERE product_name='"+ comboBoxSelectItem.Text+ "'; ";
            cmd = new MySqlCommand(sql, db.getConnection());

            MySqlDataReader myreader;

            try
            {
                db.getConnection().Open();

                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    String price = myreader.GetInt32(2).ToString();
                    textBoxPrice.Text = price;
                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();

            }

            textBoxQuantity.Text = "";
            textBoxTotal.Text = "";
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQuantity.Text.Length > 0)
            {
                textBoxTotal.Text = (Convert.ToInt32(textBoxPrice.Text) * Convert.ToInt32(textBoxQuantity.Text)).ToString();
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            String[] ar= new String[4];

            ar[0] = comboBoxSelectItem.SelectedItem.ToString();
            ar[1] = textBoxPrice.Text;
            ar[2] = textBoxQuantity.Text;
            ar[3] = textBoxTotal.Text;

            ListViewItem listview = new ListViewItem(ar);

            ListViewProduct.Items.Add(listview);

            textBoxSubTotal.Text= (Convert.ToInt32(textBoxSubTotal.Text) + Convert.ToInt32(textBoxTotal.Text)).ToString();
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            if(textBoxDiscount.Text.Length>0)
            {
                float percent = (float.Parse(textBoxSubTotal.Text) /100)* (float.Parse(textBoxDiscount.Text));
                textBoxNet.Text = (Convert.ToInt32(textBoxSubTotal.Text) - percent).ToString();
            }
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if(ListViewProduct.SelectedItems.Count>0)
            {
                for(int i=0;i< ListViewProduct.Items.Count; i++)
                {
                    if(ListViewProduct.Items[i].Selected)
                        {
                            textBoxSubTotal.Text= (Convert.ToInt32(textBoxSubTotal.Text) - Convert.ToInt32(ListViewProduct.Items[i].SubItems[3].Text)).ToString();
                            ListViewProduct.Items[i].Remove();
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPrice.Text="";
            textBoxQuantity.Text="";
            textBoxTotal.Text="";
            textBoxSubTotal.Text="0";
            textBoxDiscount.Text ="";
            textBoxNet.Text="";
            textBoxEmployeeId.Text = "";
            textBoxCustomerId.Text = "";

            if (MessageBox.Show("Are you sure??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                
                    ListViewProduct.Items.Clear();
                    MessageBox.Show("List Cleared");
            }

            


        }

        private void eupdate(int id,float bill)
        {
            string sql = "UPDATE employee_info SET employee_sale='" + bill + "' WHERE id=" + id + " ";

            cmd = new MySqlCommand(sql, db.getConnection());

            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = db.getConnection().CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    
                    MessageBox.Show("Employee Sale Updated");
                    db.getConnection().Close();
                    
                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();

            }
        }

        private void cupdate(int id, float bill)
        {
            string sql = "UPDATE customer_info SET customer_bill='" + bill + "' WHERE id=" + id + " ";

            cmd = new MySqlCommand(sql, db.getConnection());

            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = db.getConnection().CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {

                    MessageBox.Show("Customer Bill Updated");
                    db.getConnection().Close();

                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();

            }
        }

        private void eaddbill()
        {
            string id0 = textBoxEmployeeId.Text;
            string id1 = textBoxCustomerId.Text;
            string dc = textBoxDiscount.Text;
            string qty = textBoxQuantity.Text;
            if (id0.Trim().Equals("") || id1.Trim().Equals("") || dc.Trim().Equals("") || qty.Trim().Equals(""))
            {
                MessageBox.Show("Fill all the Fields First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBoxEmployeeId.Text);
                float bill = float.Parse(textBoxNet.Text);


                String sql = "SELECT * FROM employee_info WHERE id='" + id + "' ";
                cmd = new MySqlCommand(sql, db.getConnection());

                MySqlDataReader myreader;

                try
                {
                    db.getConnection().Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        String sale = myreader.GetFloat(5).ToString();
                        float esale = float.Parse(sale);
                        bill = bill + esale;

                    }
                    db.getConnection().Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.getConnection().Close();
                }
                eupdate(id, bill);
            }
        }

        private void caddbill()
        {
            int id = Convert.ToInt32(textBoxCustomerId.Text);
            float bill = float.Parse(textBoxNet.Text);


            String sql = "SELECT * FROM customer_info WHERE id='" + id + "' ";
            cmd = new MySqlCommand(sql, db.getConnection());

            MySqlDataReader myreader;

            try
            {
                db.getConnection().Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    String sale = myreader.GetFloat(4).ToString();
                    float csale = float.Parse(sale);
                    bill = bill + csale;

                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();
            }
            cupdate(id, bill);
        }

        private void pupdate(string name, int avail)
        {
            string sql = "UPDATE product_info SET product_avail='" + avail + "' WHERE product_name=  '" + name + "' ";

            cmd = new MySqlCommand(sql, db.getConnection());

            try
            {
                db.getConnection().Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = db.getConnection().CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {

                    db.getConnection().Close();

                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();

            }
        }

        private void pavail()
        {
            
            int quantity = Convert.ToInt32(textBoxQuantity.Text);
            string name = comboBoxSelectItem.Text;
            
            String sql = "SELECT * From product_info WHERE product_name= '" + name + "' ";
            cmd = new MySqlCommand(sql, db.getConnection());

            MySqlDataReader myreader;

            try
            {
                db.getConnection().Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    
                    String pquantity = myreader.GetInt32(3).ToString();
                   
                    int avail = Convert.ToInt32(pquantity);
                   
                        quantity = avail - quantity;
                    
                }
                db.getConnection().Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();
            }
            pupdate(name, quantity);
        }

        private async void print()
        {
            using(SaveFileDialog sfd=new SaveFileDialog() { Filter="Bill Documents|*.txt",ValidateNames=true})
            {
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    using(TextWriter tw=new StreamWriter(new FileStream(sfd.FileName,FileMode.Create),Encoding.UTF8))
                    {
                        await tw.WriteLineAsync("Item Name\t" + "Price\t" +  "Quantity\t" + "Total\t");

                        foreach (ListViewItem item in ListViewProduct.Items)
                        {
                            await tw.WriteLineAsync(item.SubItems[0].Text + "\t\t" + item.SubItems[1].Text + "\t" + item.SubItems[2].Text + "\t\t" + item.SubItems[3].Text);
                        }
                        await tw.WriteLineAsync("\nSub Total = "+ textBoxSubTotal.Text + "\t Discount % = " + textBoxDiscount.Text + "\tNet Total = " + textBoxNet.Text + "\nEmployee ID = " + textBoxEmployeeId.Text + "\nCustomer ID = " + textBoxCustomerId.Text + "\nDate - " + labelDate.Text + "\nTime - " + labelDate.Text);
                        MessageBox.Show("Printed", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            string id = textBoxEmployeeId.Text;
            string id1 = textBoxCustomerId.Text;
            string dc = textBoxDiscount.Text;
            string qty = textBoxQuantity.Text;
            if (id.Trim().Equals("") || id1.Trim().Equals("") || dc.Trim().Equals("") || qty.Trim().Equals(""))
            {
                MessageBox.Show("Fill all the Fields First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {

                int quantity = Convert.ToInt32(textBoxQuantity.Text);
                string name = comboBoxSelectItem.Text;
                int a = 0;
                String sql = "SELECT * From product_info WHERE product_name= '" + name + "' ";
                cmd = new MySqlCommand(sql, db.getConnection());

                MySqlDataReader myreader;

                try
                {
                    db.getConnection().Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {

                        String pquantity = myreader.GetInt32(3).ToString();

                        int avail = Convert.ToInt32(pquantity);
                        a = avail;
                    }
                    db.getConnection().Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    db.getConnection().Close();
                }


                if (a < quantity)
                {
                    MessageBox.Show("Not Enough Stock Available", "Stock Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                else
                {
                    pavail();
                    eaddbill();
                    caddbill();
                    string date = labelDate.Text;
                    string time = labelTime.Text;
                    float bill = float.Parse(textBoxNet.Text);
                    int eid= Convert.ToInt32(textBoxEmployeeId.Text);
                    int cid= Convert.ToInt32(textBoxCustomerId.Text);
                    isell(date,time,eid,cid,bill);

                }

            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            print();
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelDate.Text = DateTime.Now.ToLongDateString();
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void isell(string date,string time,int eid,int cid, float bill)
        {
            string sql1 = "INSERT INTO sell_info(date,time,employee_id,customer_id,bill) VALUES(@date,@time,@eid,@cid,@bill)";
            cmd = new MySqlCommand(sql1, db.getConnection());

            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@bill", bill);

            try
            {
                db.getConnection().Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    db.getConnection().Close();
                }
                db.getConnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.getConnection().Close();
            }
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
