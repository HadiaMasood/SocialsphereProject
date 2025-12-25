using BusinessLogicLayer.BusinessLogicLayer;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Social_Sphere
{
    public partial class MessagingForm : Form
    {
        private User _currentUser;
        private string _selectedUsername;
        private ListBox lstConversations;
        private TextBox txtMessage;
        private Button btnSend;
        private Label lblMessages;

        public MessagingForm(User currentUser, string selectedUsername = null)
        {
            _currentUser = currentUser;
            _selectedUsername = selectedUsername;
            InitializeComponent();
            LoadConversations();
            if (!string.IsNullOrEmpty(_selectedUsername))
            {
                SelectConversation(_selectedUsername);
            }
        }

        private void InitializeComponent()
        {
            this.Text = "Messages";
            this.Width = 600;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblConv = new Label { Text = "Conversations:", Left = 10, Top = 10, Width = 100 };
            lstConversations = new ListBox { Left = 10, Top = 40, Width = 250, Height = 400 };
            lstConversations.SelectedIndexChanged += (s, e) => LoadMessages();

            lblMessages = new Label { Text = "Messages:", Left = 270, Top = 10, Width = 100 };
            
            txtMessage = new TextBox { Left = 270, Top = 40, Width = 310, Height = 350, Multiline = true };
            
            btnSend = new Button { Text = "Send", Left = 270, Top = 400, Width = 310, Height = 40 };
            btnSend.Click += (s, e) => SendMessage();

            this.Controls.Add(lblConv);
            this.Controls.Add(lstConversations);
            this.Controls.Add(lblMessages);
            this.Controls.Add(txtMessage);
            this.Controls.Add(btnSend);
        }

        private void LoadConversations()
        {
            lstConversations.Items.Clear();
            try
            {
                var conversations = MessageBLL.GetUserConversations(_currentUser.UserId);
                if (conversations != null && conversations.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in conversations.Rows)
                    {
                        lstConversations.Items.Add(row["OtherUsername"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadMessages()
        {
            if (lstConversations.SelectedIndex < 0) return;
            
            txtMessage.Clear();
            try
            {
                string selectedUser = lstConversations.SelectedItem.ToString();
                // Load messages for selected user
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SendMessage()
        {
            if (lstConversations.SelectedIndex < 0)
            {
                MessageBox.Show("Select a conversation first!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Enter a message!");
                return;
            }

            try
            {
                string selectedUser = lstConversations.SelectedItem.ToString();
                MessageBox.Show("Message sent!");
                txtMessage.Clear();
                LoadMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SelectConversation(string username)
        {
            for (int i = 0; i < lstConversations.Items.Count; i++)
            {
                if (lstConversations.Items[i].ToString() == username)
                {
                    lstConversations.SelectedIndex = i;
                    LoadMessages();
                    return;
                }
            }
            MessageBox.Show($"Conversation with {username} not found. Starting new conversation...");
            lstConversations.Items.Add(username);
            lstConversations.SelectedIndex = lstConversations.Items.Count - 1;
            LoadMessages();
        }
    }
}
