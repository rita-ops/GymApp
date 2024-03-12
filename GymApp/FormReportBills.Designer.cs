namespace GymApp
{
    partial class FormReportBills
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportBills));
            this.BillsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBills = new GymApp.DataSetBills();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BillsTableTableAdapter = new GymApp.DataSetBillsTableAdapters.BillsTableTableAdapter();
            this.tableAdapterManager = new GymApp.DataSetBillsTableAdapters.TableAdapterManager();
            this.TxtBoxLBP = new System.Windows.Forms.TextBox();
            this.TxtBoxUSD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BillsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBills)).BeginInit();
            this.SuspendLayout();
            // 
            // BillsTableBindingSource
            // 
            this.BillsTableBindingSource.DataMember = "BillsTable";
            this.BillsTableBindingSource.DataSource = this.DataSetBills;
            // 
            // DataSetBills
            // 
            this.DataSetBills.DataSetName = "DataSetBills";
            this.DataSetBills.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(457, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Bills";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetBills";
            reportDataSource1.Value = this.BillsTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GymApp.ReportBills.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(46, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(931, 402);
            this.reportViewer1.TabIndex = 1;
            // 
            // BillsTableTableAdapter
            // 
            this.BillsTableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = GymApp.DataSetBillsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // TxtBoxLBP
            // 
            this.TxtBoxLBP.Location = new System.Drawing.Point(755, 475);
            this.TxtBoxLBP.Name = "TxtBoxLBP";
            this.TxtBoxLBP.Size = new System.Drawing.Size(135, 20);
            this.TxtBoxLBP.TabIndex = 53;
            // 
            // TxtBoxUSD
            // 
            this.TxtBoxUSD.Location = new System.Drawing.Point(502, 476);
            this.TxtBoxUSD.Name = "TxtBoxUSD";
            this.TxtBoxUSD.Size = new System.Drawing.Size(135, 20);
            this.TxtBoxUSD.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(896, 476);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "LBP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(639, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "USD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 475);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Total";
            // 
            // FormReportBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 545);
            this.Controls.Add(this.TxtBoxLBP);
            this.Controls.Add(this.TxtBoxUSD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportBills";
            this.Text = "FormReportBills";
            this.Load += new System.EventHandler(this.FormReportBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BillsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BillsTableBindingSource;
        private DataSetBills DataSetBills;
        private DataSetBillsTableAdapters.BillsTableTableAdapter BillsTableTableAdapter;
        private DataSetBillsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox TxtBoxLBP;
        private System.Windows.Forms.TextBox TxtBoxUSD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}