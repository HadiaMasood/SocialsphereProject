using BusinessLogicLayer.BusinessLogicLayer;
using Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Social_Sphere
{
    public partial class SearchUsersForm : Form
    {
        private User _currentUser;
        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstResults;

        public SearchUsersForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Search Users";
            this.Width = 500;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblSearch = new Label { Text = "Search:", Left = 10, Top = 10, Width = 50 };
            txtSearch = new TextBox { Left = 70, Top = 10, Width = 300, Height = 25 };
            
            btnSearch = new Button { Text = "Search", Left = 380, Top = 10, Width = 100, Height = 25 };
            btnSearch.Click += (s, e) => SearchUsers();

            lstResults = new ListBox { Left = 10, Top = 50, Width = 470, Height = 320 };
            lstResults.DoubleClick += (s, e) => OpenChat();

            this.Controls.Add(lblSearch);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(lstResults);
        }

        private void SearchUsers()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Enter search term!");
                return;
            }

            lstResults.Items.Clear();
            try
            {
                DataTable results = UserProfileBLL.SearchUsers(txtSearch.Text);
                if (results != null && results.Rows.Count > 0)
                {
                    foreach (DataRow row in results.Rows)
                    {
                        lstResults.Items.Add(row["Username"].ToString());
                    }
                }
                else
                {
                    lstResults.Items.Add("No users found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OpenChat()
        {
            if (lstResults.SelectedIndex < 0 || lstResults.SelectedItem.ToString() == "No users found")
            {
                MessageBox.Show("Select a valid user!");
                return;
            }

            string selectedUsername = lstResults.SelectedItem.ToString();
            MessagingForm messagingForm = new MessagingForm(_currentUser, selectedUsername);
            messagingForm.Show();
        }
    }
}
