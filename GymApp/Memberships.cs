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
    public partial class Memberships : Form
    {
        Functions Con;
        public Memberships()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMemberships();
            GridViewMemberships.Columns[0].Visible = false;
            GridViewMemberships.SelectionChanged += GridViewMemberships_SelectionChanged;
        }

        private void ShowMemberships()
        {
            string Query = "Select MembershipID, MembershipType, Duration, Cost, Currency from MembershipsTable";
            GridViewMemberships.DataSource = Con.GetData(Query);
            GridViewMemberships.ClearSelection();
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
           // Members Obj = new Members();
          //  Obj.Show();
            //this.Hide();
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

        private void Reset()
        {
            MembershipType.Text = string.Empty;
            Duration.Text = string.Empty;
            Cost.Text = string.Empty;
            Currency.Text = string.Empty;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MembershipType.Text == "" || Duration.SelectedIndex == -1 || Cost.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill required fields!!");
                }
                else
                {
                    string Memshiptype = MembershipType.Text;
                    string Dur= Duration.SelectedItem.ToString();
                    string Cos = Cost.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "Insert into MembershipsTable Values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, Memshiptype, Dur, Cos, Curr);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership Added");
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
                if (MembershipType.Text == "" || Duration.SelectedIndex == -1 || Cost.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    int Key = int.Parse(GridViewMemberships.CurrentRow.Cells[0].Value.ToString());
                    string Memshiptype = MembershipType.Text;
                    string Dur = Duration.SelectedItem.ToString();
                    string Cos = Cost.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "Update MembershipsTable set MembershipType = '{0}', Duration = '{1}', Cost = '{2}', Currency = '{3}' Where MembershipID = {4}";
                    Query = string.Format(Query, Memshiptype, Dur, Cos, Curr, Key);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership Updated");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Delete_click(object sender, EventArgs e)
        {
            try
            {
                if (MembershipType.Text == "" || Duration.SelectedIndex == -1 || Cost.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewMemberships.CurrentRow.Cells[0].Value.ToString());
                    string Query = "Delete from MembershipsTable where MembershipID = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowMemberships();
                    MessageBox.Show("Membership Deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void GridViewMemberships_SelectionChanged(object sender, EventArgs e)
        {
            if (GridViewMemberships.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridViewMemberships.SelectedRows[0];

                MembershipType.Text = GridViewMemberships.CurrentRow.Cells[1].Value.ToString();
                Duration.Text = GridViewMemberships.CurrentRow.Cells[2].Value.ToString();
                Cost.Text = GridViewMemberships.CurrentRow.Cells[3].Value.ToString();
                Currency.Text = GridViewMemberships.CurrentRow.Cells[4].Value.ToString();
            }
        }
    }
}
