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
    public partial class AllPayments : Form
    {
        Functions Con;

        public AllPayments()
        {
            InitializeComponent();
            Con = new Functions();
        }
        public DataGridView ReceivedDataGridView { get; set; }

        private void AllPayments_Load(object sender, EventArgs e)
        {
                // Access the DataGridView from Form1
                if (ReceivedDataGridView != null)
                {
                    // Do something with the received DataGridView
                    GridViewPayments.DataSource = ReceivedDataGridView.DataSource;
                    GridViewPayments.Columns["Amount"].DefaultCellStyle.Format = "N2";
            }

                // Access and manipulate the DataGridView as needed
                if (GridViewPayments != null)
                {
                // Hide specific columns
                GridViewPayments.Columns["PaymentID"].Visible = false;
                }

                decimal SumUSD = 0;
                decimal SumLBP = 0;

                foreach (DataGridViewRow row in GridViewPayments.Rows)
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

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {

            string searchTerm = SearchTxtBox.Text.Trim();
            BindingSource bs = new BindingSource();
            bs.DataSource = GridViewPayments.DataSource;
            bs.Filter = string.Format("ClientName LIKE '%{0}%'", searchTerm);
            GridViewPayments.DataSource = bs;

            decimal SumUSD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in GridViewPayments.Rows)
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
            TxtBoxUSD.Text = SumUSD.ToString("#,##0");
            TxtBoxLBP.Text = SumLBP.ToString("#,##0");
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
            ChangePassword Obj = new ChangePassword();
            Obj.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
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
                if (GridViewPayments.DataSource is DataTable dataTable)
                {
                    // Apply a filter to the DataTable based on the date range
                    string filterExpression = $"Date >= #{startDate.ToString("MM/dd/yyyy")}# AND Date <= #{endDate.ToString("MM/dd/yyyy")}#";
                    dataTable.DefaultView.RowFilter = filterExpression;
                }
            

            decimal SumUSD = 0;
            decimal SumLBP = 0;

            foreach (DataGridViewRow row in GridViewPayments.Rows)
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
                    TxtBoxUSD.Text = SumUSD.ToString("#,##0");
                    TxtBoxLBP.Text = SumLBP.ToString("#,##0");
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

        private void ResetFilterByDateRange()
        {
            // Reset the start and end dates to default values or null
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MaxValue;
            // Call the method to filter data with the updated date range
            FilterDataByDateRange(startDate, endDate);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            SearchTxtBox.Text = null;
            ResetFilterByDateRange();
            StartDate.Text = null;
            EndDate.Text = null;
        }
    }
}
