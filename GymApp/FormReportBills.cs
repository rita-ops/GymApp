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
 
        public FormReportBills()
        {
            InitializeComponent();
 
        }

        private void FormReportBills_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetBills.BillsTable' table. You can move, or remove it, as needed.
            this.BillsTableTableAdapter.Fill(this.DataSetBills.BillsTable);

            this.reportViewer1.RefreshReport();
        }
    }
}
