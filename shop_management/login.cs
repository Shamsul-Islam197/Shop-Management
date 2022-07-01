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
    public partial class login : Form
    {
        public login()
        {

          
            InitializeComponent();
        }

        

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor=Color.White;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `user_name`=@usn and `password`=@pass",db.getConnection());


            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count>0)
            {
                this.Hide();
                HomeForm homeform = new HomeForm();
                homeform.Show();
            }
            else
            {
                MessageBox.Show("Username or Password didn't match");
            }
        }

        

        private void Gotosignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
        }

        private void Gotosignup_MouseEnter(object sender, EventArgs e)
        {
            Gotosignup.ForeColor = Color.Yellow;
        }

        private void Gotosignup_MouseLeave(object sender, EventArgs e)
        {
            Gotosignup.ForeColor = Color.White;
        }

        

         }
}
