namespace Social_Sphere
{
    partial class signUpForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsernameLabel = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.TextBox();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.TextBox();
            this.lblPasswordLabel = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.TextBox();
            this.lblConfirmLabel = new System.Windows.Forms.Label();
            this.lblconfirmpass = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlMain.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1350, 1000);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.lblUsernameLabel);
            this.pnlForm.Controls.Add(this.lblusername);
            this.pnlForm.Controls.Add(this.lblEmailLabel);
            this.pnlForm.Controls.Add(this.lblemail);
            this.pnlForm.Controls.Add(this.lblPasswordLabel);
            this.pnlForm.Controls.Add(this.lblpassword);
            this.pnlForm.Controls.Add(this.lblConfirmLabel);
            this.pnlForm.Controls.Add(this.lblconfirmpass);
            this.pnlForm.Controls.Add(this.chkShowPassword);
            this.pnlForm.Controls.Add(this.btnSignUp);
            this.pnlForm.Controls.Add(this.linkLabel1);
            this.pnlForm.Location = new System.Drawing.Point(450, 115);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(450, 769);
            this.pnlForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 23);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Account";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblUsernameLabel.Location = new System.Drawing.Point(30, 92);
            this.lblUsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.Size = new System.Drawing.Size(390, 28);
            this.lblUsernameLabel.TabIndex = 1;
            this.lblUsernameLabel.Text = "Username";
            // 
            // lblusername
            // 
            this.lblusername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblusername.Font = new System.Drawing.Font("Arial", 11F);
            this.lblusername.Location = new System.Drawing.Point(30, 120);
            this.lblusername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(390, 26);
            this.lblusername.TabIndex = 0;
            // 
            // lblEmailLabel
            // 
            this.lblEmailLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblEmailLabel.Location = new System.Drawing.Point(30, 185);
            this.lblEmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailLabel.Name = "lblEmailLabel";
            this.lblEmailLabel.Size = new System.Drawing.Size(390, 28);
            this.lblEmailLabel.TabIndex = 2;
            this.lblEmailLabel.Text = "Email";
            // 
            // lblemail
            // 
            this.lblemail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblemail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblemail.Font = new System.Drawing.Font("Arial", 11F);
            this.lblemail.Location = new System.Drawing.Point(30, 212);
            this.lblemail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(390, 26);
            this.lblemail.TabIndex = 1;
            // 
            // lblPasswordLabel
            // 
            this.lblPasswordLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblPasswordLabel.Location = new System.Drawing.Point(30, 277);
            this.lblPasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordLabel.Name = "lblPasswordLabel";
            this.lblPasswordLabel.Size = new System.Drawing.Size(390, 28);
            this.lblPasswordLabel.TabIndex = 3;
            this.lblPasswordLabel.Text = "Password";
            // 
            // lblpassword
            // 
            this.lblpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblpassword.Font = new System.Drawing.Font("Arial", 11F);
            this.lblpassword.Location = new System.Drawing.Point(30, 305);
            this.lblpassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.PasswordChar = '*';
            this.lblpassword.Size = new System.Drawing.Size(390, 26);
            this.lblpassword.TabIndex = 2;
            // 
            // lblConfirmLabel
            // 
            this.lblConfirmLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirmLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblConfirmLabel.Location = new System.Drawing.Point(30, 369);
            this.lblConfirmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmLabel.Name = "lblConfirmLabel";
            this.lblConfirmLabel.Size = new System.Drawing.Size(390, 28);
            this.lblConfirmLabel.TabIndex = 4;
            this.lblConfirmLabel.Text = "Confirm Password";
            // 
            // lblconfirmpass
            // 
            this.lblconfirmpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblconfirmpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblconfirmpass.Font = new System.Drawing.Font("Arial", 11F);
            this.lblconfirmpass.Location = new System.Drawing.Point(30, 397);
            this.lblconfirmpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblconfirmpass.Name = "lblconfirmpass";
            this.lblconfirmpass.PasswordChar = '*';
            this.lblconfirmpass.Size = new System.Drawing.Size(390, 26);
            this.lblconfirmpass.TabIndex = 3;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Font = new System.Drawing.Font("Arial", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.chkShowPassword.Location = new System.Drawing.Point(30, 462);
            this.chkShowPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(225, 31);
            this.chkShowPassword.TabIndex = 5;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(30, 515);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(390, 62);
            this.btnSignUp.TabIndex = 6;
            this.btnSignUp.Text = "SIGN UP";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.linkLabel1.Location = new System.Drawing.Point(45, 600);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(360, 62);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Already have an account? Back to LOGIN";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // signUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 1000);
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "signUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Social Sphere - Sign Up";
            this.pnlMain.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsernameLabel;
        private System.Windows.Forms.TextBox lblusername;
        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.TextBox lblemail;
        private System.Windows.Forms.Label lblPasswordLabel;
        private System.Windows.Forms.TextBox lblpassword;
        private System.Windows.Forms.Label lblConfirmLabel;
        private System.Windows.Forms.TextBox lblconfirmpass;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

