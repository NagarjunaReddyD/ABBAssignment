namespace TwinkleBookStore
{
    partial class FrmRptCustomerAnnualBill
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
            this.usp_AnualCustBillingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AnualCustBill = new TwinkleBookStore.AnualCustBill();
            this.btnExport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_AnualCustBillingTableAdapter = new TwinkleBookStore.AnualCustBillTableAdapters.usp_AnualCustBillingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usp_AnualCustBillingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnualCustBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // usp_AnualCustBillingBindingSource
            // 
            this.usp_AnualCustBillingBindingSource.DataMember = "usp_AnualCustBilling";
            this.usp_AnualCustBillingBindingSource.DataSource = this.AnualCustBill;
            // 
            // AnualCustBill
            // 
            this.AnualCustBill.DataSetName = "AnualCustBill";
            this.AnualCustBill.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(456, 324);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(109, 23);
            this.btnExport.TabIndex = 44;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 302);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(402, 70);
            this.dataGridView1.TabIndex = 45;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsAnualCust";
            reportDataSource1.Value = this.usp_AnualCustBillingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TwinkleBookStore.RptCustomerAnual.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(739, 246);
            this.reportViewer1.TabIndex = 46;
            // 
            // usp_AnualCustBillingTableAdapter
            // 
            this.usp_AnualCustBillingTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptCustomerAnnualBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 418);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmRptCustomerAnnualBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usp_AnualCustBillingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnualCustBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usp_AnualCustBillingBindingSource;
        private AnualCustBill AnualCustBill;
        private AnualCustBillTableAdapters.usp_AnualCustBillingTableAdapter usp_AnualCustBillingTableAdapter;
    }
}