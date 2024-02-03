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
        //private DataTable originalDataTable;

        public AllBills()
        {
            InitializeComponent();
            Con = new Functions();
            //receivedDataGridView = (DataGridView)GridViewBills.DataSource;
            //GridViewBills.DataSource = receivedDataGridView;
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
            TxtBoxUSD.Text = SumUSD.ToString();
            TxtBoxLBP.Text = SumLBP.ToString();
        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {

            string searchTerm = SearchTxtBox.Text.Trim();
            BindingSource bs = new BindingSource();
            bs.DataSource = GridViewBills.DataSource;
            bs.Filter = string.Format("Member LIKE '%{0}%'", searchTerm);
            GridViewBills.DataSource = bs;

            decimal SumUSD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in GridViewBills.Rows)
            {
                // Replace "PaymentAmount" and "CurrencyType" with the actual column names in your DataGridView
                DataGridViewCell paymentCell = row.Cells["Amount"];
                DataGridViewCell currencyCell = row.Cells["Currency"];

                // Check if the cells are not null and contain valid values
                if (paymentCell.Value != null && currencyCell.Value != null)
                {
                    decimal Amount;
                    if (decimal.TryParse(paymentCell.Value.ToString(), out Amount))
                    {
                        string Currency = currencyCell.Value.ToString();

                        // Convert to dollars and Lebanese pounds based on exchange rates
                        if (Currency == "USD")
                        {
                            SumUSD += Amount;
                        }
                        else if (Currency == "LBP")
                        {
                            SumLBP += Amount;
                        }
                    }
                }
            }

            // Display or use the calculated totals
            TxtBoxUSD.Text = SumUSD.ToString();
            TxtBoxLBP.Text = SumLBP.ToString();
        }

        private void FilterDataByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                MessageBox.Show("Date To should be greater then Date From");
            }

            else
            {
                // Assuming your DataGridView has a DataTable as its DataSource
                if (GridViewBills.DataSource is DataTable dataTable)
                {
                    // Apply a filter to the DataTable based on the date range
                    string filterExpression = $"Date >= #{startDate.ToString("MM/dd/yyyy")}# AND Date <= #{endDate.ToString("MM/dd/yyyy")}#";
                    dataTable.DefaultView.RowFilter = filterExpression;
                }

                decimal SumUSD = 0;
                decimal SumLBP = 0;

                foreach (DataGridViewRow row in GridViewBills.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row if it's there

                    // Assuming your columns are named "DateColumn", "DollarAmountColumn", and "LbpAmountColumn"
                    DateTime date = Convert.ToDateTime(row.Cells["Date"].Value);

                    if (date >= startDate && date <= endDate)
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
                }

                // Display the total amounts in some labels or other controls
                TxtBoxUSD.Text = SumUSD.ToString();
                TxtBoxLBP.Text = SumLBP.ToString();
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            // Get the start and end dates from your UI controls
            DateTime startDate = StartDate.Value;
            DateTime endDate = EndDate.Value;

            // Call the filtering method
            FilterDataByDateRange(startDate, endDate);

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

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Search(object sender, EventArgs e)
        {

        }
    }
}
