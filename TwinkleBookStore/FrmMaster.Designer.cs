namespace TwinkleBookStore
{
    partial class FrmMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaster));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUserRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCustomerItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCustomerSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQualifiedCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBirthday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnnualBillig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsmLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMaster,
            this.tsmReports,
            this.tsmExit,
            this.tsmLogOut});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMaster
            // 
            this.tsmMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRegister,
            this.tsmImport,
            this.tsmRoles,
            this.tsmUserRoles,
            this.tsmItems,
            this.tsmCustomerItems,
            this.tsmCustomer});
            this.tsmMaster.Name = "tsmMaster";
            this.tsmMaster.Size = new System.Drawing.Size(88, 20);
            this.tsmMaster.Text = "MasterForms";
            // 
            // tsmRegister
            // 
            this.tsmRegister.Name = "tsmRegister";
            this.tsmRegister.Size = new System.Drawing.Size(192, 22);
            this.tsmRegister.Text = "Login Registration";
            this.tsmRegister.Click += new System.EventHandler(this.tsmRegister_Click);
            // 
            // tsmImport
            // 
            this.tsmImport.Name = "tsmImport";
            this.tsmImport.Size = new System.Drawing.Size(192, 22);
            this.tsmImport.Text = "Import Customer Data";
            this.tsmImport.Click += new System.EventHandler(this.tsmImport_Click);
            // 
            // tsmRoles
            // 
            this.tsmRoles.Name = "tsmRoles";
            this.tsmRoles.Size = new System.Drawing.Size(192, 22);
            this.tsmRoles.Text = "Roles";
            this.tsmRoles.Click += new System.EventHandler(this.tsmRoles_Click);
            // 
            // tsmUserRoles
            // 
            this.tsmUserRoles.Name = "tsmUserRoles";
            this.tsmUserRoles.Size = new System.Drawing.Size(192, 22);
            this.tsmUserRoles.Text = "Login Roles Mapping";
            this.tsmUserRoles.Click += new System.EventHandler(this.tsmUserRoles_Click);
            // 
            // tsmItems
            // 
            this.tsmItems.Name = "tsmItems";
            this.tsmItems.Size = new System.Drawing.Size(192, 22);
            this.tsmItems.Text = "Items";
            this.tsmItems.Click += new System.EventHandler(this.tsmItems_Click);
            // 
            // tsmCustomerItems
            // 
            this.tsmCustomerItems.Name = "tsmCustomerItems";
            this.tsmCustomerItems.Size = new System.Drawing.Size(192, 22);
            this.tsmCustomerItems.Text = "Customer Items";
            this.tsmCustomerItems.Click += new System.EventHandler(this.tsmUserItems_Click);
            // 
            // tsmCustomer
            // 
            this.tsmCustomer.Name = "tsmCustomer";
            this.tsmCustomer.Size = new System.Drawing.Size(192, 22);
            this.tsmCustomer.Text = "Customer";
            this.tsmCustomer.Click += new System.EventHandler(this.tsmCustomer_Click);
            // 
            // tsmReports
            // 
            this.tsmReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCustomerSearch,
            this.tsmQualifiedCustomers,
            this.tsmBirthday,
            this.tsmAnnualBillig});
            this.tsmReports.Name = "tsmReports";
            this.tsmReports.Size = new System.Drawing.Size(59, 20);
            this.tsmReports.Text = "Reports";
            // 
            // tsmCustomerSearch
            // 
            this.tsmCustomerSearch.Name = "tsmCustomerSearch";
            this.tsmCustomerSearch.Size = new System.Drawing.Size(232, 22);
            this.tsmCustomerSearch.Text = "Customer Search";
            this.tsmCustomerSearch.Click += new System.EventHandler(this.tsmCustomerSearch_Click);
            // 
            // tsmQualifiedCustomers
            // 
            this.tsmQualifiedCustomers.Name = "tsmQualifiedCustomers";
            this.tsmQualifiedCustomers.Size = new System.Drawing.Size(232, 22);
            this.tsmQualifiedCustomers.Text = "Qualified 20% Disc Customers";
            this.tsmQualifiedCustomers.Click += new System.EventHandler(this.tsmQualifiedCustomers_Click);
            // 
            // tsmBirthday
            // 
            this.tsmBirthday.Name = "tsmBirthday";
            this.tsmBirthday.Size = new System.Drawing.Size(232, 22);
            this.tsmBirthday.Text = "Customer BirthDay List";
            this.tsmBirthday.Click += new System.EventHandler(this.tsmBirthday_Click);
            // 
            // tsmAnnualBillig
            // 
            this.tsmAnnualBillig.Name = "tsmAnnualBillig";
            this.tsmAnnualBillig.Size = new System.Drawing.Size(232, 22);
            this.tsmAnnualBillig.Text = "AnnualBilling";
            this.tsmAnnualBillig.Click += new System.EventHandler(this.tsmAnnualBillig_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(38, 20);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 425);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "Powered By Add";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.DoubleClickEnabled = true;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(94, 22);
            this.toolStripLabel1.Text = "Powered By ABB";
            // 
            // tsmLogOut
            // 
            this.tsmLogOut.Name = "tsmLogOut";
            this.tsmLogOut.Size = new System.Drawing.Size(59, 20);
            this.tsmLogOut.Text = "LogOut";
            this.tsmLogOut.Click += new System.EventHandler(this.tsmLogOut_Click);
            // 
            // FrmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FrmMaster";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMaster;
        private System.Windows.Forms.ToolStripMenuItem tsmRegister;
        private System.Windows.Forms.ToolStripMenuItem tsmImport;
        private System.Windows.Forms.ToolStripMenuItem tsmReports;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmRoles;
        private System.Windows.Forms.ToolStripMenuItem tsmUserRoles;
        private System.Windows.Forms.ToolStripMenuItem tsmItems;
        private System.Windows.Forms.ToolStripMenuItem tsmCustomerItems;
        private System.Windows.Forms.ToolStripMenuItem tsmCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmCustomerSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmQualifiedCustomers;
        private System.Windows.Forms.ToolStripMenuItem tsmBirthday;
        private System.Windows.Forms.ToolStripMenuItem tsmAnnualBillig;
        private System.Windows.Forms.ToolStripMenuItem tsmLogOut;
    }
}

