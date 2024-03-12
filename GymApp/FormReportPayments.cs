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
    public partial class FormReportPayments : Form
    {
        string client;
        DateTime fromDate, toDate;
        private decimal sumUSD = 0;
        private decimal sumLBP = 0;

        public FormReportPayments()
        {
            InitializeComponent();
            this.PaymentsTableTableAdapter.Fill(this.DataSetPayments.PaymentsTable);
            this.reportViewer1.RefreshReport();
            CalculateAndDisplaySums();
        }

        public FormReportPayments(string client, DateTime fromDate, DateTime toDate, decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.client = client;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
        }

        private void LoadReport()
        {
            // Fill the data table based on the filter criteria
            if (!string.IsNullOrEmpty(client) && fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
            {
                this.PaymentsTableTableAdapter.FillByAll(this.DataSetPayments.PaymentsTable, client, fromDate.ToString(), toDate.ToString());
            }
            else if (!string.IsNullOrEmpty(client) && fromDate == DateTime.MinValue)
            {
                this.PaymentsTableTableAdapter.FillByClient(this.DataSetPayments.PaymentsTable, client);
            }
            else if (client == null && fromDate != DateTime.MinValue && toDate != DateTime.MaxValue)
            {
                this.PaymentsTableTableAdapter.FillByDate(this.DataSetPayments.PaymentsTable, fromDate.ToString(), toDate.ToString());
            }
            else
            {
                this.PaymentsTableTableAdapter.Fill(this.DataSetPayments.PaymentsTable);
            }

            // Refresh report and update sums
            this.reportViewer1.RefreshReport();
            CalculateAndDisplaySums();
        }

        private void FormReportPayments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetPayments.PaymentsTable' table. You can move, or remove it, as needed.
          //  this.PaymentsTableTableAdapter.Fill(this.DataSetPayments.PaymentsTable);

          //  this.reportViewer1.RefreshReport();
        }

        private void CalculateAndDisplaySums()
        {
            // Reset sums
            decimal sumUSD = 0;
            decimal sumLBP = 0;
            // Calculate sums
            foreach (DataRow row in DataSetPayments.PaymentsTable.Rows)
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
