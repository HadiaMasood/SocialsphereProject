using BusinessLogicLayer;
using Models;
using System;
using System.Windows.Forms;

namespace Social_Sphere
{
    public partial class signUpForm : Form
    {
        public signUpForm()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            lblpassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            lblconfirmpass.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            string username = lblusername.Text.Trim();
            string email = lblemail.Text.Trim();
            string password = lblpassword.Text;
            string confirmPass = lblconfirmpass.Text;

            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check if username exists BEFORE attempting signup
                if (UserBLL.UsernameExists(username))
                {
                    MessageBox.Show($"Username '{username}' is already taken. Please choose another username.",
                                  "Username Exists",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    lblusername.Focus();
                    lblusername.SelectAll();
                    return;
                }

                // Check if email exists BEFORE attempting signup
                if (UserBLL.EmailExists(email))
                {
                    MessageBox.Show($"Email '{email}' is already registered. Please use another email or login.",
                                  "Email Exists",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    lblemail.Focus();
                    lblemail.SelectAll();
                    return;
                }

                // Attempt to create account
                bool success = UserBLL.SignUp(email, username, password);

                if (success)
                {
                    MessageBox.Show("Account created successfully! Please log in.",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // Clear fields
                    lblusername.Clear();
                    lblemail.Clear();
                    lblpassword.Clear();
                    lblconfirmpass.Clear();

                    // Navigate to login form
                    Form1 loginForm = new Form1();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create account. Please try again.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message,
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}