namespace TwinkleBookStore
{
    partial class FrmRptCustomerBirthDay
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
            this.btnExport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsCustBday = new TwinkleBookStore.dsCustBday();
            this.usp_UpCmgBdayCustBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_UpCmgBdayCustTableAdapter = new TwinkleBookStore.dsCustBdayTableAdapters.usp_UpCmgBdayCustTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCustBday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_UpCmgBdayCustBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(363, 382);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 291);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(539, 71);
            this.dataGridView1.TabIndex = 45;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsCustBirthDay";
            reportDataSource1.Value = this.usp_UpCmgBdayCustBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TwinkleBookStore.RptCustomerBirthDay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 27);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(833, 246);
            this.reportViewer1.TabIndex = 47;
            // 
            // dsCustBday
            // 
            this.dsCustBday.DataSetName = "dsCustBday";
            this.dsCustBday.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usp_UpCmgBdayCustBindingSource
            // 
            this.usp_UpCmgBdayCustBindingSource.DataMember = "usp_UpCmgBdayCust";
            this.usp_UpCmgBdayCustBindingSource.DataSource = this.dsCustBday;
            // 
            // usp_UpCmgBdayCustTableAdapter
            // 
            this.usp_UpCmgBdayCustTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptCustomerBirthDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 417);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmRptCustomerBirthDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCustBday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_UpCmgBdayCustBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource usp_UpCmgBdayCustBindingSource;
        private dsCustBday dsCustBday;
        private dsCustBdayTableAdapters.usp_UpCmgBdayCustTableAdapter usp_UpCmgBdayCustTableAdapter;
    }
}