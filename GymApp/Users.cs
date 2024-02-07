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
    public partial class Users : Form
    {
        Functions Con;
        public Users()
        {
            InitializeComponent();
            Con = new Functions();
            ShowUsers();
            GridViewUsers.Columns[0].Visible = false;
            GridViewUsers.Columns[5].HeaderText = "Admin";
            GridViewUsers.SelectionChanged += GridViewUsers_SelectionChanged;
            bool admin = isAdmin.Checked;
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
            isAdmin.Checked = false;
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
                    string number = Phone.Text;
                    string email = Mail.Text;
                    string admin = isAdmin.Checked.ToString();
                    string Query = "Insert into UsersTable Values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, user, pass, number, email, admin);
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

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Username.Text == "" || Password.Text == "" || Phone.Text == "")
                {
                    MessageBox.Show("Please enter the required fields!!");
                }

                else
                {
                    int Key = int.Parse(GridViewUsers.CurrentRow.Cells[0].Value.ToString());
                    string user = Username.Text;
                    string pass = Password.Text;
                    string number = Phone.Text;
                    string email = Mail.Text;
                    bool admin = Convert.ToBoolean(isAdmin.Checked);
                    string Query = "Update UsersTable set Username ='{0}', Password = '{1}', Phone ='{2}', Mail = '{3}', isAdmin = '{4}' Where UserID = {5}";
                    Query = string.Format(Query, user, pass, number, email, admin, Key);
                    Con.setData(Query);
                    ShowUsers();
                    MessageBox.Show("User Updated");
                    Reset();
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
                Password.Text = GridViewUsers.CurrentRow.Cells[2].Value.ToString();
                Phone.Text = GridViewUsers.CurrentRow.Cells[3].Value.ToString();
                Mail.Text = GridViewUsers.CurrentRow.Cells[4].Value.ToString();
                bool admin = (bool)GridViewUsers.CurrentRow.Cells["isAdmin"].Value;
                isAdmin.Checked = admin;
            }
                
        } 
    }
}
