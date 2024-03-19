namespace GymApp
{
    partial class FormReportPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportPayments));
            this.PaymentsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetPayments = new GymApp.DataSetPayments();
            this.label1 = new System.Windows.Forms.Label();
            this.RVpayments = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PaymentsTableTableAdapter = new GymApp.DataSetPaymentsTableAdapters.PaymentsTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentsTableBindingSource
            // 
            this.PaymentsTableBindingSource.DataMember = "PaymentsTable";
            this.PaymentsTableBindingSource.DataSource = this.DataSetPayments;
            // 
            // DataSetPayments
            // 
            this.DataSetPayments.DataSetName = "DataSetPayments";
            this.DataSetPayments.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Payments";
            // 
            // RVpayments
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PaymentsTableBindingSource;
            this.RVpayments.LocalReport.DataSources.Add(reportDataSource1);
            this.RVpayments.LocalReport.ReportEmbeddedResource = "GymApp.ReportPayments.rdlc";
            this.RVpayments.Location = new System.Drawing.Point(12, 47);
            this.RVpayments.Name = "RVpayments";
            this.RVpayments.ServerReport.BearerToken = null;
            this.RVpayments.Size = new System.Drawing.Size(718, 429);
            this.RVpayments.TabIndex = 2;
            // 
            // PaymentsTableTableAdapter
            // 
            this.PaymentsTableTableAdapter.ClearBeforeFill = true;
            // 
            // FormReportPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 488);
            this.Controls.Add(this.RVpayments);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportPayments";
            this.Text = "FormReportPayments";
            this.Load += new System.EventHandler(this.FormReportPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer RVpayments;
        private System.Windows.Forms.BindingSource PaymentsTableBindingSource;
        private DataSetPayments DataSetPayments;
        private DataSetPaymentsTableAdapters.PaymentsTableTableAdapter PaymentsTableTableAdapter;
    }
}