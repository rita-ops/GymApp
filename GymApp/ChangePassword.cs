using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace GymApp
{
    public partial class ChangePassword : Form
    {

        Functions Con;
        bool adm; // No need to assign Program.IsAdmin here

        public int UserId { get; internal set; }

        public ChangePassword()
        {
            InitializeComponent();
            Con = new Functions();
            // Compare the isAdmin property with the current value of Program.IsAdmin
            if (adm != Program.IsAdmin)
            {
                UsersLbl.Visible = true;
                usericon.Visible = true;
            }
            else
            {
                UsersLbl.Visible = false;
                usericon.Visible = false;
            }
            // Update the local variable to match the current state of Program.IsAdmin
            adm = Program.IsAdmin;
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void MemberShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void TrainersLbl_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
            Obj.Show();
            this.Hide();
        }

        private void PaymentLbl_Click(object sender, EventArgs e)
        {
            Payments Obj = new Payments();
            Obj.Show();
            this.Hide();
        }

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }

        private void Users_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void ChangePassLbl_Click(object sender, EventArgs e)
        {
            ChangePassword Obj = new ChangePassword();
            Obj.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text == "" || txtConfPassword.Text == "")
                {
                    MessageBox.Show("Please enter the new password");
                    return;
                }

                else if (txtNewPassword.Text != txtConfPassword.Text)
                {
                    MessageBox.Show("New password and confirm password do not match.");
                    return;
                }

                string newPassword = txtNewPassword.Text;

                // Update the password in the database
                string Query = "UPDATE UsersTable SET Password = '{0}' WHERE UserId = {1}";
                Query = string.Format(Query, newPassword, UserId);
                Con.setData(Query);
                MessageBox.Show("Password changed successfully.");

                // Clear the textboxes
                txtNewPassword.Text = "";
                txtConfPassword.Text = "";

                // Redirect to the login form
                Login Obj = new Login();
                Obj.Name = ""; // Reset the username text box
                Obj.Text = ""; 
                Obj.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }
    }
}
