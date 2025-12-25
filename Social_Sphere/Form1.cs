using BusinessLogicLayer;
using DataAccessLayer;
using Models;
using System;
using System.Windows.Forms;
// REMOVED: using Microsoft.VisualBasic.ApplicationServices; - This causes User conflict

namespace Social_Sphere
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            lblpassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signUpForm form = new signUpForm();
            form.Show();
            this.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = lblusername.Text.Trim();
            string password = lblpassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check hardcoded admin credentials first
                if (username == "admin" && password == "admin123")
                {
                    // Create admin user object
                    Models.User adminUser = new Models.User
                    {
                        UserId = 0,
                        Username = "Admin",
                        Email = "admin@socialsphere.com"
                    };

                    AdminPanel adminPanel = new AdminPanel(adminUser);
                    adminPanel.Show();
                    this.Hide();
                    return;
                }

                // Try to login as regular user
                Models.User loggedUser = UserBLL.Login(username, password);
                
                if (loggedUser != null)
                {
                    // Open regular Dashboard
                    Dashboard dash = new Dashboard(loggedUser);
                    dash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string username = lblusername.Text.Trim();
            string password = lblpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check hardcoded admin credentials
                if (username == "admin" && password == "admin123")
                {
                    MessageBox.Show("Admin login successful!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Create admin user object
                    Models.User adminUser = new Models.User
                    {
                        UserId = 0,
                        Username = "Admin",
                        Email = "admin@socialsphere.com"
                    };

                    // Open Admin Panel
                    AdminPanel adminPanel = new AdminPanel(adminUser);
                    adminPanel.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid admin credentials!",
                        "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}