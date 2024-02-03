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
    public partial class Bills : Form
    {
        Functions Con;
        public Bills()
        {
            InitializeComponent();
            Con = new Functions();
            ShowBills();
            GetMembers();
            GridViewBills.Columns[4].Visible = false;
            GridViewBills.SelectionChanged += GridViewBills_SelectionChanged;
        }

        private void Reset()
        {
            Member.Text = string.Empty;
            Amount.Text = string.Empty;
            Currency.Text = string.Empty;
        }


        private void ShowBills()
        {
            string Query = "SELECT CONCAT(MembersTable.MemberFName ,' ', MembersTable.MemberLName ,' ') AS Member , BillsTable.Date, BillsTable.Amount , BillsTable.Currency, BillsTable.BillID FROM MembersTable INNER JOIN BillsTable ON MembersTable.MembersID = BillsTable.MembersID";
            GridViewBills.DataSource = Con.GetData(Query);
            GridViewBills.ClearSelection();
        }

        private void GetMembers()
        {
            string Query = "Select MembersTable.MembersID, MemberFName +' '+ MemberLName +' ' as Member from MembersTable";
            Member.DisplayMember = Con.GetData(Query).Columns["Member"].ToString();
            Member.ValueMember = Con.GetData(Query).Columns["MembersID"].ToString();
            Member.DataSource = Con.GetData(Query);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Member.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)

                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    string Memship = Member.SelectedValue.ToString();
                    string BillDate = Date.Value.Date.ToString();
                    string Amo = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "insert into BillsTable values({0},'{1}','{2}','{3}')";
                    Query = string.Format(Query, Memship, Date.Value.Date, Amo, Curr);
                    Con.setData(Query);
                    ShowBills();
                    MessageBox.Show("Bill confirmed");
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
                if (Member.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    int Key = int.Parse(GridViewBills.SelectedRows[0].Cells[4].Value.ToString());
                    string Memship = Member.SelectedValue.ToString();
                    string BillDate = Date.Value.Date.ToString();
                    string Amo = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "update BillsTable set MembersID= {0}, Date = '{1}', Amount = '{2}', Currency = '{3}' where BillID = {4}";
                    Query = string.Format(Query, Memship, Date.Value.Date, Amo, Curr, Key);
                    Con.setData(Query);
                    ShowBills();
                    MessageBox.Show("Bill updated");
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
                if (Member.SelectedIndex == -1 || Amount.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewBills.SelectedRows[0].Cells[4].Value.ToString());
                    string Query = "Delete from BillsTable where BillID = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowBills();
                    MessageBox.Show("Bill Deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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

        private void ChangePassLbl_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void GridViewBills_SelectionChanged(object sender, EventArgs e)
        {

            if (GridViewBills.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridViewBills.SelectedRows[0];

                Member.Text = GridViewBills.CurrentRow.Cells[0].Value.ToString();
                Date.Text = GridViewBills.CurrentRow.Cells[1].Value.ToString();
                Amount.Text = GridViewBills.CurrentRow.Cells[2].Value.ToString();
                Currency.Text = GridViewBills.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void All_Bills(object sender, EventArgs e)
        {
            AllBills form2 = new AllBills();
            form2.ReceivedDataGridView = GridViewBills;
            form2.Show();
        }
    }
}
