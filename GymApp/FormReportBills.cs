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
        decimal sumUSD ;
        decimal sumLBP;

        public FormReportBills(decimal sumUSD, decimal sumLBP)
        {
            InitializeComponent();
            this.sumLBP = sumLBP;
            this.sumUSD = sumUSD;
            LoadReport();
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

            ReportParameter parameter1 = new ReportParameter("sumUSD", this.sumUSD.ToString("#,##0"));
            ReportParameter parameter2 = new ReportParameter("sumLBP", this.sumLBP.ToString("#,##0"));

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameter1, parameter2 });
            this.reportViewer1.RefreshReport();
        }
           
        private void FormReportBills_Load(object sender, EventArgs e)
        {
                // TODO: This line of code loads data into the 'DataSetBills.BillsTable' table. You can move, or remove it, as needed.
                //this.BillsTableTableAdapter.Fill(this.DataSetBills.BillsTable);
                //this.reportViewer1.RefreshReport();
               // CalculateAndDisplaySums();
        }
    }
}
