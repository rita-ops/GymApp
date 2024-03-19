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
    public partial class FormReportPayments : Form
    {
        string client;
        DateTime fromDate, toDate;
        decimal sumUSD = 0;
        decimal sumLBP = 0;

        public FormReportPayments(decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
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

            ReportParameter par= new ReportParameter("sumUSD", this.sumUSD.ToString("#,##0"));
            ReportParameter par1 = new ReportParameter("sumLBP", this.sumLBP.ToString("#,##0"));

            RVpayments.LocalReport.SetParameters(new ReportParameter[] { par, par1 });
            // Refresh report and update sums
            this.RVpayments.RefreshReport();
        }

        private void FormReportPayments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetPayments.PaymentsTable' table. You can move, or remove it, as needed.
          //  this.PaymentsTableTableAdapter.Fill(this.DataSetPayments.PaymentsTable);

          //  this.reportViewer1.RefreshReport();
        }
    }
}
