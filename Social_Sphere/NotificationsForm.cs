using BusinessLogicLayer.BusinessLogicLayer;
using Models;
using System;
using System.Windows.Forms;

namespace Social_Sphere
{
    public partial class NotificationsForm : Form
    {
        private User _currentUser;
        private ListBox lstNotifications;
        private Button btnMarkRead;
        private Button btnDelete;

        public NotificationsForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            LoadNotifications();
        }

        private void InitializeComponent()
        {
            this.Text = "Notifications";
            this.Width = 600;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblNotif = new Label { Text = "Notifications:", Left = 10, Top = 10, Width = 100 };
            lstNotifications = new ListBox { Left = 10, Top = 40, Width = 560, Height = 280 };

            btnMarkRead = new Button { Text = "Mark as Read", Left = 10, Top = 330, Width = 150, Height = 40 };
            btnMarkRead.Click += (s, e) => MarkAsRead();

            btnDelete = new Button { Text = "Delete", Left = 170, Top = 330, Width = 150, Height = 40 };
            btnDelete.Click += (s, e) => DeleteNotification();

            this.Controls.Add(lblNotif);
            this.Controls.Add(lstNotifications);
            this.Controls.Add(btnMarkRead);
            this.Controls.Add(btnDelete);
        }

        private void LoadNotifications()
        {
            lstNotifications.Items.Clear();
            try
            {
                var notifications = NotificationBLL.GetUserNotifications(_currentUser.UserId);
                if (notifications != null && notifications.Count > 0)
                {
                    foreach (var notif in notifications)
                    {
                        lstNotifications.Items.Add($"{notif.TriggeredByUsername}: {notif.Message}");
                    }
                }
                else
                {
                    lstNotifications.Items.Add("No notifications");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MarkAsRead()
        {
            if (lstNotifications.SelectedIndex < 0)
            {
                MessageBox.Show("Select a notification!");
                return;
            }
            MessageBox.Show("Marked as read!");
            LoadNotifications();
        }

        private void DeleteNotification()
        {
            if (lstNotifications.SelectedIndex < 0)
            {
                MessageBox.Show("Select a notification!");
                return;
            }
            MessageBox.Show("Notification deleted!");
            LoadNotifications();
        }
    }
}
