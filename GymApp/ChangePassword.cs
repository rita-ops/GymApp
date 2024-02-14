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
    public partial class ChangePassword : Form
    {

        Functions Con;
        // Placeholder for the current password (this should come from your application's data)
        private string currentPassword = "current_password";
        bool adm; // No need to assign Program.IsAdmin here

        public ChangePassword()
        {
            InitializeComponent();
            Con = new Functions();
            // Compare the isAdmin property with the current value of Program.IsAdmin
            if (adm != Program.IsAdmin)
            {
                label12.Visible = true;
                usericon.Visible = true;
            }
            else
            {
                label12.Visible = false;
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
           // Members Obj = new Members();
            //Obj.Show();
           // this.Hide();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check if the old password is correct
            if (oldPassword == currentPassword)
            {
                // Check if the new password and confirmation match
                if (newPassword == confirmPassword)
                {
                    // Update the password (in this example, just updating the placeholder)
                    currentPassword = newPassword;

                    // Optionally, you can save the updated password to your database or application
                    string Query = "UPDATE UsersTable SET Password = @NewPassword WHERE Username = @Username";
                    Query = string.Format(Query, currentPassword);
                    Con.setData(Query);

                    MessageBox.Show("Password changed successfully!");
                    this.Close(); // Close the form or navigate to another page as needed
                }
                else
                {
                    MessageBox.Show("New password and confirmation do not match.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect old password. Please try again.");
            }
        }
     
    }
}
