using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace shop_management
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.ToLower().Trim().Equals("First Name"))
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.Black;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstName.Text;
            if (fname.ToLower().Trim().Equals("First Name") || fname.Trim().Equals(""))
            {
                textBoxFirstName.Text = "First Name";
                textBoxFirstName.ForeColor = Color.Gray;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        

        private void textBoxLastName_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastName.Text;
            if (lname.ToLower().Trim().Equals("Last Name"))
            {
                textBoxLastName.Text = "";
                textBoxLastName.ForeColor = Color.Black;
            }
        }

        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastName.Text;
            if (lname.ToLower().Trim().Equals("Last Name") || lname.Trim().Equals(""))
            {
                textBoxLastName.Text = "Last Name";
                textBoxLastName.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("Email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("Email") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "Email";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        

        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            String uname = textBoxUserName.Text;
            if (uname.ToLower().Trim().Equals("User Name"))
            {
                textBoxUserName.Text = "";
                textBoxUserName.ForeColor = Color.Black;
            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            String uname = textBoxUserName.Text;
            if (uname.ToLower().Trim().Equals("User Name") || uname.Trim().Equals(""))
            {
                textBoxUserName.Text = "User Name";
                textBoxUserName.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String pass = textBoxPassword.Text;
            if (pass.ToLower().Trim().Equals("Password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String pass = textBoxPassword.Text;
            if (pass.ToLower().Trim().Equals("Password") || pass.Trim().Equals(""))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            String cpass = textBoxConfirmPassword.Text;
            if (cpass.ToLower().Trim().Equals("Confirm Password"))
            {
                textBoxConfirmPassword.Text = "";
                textBoxConfirmPassword.UseSystemPasswordChar = true;
                textBoxConfirmPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            String cpass = textBoxConfirmPassword.Text;
            if (cpass.ToLower().Trim().Equals("Confirm Password") ||
                cpass.ToLower().Trim().Equals("Password") ||
                cpass.Trim().Equals(""))
            {
                textBoxConfirmPassword.Text = "Confirm Password";
                textBoxConfirmPassword.UseSystemPasswordChar = false;
                textBoxConfirmPassword.ForeColor = Color.Gray;
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `user`(`first_name`, `last_name`, `email`, `user_name`, `password`) VALUES (@fn,@ln,@email,@usn,@pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstName.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastName.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUserName.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            db.openConnection();

            if (!checkTextBoxesValues())
            {
                if (textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
                {
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists,Select Different One", "Duplicate User Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Account Created", "AccountCreated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            login login = new login();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Did not Match", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter Your Information First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }




            db.closeConnection();
        }
        public Boolean checkUsername()
        {
            DB db = new DB();
            String username = textBoxUserName.Text;


            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `user_name`=@usn", db.getConnection());


            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;


            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstName.Text;
            String lname = textBoxLastName.Text;
            String email = textBoxEmail.Text;
            String uname = textBoxUserName.Text;
            String pass = textBoxPassword.Text;

            if (fname.Equals("Fisrt Name") || lname.Equals("Last Name") ||
                email.Equals("Email") || uname.Equals("User Name") ||
                pass.Equals("Password"))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void Gotosignin_MouseEnter(object sender, EventArgs e)
        {
            Gotosignin.ForeColor = Color.Yellow;
        }

        private void Gotosignin_MouseLeave(object sender, EventArgs e)
        {
            Gotosignin.ForeColor = Color.White;
        }

        private void Gotosignin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginform = new login();
            loginform.Show();
        }

    }
}
