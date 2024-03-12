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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PaymentsTableTableAdapter = new GymApp.DataSetPaymentsTableAdapters.PaymentsTableTableAdapter();
            this.TxtBoxLBP = new System.Windows.Forms.TextBox();
            this.TxtBoxUSD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(461, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Payments";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PaymentsTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GymApp.ReportPayments.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 50);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(936, 429);
            this.reportViewer1.TabIndex = 2;
            // 
            // PaymentsTableTableAdapter
            // 
            this.PaymentsTableTableAdapter.ClearBeforeFill = true;
            // 
            // TxtBoxLBP
            // 
            this.TxtBoxLBP.Location = new System.Drawing.Point(791, 494);
            this.TxtBoxLBP.Name = "TxtBoxLBP";
            this.TxtBoxLBP.Size = new System.Drawing.Size(135, 20);
            this.TxtBoxLBP.TabIndex = 58;
            // 
            // TxtBoxUSD
            // 
            this.TxtBoxUSD.Location = new System.Drawing.Point(538, 495);
            this.TxtBoxUSD.Name = "TxtBoxUSD";
            this.TxtBoxUSD.Size = new System.Drawing.Size(135, 20);
            this.TxtBoxUSD.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(932, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 55;
            this.label4.Text = "LBP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(675, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "USD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Total";
            // 
            // FormReportPayments
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
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PaymentsTableBindingSource;
        private DataSetPayments DataSetPayments;
        private DataSetPaymentsTableAdapters.PaymentsTableTableAdapter PaymentsTableTableAdapter;
        private System.Windows.Forms.TextBox TxtBoxLBP;
        private System.Windows.Forms.TextBox TxtBoxUSD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}