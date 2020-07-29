namespace TwinkleBookStore
{
    partial class FrmLoginRegistration
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
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblUserIdMand = new System.Windows.Forms.Label();
            this.lblPasswordMand = new System.Windows.Forms.Label();
            this.lblConfirmPassMand = new System.Windows.Forms.Label();
            this.lblValidationSummary = new System.Windows.Forms.Label();
            this.lblConfPasswordExpression = new System.Windows.Forms.Label();
            this.lblUserIdExpression = new System.Windows.Forms.Label();
            this.lblPasswordExpression = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(69, 46);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserId.Size = new System.Drawing.Size(48, 13);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "User Id";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(56, 84);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(137, 43);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(199, 20);
            this.txtUserId.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(137, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(51, 169);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(167, 23);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(137, 117);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(199, 20);
            this.txtConfirmPassword.TabIndex = 10;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPass.Location = new System.Drawing.Point(12, 124);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(107, 13);
            this.lblConfirmPass.TabIndex = 13;
            this.lblConfirmPass.Text = "Confirm Password";
            this.lblConfirmPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(242, 169);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(167, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblUserIdMand
            // 
            this.lblUserIdMand.AutoSize = true;
            this.lblUserIdMand.BackColor = System.Drawing.Color.Transparent;
            this.lblUserIdMand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIdMand.ForeColor = System.Drawing.Color.Red;
            this.lblUserIdMand.Location = new System.Drawing.Point(119, 50);
            this.lblUserIdMand.Name = "lblUserIdMand";
            this.lblUserIdMand.Size = new System.Drawing.Size(12, 13);
            this.lblUserIdMand.TabIndex = 18;
            this.lblUserIdMand.Text = "*";
            this.lblUserIdMand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPasswordMand
            // 
            this.lblPasswordMand.AutoSize = true;
            this.lblPasswordMand.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordMand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordMand.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordMand.Location = new System.Drawing.Point(119, 88);
            this.lblPasswordMand.Name = "lblPasswordMand";
            this.lblPasswordMand.Size = new System.Drawing.Size(12, 13);
            this.lblPasswordMand.TabIndex = 19;
            this.lblPasswordMand.Text = "*";
            this.lblPasswordMand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfirmPassMand
            // 
            this.lblConfirmPassMand.AutoSize = true;
            this.lblConfirmPassMand.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmPassMand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassMand.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPassMand.Location = new System.Drawing.Point(119, 124);
            this.lblConfirmPassMand.Name = "lblConfirmPassMand";
            this.lblConfirmPassMand.Size = new System.Drawing.Size(12, 13);
            this.lblConfirmPassMand.TabIndex = 20;
            this.lblConfirmPassMand.Text = "*";
            this.lblConfirmPassMand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValidationSummary
            // 
            this.lblValidationSummary.AutoSize = true;
            this.lblValidationSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblValidationSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidationSummary.ForeColor = System.Drawing.Color.Red;
            this.lblValidationSummary.Location = new System.Drawing.Point(138, 9);
            this.lblValidationSummary.Name = "lblValidationSummary";
            this.lblValidationSummary.Size = new System.Drawing.Size(147, 13);
            this.lblValidationSummary.TabIndex = 23;
            this.lblValidationSummary.Text = "Please Enter All  * Fields";
            this.lblValidationSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfPasswordExpression
            // 
            this.lblConfPasswordExpression.AutoSize = true;
            this.lblConfPasswordExpression.BackColor = System.Drawing.Color.Transparent;
            this.lblConfPasswordExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfPasswordExpression.ForeColor = System.Drawing.Color.Red;
            this.lblConfPasswordExpression.Location = new System.Drawing.Point(359, 120);
            this.lblConfPasswordExpression.Name = "lblConfPasswordExpression";
            this.lblConfPasswordExpression.Size = new System.Drawing.Size(138, 13);
            this.lblConfPasswordExpression.TabIndex = 26;
            this.lblConfPasswordExpression.Text = "Password Not Matched";
            this.lblConfPasswordExpression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserIdExpression
            // 
            this.lblUserIdExpression.AutoSize = true;
            this.lblUserIdExpression.BackColor = System.Drawing.Color.Transparent;
            this.lblUserIdExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIdExpression.ForeColor = System.Drawing.Color.Red;
            this.lblUserIdExpression.Location = new System.Drawing.Point(359, 50);
            this.lblUserIdExpression.Name = "lblUserIdExpression";
            this.lblUserIdExpression.Size = new System.Drawing.Size(256, 13);
            this.lblUserIdExpression.TabIndex = 27;
            this.lblUserIdExpression.Text = "Please Use AlphaNumeric and Min Length 5";
            this.lblUserIdExpression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPasswordExpression
            // 
            this.lblPasswordExpression.AutoSize = true;
            this.lblPasswordExpression.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordExpression.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordExpression.Location = new System.Drawing.Point(359, 88);
            this.lblPasswordExpression.Name = "lblPasswordExpression";
            this.lblPasswordExpression.Size = new System.Drawing.Size(128, 13);
            this.lblPasswordExpression.TabIndex = 28;
            this.lblPasswordExpression.Text = "Use Strong Password";
            this.lblPasswordExpression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(424, 169);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(167, 23);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmLoginRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 229);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPasswordExpression);
            this.Controls.Add(this.lblUserIdExpression);
            this.Controls.Add(this.lblConfPasswordExpression);
            this.Controls.Add(this.lblValidationSummary);
            this.Controls.Add(this.lblConfirmPassMand);
            this.Controls.Add(this.lblPasswordMand);
            this.Controls.Add(this.lblUserIdMand);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserId);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmLoginRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Regisration";
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblUserIdMand;
        private System.Windows.Forms.Label lblPasswordMand;
        private System.Windows.Forms.Label lblConfirmPassMand;
        private System.Windows.Forms.Label lblValidationSummary;
        private System.Windows.Forms.Label lblConfPasswordExpression;
        private System.Windows.Forms.Label lblUserIdExpression;
        private System.Windows.Forms.Label lblPasswordExpression;
        private System.Windows.Forms.Button btnClose;
    }
}