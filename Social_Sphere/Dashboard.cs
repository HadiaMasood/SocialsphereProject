using BusinessLogicLayer.BusinessLogicLayer;
using DataAccessLayer;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Social_Sphere
{
    public partial class Dashboard : Form
    {
        private User _currentUser;
        private const string PLACEHOLDER_TEXT = "What's on your mind?";

        // Consistent darker light blue color scheme
        private readonly Color PRIMARY_COLOR = Color.FromArgb(100, 149, 237); // Darker Light Blue
        private readonly Color PRIMARY_DARK = Color.FromArgb(70, 130, 220); // Even Darker Blue
        private readonly Color ACCENT_COLOR = Color.FromArgb(135, 206, 250); // Sky Blue
        private readonly Color DANGER_COLOR = Color.FromArgb(220, 53, 69); // Red

        private List<SamplePost> samplePosts = new List<SamplePost>();

        public Dashboard(User user)
        {
            _currentUser = user;
            InitializeComponent();
            InitializeSamplePosts();
            CustomizeControls();
            LoadUserData();
        }

        private void InitializeSamplePosts()
        {
            samplePosts.Add(new SamplePost
            {
                Username = "Tech Enthusiast",
                Content = "Just learned about the new C# 12 features! The collection expressions are game-changing. 🚀",
                CreatedAt = DateTime.Now.AddHours(-2),
                Likes = 42,
                Comments = new List<string> { "Totally agree!", "Can't wait to try them out!" },
                ImageUrl = "https://via.placeholder.com/800x400?text=C%23+12+Features"
            });

            samplePosts.Add(new SamplePost
            {
                Username = "Code Ninja",
                Content = "Coffee + Code = Productivity ☕💻 What's your favorite programming setup?",
                CreatedAt = DateTime.Now.AddHours(-5),
                Likes = 28,
                Comments = new List<string> { "Dark theme + mechanical keyboard!", "Same here!" },
                ImageUrl = "https://via.placeholder.com/800x400?text=Coffee+%26+Code"
            });

            samplePosts.Add(new SamplePost
            {
                Username = "Design Master",
                Content = "Just finished designing a new UI for our social platform. Clean, modern, and user-friendly! 🎨",
                CreatedAt = DateTime.Now.AddHours(-8),
                Likes = 67,
                Comments = new List<string> { "Looks amazing!", "Love the color scheme" },
                ImageUrl = "https://via.placeholder.com/800x400?text=Modern+UI+Design"
            });

            samplePosts.Add(new SamplePost
            {
                Username = "Dev Journey",
                Content = "Debugging is like being a detective in a crime movie where you're also the murderer. 🕵‍♂",
                CreatedAt = DateTime.Now.AddDays(-1),
                Likes = 156,
                Comments = new List<string> { "😂 So true!", "This is too real" },
                ImageUrl = "https://via.placeholder.com/800x400?text=Debugging+Life"
            });

            samplePosts.Add(new SamplePost
            {
                Username = "Learning Path",
                Content = "Started my journey with ASP.NET Core. Any tips for beginners? 🌟",
                CreatedAt = DateTime.Now.AddDays(-2),
                Likes = 34,
                Comments = new List<string> { "Start with the official docs!", "Build small projects first" },
                ImageUrl = "https://via.placeholder.com/800x400?text=ASP.NET+Core+Journey"
            });
        }

        private void CustomizeControls()
        {
            // Update welcome label with username
            lblWelcome.Text = $"Welcome back, {_currentUser.Username}! 👋";

            // Add gradient paint to top panel
            panelTop.Paint += (s, e) =>
            {
                var rect = panelTop.ClientRectangle;
                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect,
                    PRIMARY_COLOR,
                    PRIMARY_DARK,
                    45f))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            // Add shadow effect to panels
            AddPanelShadow(panelCreatePost);
            AddPanelShadow(panelFriendsContainer);
            AddPanelShadow(panelPostsContainer);

            // Set button hover effects
            SetButtonHoverEffect(btnRefresh, ACCENT_COLOR);
            SetButtonHoverEffect(btnLogout, DANGER_COLOR);
            SetButtonHoverEffect(btnCreatePost, PRIMARY_COLOR);

            // Add new feature buttons
            Button btnSearch = new Button
            {
                Text = "🔍 Search",
                Size = new Size(100, 40),
                Location = new Point(900, 25),
                BackColor = PRIMARY_COLOR,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += (s, e) => new SearchUsersForm(_currentUser).Show();
            SetButtonHoverEffect(btnSearch, PRIMARY_COLOR);
            panelTop.Controls.Add(btnSearch);

            Button btnMessages = new Button
            {
                Text = "💬 Messages",
                Size = new Size(100, 40),
                Location = new Point(1010, 25),
                BackColor = PRIMARY_COLOR,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnMessages.FlatAppearance.BorderSize = 0;
            btnMessages.Click += (s, e) => new MessagingForm(_currentUser).Show();
            SetButtonHoverEffect(btnMessages, PRIMARY_COLOR);
            panelTop.Controls.Add(btnMessages);

            Button btnNotifications = new Button
            {
                Text = "🔔 Notifications",
                Size = new Size(120, 40),
                Location = new Point(1120, 25),
                BackColor = PRIMARY_COLOR,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.Click += (s, e) => new NotificationsForm(_currentUser).Show();
            SetButtonHoverEffect(btnNotifications, PRIMARY_COLOR);
            panelTop.Controls.Add(btnNotifications);

            // Configure existing btnLogout button
            btnLogout.Text = "🚪 Logout";
            btnLogout.Click += (s, e) => LogoutUser();
            SetButtonHoverEffect(btnLogout, DANGER_COLOR);
        }

        private void LogoutUser()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }

        private void AddPanelShadow(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            };
        }

        private void SetButtonHoverEffect(Button btn, Color baseColor)
        {
            Color hoverColor = ControlPaint.Light(baseColor, 0.2f);

            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;
        }

        private void LoadUserData()
        {
            LoadAllUsers();
            LoadAllPosts();
        }

        private void LoadAllUsers()
        {
            friendsPanel.Controls.Clear();

            try
            {
                System.Data.DataTable dtUsers = UserDAL.GetAllUsers();

                if (dtUsers == null || dtUsers.Rows.Count == 0)
                {
                    Label noUsers = new Label
                    {
                        Text = "No users found",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10),
                        ForeColor = Color.Gray,
                        Padding = new Padding(20)
                    };
                    friendsPanel.Controls.Add(noUsers);
                    return;
                }

                foreach (System.Data.DataRow row in dtUsers.Rows)
                {
                    int userId = Convert.ToInt32(row["UserId"]);
                    if (userId == _currentUser.UserId) continue;

                    Panel userPanel = CreateUserPanel(row, userId);
                    friendsPanel.Controls.Add(userPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateUserPanel(System.Data.DataRow row, int userId)
        {
            Panel userPanel = new Panel
            {
                Size = new Size(350, 75),
                BackColor = Color.FromArgb(248, 249, 250),
                Margin = new Padding(8),
                BorderStyle = BorderStyle.None
            };

            userPanel.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220)),
                    0, 0, userPanel.Width - 1, userPanel.Height - 1);
            };

            // Avatar circle
            Panel avatar = new Panel
            {
                Size = new Size(50, 50),
                Location = new Point(12, 12),
                BackColor = PRIMARY_COLOR
            };

            string username = row["Username"].ToString();
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(new SolidBrush(PRIMARY_COLOR), 0, 0, 49, 49);

                string initial = username.Substring(0, 1).ToUpper();
                using (var sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(initial, new Font("Segoe UI", 18, FontStyle.Bold),
                        Brushes.White, 25, 25, sf);
                }
            };

            Label lblUsername = new Label
            {
                Text = username,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(70, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80)
            };

            Label lblEmail = new Label
            {
                Text = row["Email"].ToString(),
                Font = new Font("Segoe UI", 8),
                Location = new Point(70, 37),
                AutoSize = true,
                ForeColor = Color.FromArgb(127, 140, 141)
            };

            bool isFriend = FriendshipBLL.AreFriends(_currentUser.UserId, userId);

            Button btnAddFriend = new Button
            {
                Text = isFriend ? "✓ Friends" : "+ Add Friend",
                Size = new Size(95, 30),
                Location = new Point(240, 22),
                BackColor = isFriend ? Color.FromArgb(149, 165, 166) : PRIMARY_COLOR,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Tag = userId,
                Enabled = !isFriend
            };
            btnAddFriend.FlatAppearance.BorderSize = 0;

            if (!isFriend)
            {
                SetButtonHoverEffect(btnAddFriend, PRIMARY_COLOR);
            }

            // Fixed event handler - using proper lambda
            btnAddFriend.Click += (s, e) =>
            {
                AddFriend(userId, btnAddFriend);
            };

            userPanel.Controls.Add(avatar);
            userPanel.Controls.Add(lblUsername);
            userPanel.Controls.Add(lblEmail);
            userPanel.Controls.Add(btnAddFriend);

            return userPanel;
        }

        private void AddFriend(int friendUserId, Button btn)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Adding friend: CurrentUser={_currentUser.UserId}, Friend={friendUserId}");

                bool result = FriendshipBLL.AddFriend(_currentUser.UserId, friendUserId);

                if (result)
                {
                    btn.Text = "✓ Friends";
                    btn.BackColor = Color.FromArgb(149, 165, 166);
                    btn.Enabled = false;

                    MessageBox.Show("Friend added successfully! 🎉", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllPosts();
                }
                else
                {
                    MessageBox.Show("Failed to add friend. They may already be your friend or there was a database error.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding friend:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllPosts()
        {
            postsPanel.Controls.Clear();

            try
            {
                PostDAL postDAL = new PostDAL();
                List<Post> realPosts = new List<Post>();

                try
                {
                    realPosts = postDAL.GetFriendsPosts(_currentUser.UserId);
                    List<Post> myPosts = postDAL.GetUserPosts(_currentUser.UserId);
                    realPosts.AddRange(myPosts);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Database error: " + ex.Message);
                }

                if (realPosts.Count == 0)
                {
                    foreach (var samplePost in samplePosts)
                    {
                        AddPostToFeed(samplePost);
                    }
                }
                else
                {
                    foreach (var post in realPosts.OrderByDescending(p => p.CreatedAt))
                    {
                        AddRealPostToFeed(post, true);
                    }

                    foreach (var samplePost in samplePosts.Take(2))
                    {
                        AddPostToFeed(samplePost);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading posts: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                foreach (var samplePost in samplePosts)
                {
                    AddPostToFeed(samplePost);
                }
            }
        }

        private void AddRealPostToFeed(Post post, bool isRealPost)
        {
            Panel postPanel = new Panel
            {
                Size = new Size(1100, 200),
                BackColor = Color.FromArgb(252, 253, 255),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None
            };

            postPanel.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200), 1),
                    0, 0, postPanel.Width - 1, postPanel.Height - 1);
            };

            Label lblAuthor = new Label
            {
                Text = post.Username,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 12),
                AutoSize = true,
                ForeColor = PRIMARY_COLOR
            };

            Label lblDate = new Label
            {
                Text = GetTimeAgo(post.CreatedAt),
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 36),
                AutoSize = true,
                ForeColor = Color.Gray
            };

            Label lblContent = new Label
            {
                Text = post.Content,
                Font = new Font("Segoe UI", 11),
                Location = new Point(15, 60),
                Size = new Size(1070, 80),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = false
            };

            Panel actionsPanel = CreateActionsPanel(0, 0, null);

            postPanel.Controls.Add(lblAuthor);
            postPanel.Controls.Add(lblDate);
            postPanel.Controls.Add(lblContent);
            postPanel.Controls.Add(actionsPanel);

            // Add edit/delete buttons if post owner
            if (post.UserId == _currentUser.UserId)
            {
                Button btnEdit = new Button
                {
                    Text = "✏️ Edit",
                    Size = new Size(80, 30),
                    Location = new Point(1000, 12),
                    BackColor = PRIMARY_COLOR,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnEdit.FlatAppearance.BorderSize = 0;
                btnEdit.Click += (s, e) =>
                {
                    EditPostForm editForm = new EditPostForm(post);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllPosts();
                    }
                };
                postPanel.Controls.Add(btnEdit);

                Button btnDelete = new Button
                {
                    Text = "🗑️ Delete",
                    Size = new Size(80, 30),
                    Location = new Point(1000, 50),
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.Click += (s, e) =>
                {
                    DialogResult result = MessageBox.Show("Delete this post?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (PostDAL.DeletePost(post.PostId, _currentUser.UserId))
                        {
                            LoadAllPosts();
                            MessageBox.Show("Post deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                };
                postPanel.Controls.Add(btnDelete);
            }

            postsPanel.Controls.Add(postPanel);
        }

        private void AddPostToFeed(SamplePost post)
        {
            Panel postPanel = new Panel
            {
                Size = new Size(1100, 200),
                BackColor = Color.FromArgb(252, 253, 255),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None
            };

            postPanel.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200), 1),
                    0, 0, postPanel.Width - 1, postPanel.Height - 1);
            };

            Label lblAuthor = new Label
            {
                Text = post.Username,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 12),
                AutoSize = true,
                ForeColor = PRIMARY_COLOR
            };

            Label lblDate = new Label
            {
                Text = GetTimeAgo(post.CreatedAt),
                Font = new Font("Segoe UI", 9),
                Location = new Point(15, 36),
                AutoSize = true,
                ForeColor = Color.Gray
            };

            Label lblContent = new Label
            {
                Text = post.Content,
                Font = new Font("Segoe UI", 11),
                Location = new Point(15, 60),
                Size = new Size(1070, 80),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = false
            };

            Panel actionsPanel = CreateActionsPanel(post.Likes, post.Comments.Count, post);

            postPanel.Controls.Add(lblAuthor);
            postPanel.Controls.Add(lblDate);
            postPanel.Controls.Add(lblContent);
            postPanel.Controls.Add(actionsPanel);

            postsPanel.Controls.Add(postPanel);
        }

        private Panel CreatePostPanel()
        {
            Panel postPanel = new Panel
            {
                Size = new Size(840, 160),
                BackColor = Color.FromArgb(252, 253, 255),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None
            };

            postPanel.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)),
                    0, 0, postPanel.Width - 1, postPanel.Height - 1);
            };

            return postPanel;
        }

        private Panel CreateActionsPanel(int likes, int comments = 0, SamplePost samplePost = null)
        {
            Panel actionsPanel = new Panel
            {
                Location = new Point(15, 145),
                Size = new Size(1070, 45),
                BackColor = Color.FromArgb(245, 246, 250)
            };

            Button btnLike = CreateActionButton($"❤ Like ({likes})", new Point(10, 8));
            Button btnComment = CreateActionButton($"💬 Comment ({comments})", new Point(290, 8));
            Button btnShare = CreateActionButton("🔗 Share", new Point(570, 8));

            btnLike.Click += (s, e) =>
            {
                if (samplePost != null)
                {
                    samplePost.Likes++;
                    btnLike.Text = $"❤ Like ({samplePost.Likes})";
                }
                else
                {
                    int currentLikes = int.Parse(btnLike.Text.Split('(')[1].TrimEnd(')'));
                    btnLike.Text = $"❤ Like ({currentLikes + 1})";
                }
                btnLike.BackColor = Color.FromArgb(255, 220, 220);
                MessageBox.Show("Post liked! ❤", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnComment.Click += (s, e) =>
            {
                string comment = Microsoft.VisualBasic.Interaction.InputBox("Enter your comment:", "Comment", "");
                if (!string.IsNullOrWhiteSpace(comment))
                {
                    if (samplePost != null)
                    {
                        samplePost.Comments.Add(comment);
                        btnComment.Text = $"💬 Comment ({samplePost.Comments.Count})";
                    }
                    MessageBox.Show("Comment added successfully! 💬", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            btnShare.Click += (s, e) =>
            {
                MessageBox.Show("Post shared! 🔗", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            actionsPanel.Controls.Add(btnLike);
            actionsPanel.Controls.Add(btnComment);
            actionsPanel.Controls.Add(btnShare);

            return actionsPanel;
        }

        private Button CreateActionButton(string text, Point location)
        {
            Button btn = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(170, 30),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(100, 100, 100),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);

            return btn;
        }

        private string GetTimeAgo(DateTime dateTime)
        {
            TimeSpan timeSince = DateTime.Now - dateTime;
            if (timeSince.TotalMinutes < 1) return "Just now";
            if (timeSince.TotalMinutes < 60) return $"{(int)timeSince.TotalMinutes}m ago";
            if (timeSince.TotalHours < 24) return $"{(int)timeSince.TotalHours}h ago";
            if (timeSince.TotalDays < 7) return $"{(int)timeSince.TotalDays}d ago";
            return dateTime.ToString("MMM dd, yyyy");
        }

        private void TxtPostContent_Enter(object sender, EventArgs e)
        {
            if (txtPostContent.Text == PLACEHOLDER_TEXT)
            {
                txtPostContent.Text = "";
                txtPostContent.ForeColor = Color.Black;
            }
        }

        private void TxtPostContent_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostContent.Text))
            {
                txtPostContent.Text = PLACEHOLDER_TEXT;
                txtPostContent.ForeColor = Color.Gray;
            }
        }

        private void BtnCreatePost_Click(object sender, EventArgs e)
        {
            string content = txtPostContent.Text.Trim();

            if (string.IsNullOrEmpty(content) || content == PLACEHOLDER_TEXT)
            {
                MessageBox.Show("Please enter post content! ✍", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPostContent.Focus();
                return;
            }

            if (content.Length > 500)
            {
                MessageBox.Show("Post content is too long! Maximum 500 characters.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                System.Diagnostics.Debug.WriteLine($"Creating post for user: {_currentUser.UserId}, Content: {content}");

                PostDAL postDAL = new PostDAL();
                Post newPost = new Post
                {
                    UserId = _currentUser.UserId,
                    Username = _currentUser.Username,
                    Content = content,
                    CreatedAt = DateTime.Now
                };

                bool result = postDAL.CreatePost(newPost);

                if (result)
                {
                    MessageBox.Show("Post created successfully! 📤", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPostContent.Text = PLACEHOLDER_TEXT;
                    txtPostContent.ForeColor = Color.Gray;

                    LoadAllPosts();
                }
                else
                {
                    MessageBox.Show("Failed to create post. Please check your database connection and try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating post:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserData();
                MessageBox.Show("Feed refreshed! 🔄", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing feed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Form is already initialized in constructor
        }
    }

    public class SamplePost
    {
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public string ImageUrl { get; set; } // New: Image URL
    }
}