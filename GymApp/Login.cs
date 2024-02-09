using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
            checkBoxShowPassword.CheckedChanged += CheckBoxShowPassword_CheckedChanged;
        }
        public static int UserId;

        private void Login_Click(object sender, EventArgs e)
        {

            if (Username.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Invalid Credentials! Please try again.");
            }
            else
            {
                try

                {
                    string Query = "select * from UsersTable where Username = '{0}' and Password = '{1}'";
                    Query = string.Format(Query, Username.Text, Password.Text);
                    DataTable dt = Con.GetData(Query);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Credentials!");
                    }

                    else
                    {
                        UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                        Members Obj = new Members();
                        Obj.Show();
                        this.Hide();  
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the password visibility based on the CheckBox state
            Password.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }
    }
}
