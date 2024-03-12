using Microsoft.Reporting.WinForms;
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
    public partial class FormReportBills : Form
    {
        string member;
        DateTime fromDate, toDate;
        private decimal sumUSD = 0;
        private decimal sumLBP = 0;

        public FormReportBills()
        {
            InitializeComponent();
            this.BillsTableTableAdapter.Fill(this.DataSetBills.BillsTable);
            this.reportViewer1.RefreshReport();
            CalculateAndDisplaySums();
        }

        public FormReportBills(string member, DateTime fromDate, DateTime toDate, decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.member = member;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
        }

            private void LoadReport()
            {
                // Fill the data table based on the filter criteria
                if (!string.IsNullOrEmpty(member) && fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
                {
                    this.BillsTableTableAdapter.FillByAll(this.DataSetBills.BillsTable, member, fromDate.ToString(), toDate.ToString());
                }
                else if (!string.IsNullOrEmpty(member) && fromDate == DateTime.MinValue)
                {
                    this.BillsTableTableAdapter.FillByMember(this.DataSetBills.BillsTable, member);
                }
                else if (member == null && fromDate != DateTime.MinValue && toDate != DateTime.MaxValue)
                {
                    this.BillsTableTableAdapter.FillByDate(this.DataSetBills.BillsTable, fromDate.ToString(), toDate.ToString());
                }
                else
                {
                    this.BillsTableTableAdapter.Fill(this.DataSetBills.BillsTable);
                }

                // Refresh report and update sums
                this.reportViewer1.RefreshReport();
                CalculateAndDisplaySums();
            }
           
        private void FormReportBills_Load(object sender, EventArgs e)
        {
                // TODO: This line of code loads data into the 'DataSetBills.BillsTable' table. You can move, or remove it, as needed.
                //this.BillsTableTableAdapter.Fill(this.DataSetBills.BillsTable);
                //this.reportViewer1.RefreshReport();
               // CalculateAndDisplaySums();
        }

        private void CalculateAndDisplaySums()
        {
            // Reset sums
            decimal sumUSD = 0;
            decimal sumLBP = 0;
            // Calculate sums
            foreach (DataRow row in DataSetBills.BillsTable.Rows)
            {
                string currency = row["Currency"].ToString();
                decimal amount = Convert.ToDecimal(row["Amount"]);

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
    }
}
