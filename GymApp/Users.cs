using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class Users : Form
    {
        Functions Con;
        bool adm;
        public Users()
        {
            InitializeComponent();
            Con = new Functions();
            ShowUsers();
            GridViewUsers.Columns[0].Visible = false;
            GridViewUsers.Columns[2].Visible = false;
            GridViewUsers.Columns[5].HeaderText = "Admin";
            GridViewUsers.SelectionChanged += GridViewUsers_SelectionChanged;
            checkBoxShowPassword.CheckedChanged += CheckBoxShowPassword_CheckedChanged;
            bool admin = isAdmin.Checked;
            lblEmailValidation.Visible = false;
            GridViewUsers.CellFormatting += GridViewUsers_CellFormatting;
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

        private void ShowUsers()
        {
            string Query = " SELECT UserID, Username, Password, Phone, Mail, isAdmin  FROM UsersTable";
            GridViewUsers.DataSource = Con.GetData(Query);
            GridViewUsers.ClearSelection();
        }
  
        private void Reset()
        {
            Username.Text = string.Empty;
            Password.Text = string.Empty;
            Phone.Text = string.Empty;
            Mail.Text = string.Empty;
            lblEmailValidation.Visible = false;
            isAdmin.Checked = false;
            checkBoxShowPassword.Checked = false;
        }

        private bool IsUserAlreadyExists(string username)
        {
            foreach (DataGridViewRow row in GridViewUsers.Rows)
            {
                // Assuming "UsernameColumn" is the name of the column containing usernames
                string existingUsername = row.Cells["Username"].Value as string;

                // Check if the username already exists
                if (!string.IsNullOrEmpty(existingUsername) && existingUsername.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // User already exists
                }
            }

            return false; // User does not exist
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {

                if (Username.Text == "" || Password.Text == "" || Phone.Text == "")
                {
                    MessageBox.Show("Please fill required fields!!");
                }

                if (!string.IsNullOrEmpty(Mail.Text))
                {
                    if (IsValidEmail(Mail.Text))
                    {
                        lblEmailValidation.Visible = true;
                        // The email is valid, update the label message.
                        lblEmailValidation.Text = "Email is valid!";
                        lblEmailValidation.ForeColor = System.Drawing.Color.Green;
                    }

                    else
                    {
                        // The email is not valid. Display an error message.
                        MessageBox.Show("Invalid email address. Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Check if the username already exists
                if (IsUserAlreadyExists(Username.Text))
                {
                    MessageBox.Show("User already exists. Choose a different username.");
                    return; // Abort saving
                }
                else
                    {
                    string user = Username.Text;
                    string pass = Password.Text;
                    // Generate a random salt
                    string salt = GenerateSalt();

                    // Combine the password and salt, then hash the result
                    string hashedPassword = HashPassword(pass, salt);
                    string number = Phone.Text;
                    string email = Mail.Text;
                    string admin = isAdmin.Checked.ToString();
                    string Query = "Insert into UsersTable Values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, user, pass, salt, number, email, admin);
                    Con.setData(Query);
                    ShowUsers();
                    MessageBox.Show("User Added");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
        // Use a regular expression to check if the email follows a valid format.
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Username.Text == "" || Phone.Text == "")
                {
                    MessageBox.Show("Please enter the required fields!!");
                }                  
                   else
                   {
                        int Key = int.Parse(GridViewUsers.CurrentRow.Cells[0].Value.ToString());
                        string user = Username.Text;
                        string pass = Password.Text;
                        // Generate a random salt
                        string salt = GenerateSalt();

                        // Combine the password and salt, then hash the result
                        string hashedPassword = HashPassword(pass, salt);
                        string number = Phone.Text;
                        string email = Mail.Text;
                        string admin = isAdmin.Checked.ToString();
                        string Query = "Update UsersTable set Username ='{0}', Password = '{1}', Salt ='{2}', Phone ='{3}', Mail = '{4}', isAdmin = '{5}' Where UserID = {6}";
                        Query = string.Format(Query, user, pass, salt, number, email, admin, Key);
                        Con.setData(Query);
                        ShowUsers();
                        MessageBox.Show("User Updated");
                        Reset();       
                   }

                    if (!string.IsNullOrEmpty(Mail.Text))
                    {
                        if (IsValidEmail(Mail.Text))
                        {
                            lblEmailValidation.Visible = true;
                            lblEmailValidation.Text = "Email is valid!";
                            lblEmailValidation.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            MessageBox.Show("Invalid email address. Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Username.Text == "" || Password.Text == "" || Phone.Text == "" )
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewUsers.CurrentRow.Cells[0].Value.ToString());
                    string Query = "Delete from UsersTable where UserID = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowUsers();
                    MessageBox.Show("Username Deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void GridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (GridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridViewUsers.SelectedRows[0];

                Username.Text = GridViewUsers.CurrentRow.Cells[1].Value.ToString();
                //Password.Text = GridViewUsers.CurrentRow.Cells[2].Value.ToString();
                Password.Text = string.Empty;
                Phone.Text = GridViewUsers.CurrentRow.Cells[3].Value.ToString();
                Mail.Text = GridViewUsers.CurrentRow.Cells[4].Value.ToString();
                bool admin = (bool)GridViewUsers.CurrentRow.Cells["isAdmin"].Value;
                isAdmin.Checked = admin;
            }
                
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the password visibility based on the CheckBox state
            Password.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
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

        private void GridViewUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current cell is in the Password column and the value is not null
            if (e.ColumnIndex == GridViewUsers.Columns["Password"].Index && e.Value != null)
            {
                // Replace the displayed value with the encrypted version
                e.Value = EncryptPassword(e.Value.ToString());
            }
        }

        private string EncryptPassword(string plainText)
        {
            // Generate a random salt
            string salt = GenerateSalt();

            // Combine the password and salt, then hash the result
            string hashedPassword = HashPassword(plainText, salt);

            // Store the salt and hashed password (you'll need to save these values in your database)
            string storedPassword = salt + hashedPassword;

            return storedPassword;
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16]; // Choose an appropriate size for your salt
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
