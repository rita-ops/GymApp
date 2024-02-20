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
    public partial class AllBills : Form
    {
        Functions Con;
        bool adm;
        public AllBills()
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

        // Property to receive DataGridView
        public DataGridView ReceivedDataGridView { get; set; }

        private void AllBills_Load(object sender, EventArgs e)
        {

            // Access the DataGridView from Form1
            if (ReceivedDataGridView != null)
            {
                // Do something with the received DataGridView
                GridViewBills.DataSource = ReceivedDataGridView.DataSource;
                GridViewBills.Columns["Amount"].DefaultCellStyle.Format = "N2";
            }

            // Access and manipulate the DataGridView as needed
            if (GridViewBills != null)
            {
                // Hide specific columns
                GridViewBills.Columns["BillID"].Visible = false;
            }

            decimal SumUSD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in GridViewBills.Rows)
            {
                // Assuming your amount column is at index 1 and currency column is at index 2
                decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);

                // You can use the currency information if needed
                string currency = Convert.ToString(row.Cells["Currency"].Value);


                // Convert to dollars and Lebanese pounds based on exchange rates
                if (currency == "USD")
                {
                    SumUSD += amount;
                }
                else if (currency == "LBP")
                {
                    SumLBP += amount;
                }

            }

            // Display or use the calculated totals
            TxtBoxUSD.Text = SumUSD.ToString("#,##0");
            TxtBoxLBP.Text = SumLBP.ToString("#,##0");
        }

        private DateTime disabledDatePickerValue;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            StartDate.Enabled = checkBox1.Checked;
            EndDate.Enabled = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                // Use the saved value when disabling the DateTimePicker.
                DateTime startDate = StartDate.Value.Date;
                DateTime endDate = EndDate.Value.Date;
            }
            else
            {
                // Save the current value when enabling the DateTimePicker.
                disabledDatePickerValue = StartDate.Value.Date;
                disabledDatePickerValue = EndDate.Value.Date;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            // Get search parameters
            string memberName = SearchTxtBox.Text.Trim();
            DateTime startDate = StartDate.Value;
            DateTime endDate = EndDate.Value;

            // Assuming your DataGridView has a DataTable as its DataSource
            DataTable dataTable = ((DataTable)ReceivedDataGridView.DataSource); // Change to your actual DataGridView name

            // Construct the filter based on member name and date range
            string filter = "";

            if (!string.IsNullOrEmpty(memberName))
            {
                filter += $"Member LIKE '%{memberName}%'";
            }

            if (checkBox1.Checked)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }

                filter += $"Date >= #{startDate.ToString("MM/dd/yyyy")}# AND Date <= #{endDate.ToString("MM/dd/yyyy")}#";
            }

            // Apply the filter to the DataTable
            dataTable.DefaultView.RowFilter = filter;

            // Update the DataGridView to reflect the changes
            GridViewBills.DataSource = dataTable; // Change to your actual DataGridView name

            // Calculate the sum of amounts for USD and LBP
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            foreach (DataRowView rowView in dataTable.DefaultView)
            {
                DataRow row = rowView.Row;

                decimal amount = Convert.ToDecimal(row["Amount"]);
                string currency = Convert.ToString(row["Currency"]);

                if (currency == "USD")
                {
                    sumUSD += amount;
                }
                else if (currency == "LBP")
                {
                    sumLBP += amount;
                }
            }

            // Display the sums in the appropriate TextBoxes or labels
            TxtBoxUSD.Text = sumUSD.ToString("#,##0");
            TxtBoxLBP.Text = sumLBP.ToString("#,##0");
        }

        private void ClearSearch()
        {
            // Clear search parameters
            SearchTxtBox.Text = string.Empty;
            StartDate.Value = DateTime.Now.Date;
            EndDate.Value = DateTime.Now.Date;
            checkBox1.Checked = false;

            // Reset the filter by setting an empty filter string
            ((DataTable)ReceivedDataGridView.DataSource).DefaultView.RowFilter = string.Empty;

            // Update the DataGridView to reflect the changes
            GridViewBills.DataSource = ReceivedDataGridView.DataSource;

            // Recalculate and display the sum
            CalculateAndDisplaySum();
        }

        private void CalculateAndDisplaySum()
        {
            decimal sumUSD = 0;
            decimal sumLBP = 0;

            foreach (DataGridViewRow row in GridViewBills.Rows)
            {
                decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);
                string currency = Convert.ToString(row.Cells["Currency"].Value);

                if (currency == "USD")
                {
                    sumUSD += amount;
                }
                else if (currency == "LBP")
                {
                    sumLBP += amount;
                }
            }

            // Display or use the calculated totals
            TxtBoxUSD.Text = sumUSD.ToString("#,##0");
            TxtBoxLBP.Text = sumLBP.ToString("#,##0");
        }

        private void Clear_Search(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
           // Members Obj = new Members();
            //Obj.Show();
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

        private void Print_Click(object sender, EventArgs e)
        {
            FormReportBills Obj = new FormReportBills();
            Obj.Show();
        }
    }

    class BillsTable
    {
    }
}
