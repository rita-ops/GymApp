using System;
using System.Data;
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
                return;
            }
            else
            {
                try
                {
                    string Query = "select * from UsersTable where Username = '{0}'";
                    Query = string.Format(Query, Username.Text);
                    DataTable dt = Con.GetData(Query);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("User does not exist.");
                        return;
                    }
                    else
                    {
                        string storedPassword = dt.Rows[0]["Password"].ToString();
                        string defaultPassword = "P@ssw0rd"; // Change this to your default password

                        if (Password.Text == defaultPassword)
                        {
                            // Redirect user to change password form
                            ChangePassword changePasswordForm = new ChangePassword();
                            changePasswordForm.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                            changePasswordForm.ShowDialog();
                        }
                        else if (Password.Text != storedPassword)
                        {
                            MessageBox.Show("Invalid password.");
                            return;
                        }
                        else
                        {
                            Program.IsAdmin = Convert.ToBoolean(dt.Rows[0]["isAdmin"]);
                            UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);

                            Members Obj = new Members();
                            Obj.Show();
                            this.Hide();
                        }
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

        private void linkforgetpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string Query = "select * from UsersTable where Username = '{0}'";
            Query = string.Format(Query, Username.Text);
            DataTable dt = Con.GetData(Query);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User does not exist.");
                return;
            }
            else
            {
                {
                    // Redirect user to change password form
                    ChangePassword changePasswordForm = new ChangePassword();
                    changePasswordForm.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    changePasswordForm.ShowDialog();
                }
            }
        }
    }
}

