namespace Social_Sphere
{
    partial class Dashboard
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.panelCreatePost = new System.Windows.Forms.Panel();
            this.btnCreatePost = new System.Windows.Forms.Button();
            this.txtPostContent = new System.Windows.Forms.TextBox();
            this.lblCreatePostTitle = new System.Windows.Forms.Label();
            this.panelFriendsContainer = new System.Windows.Forms.Panel();
            this.friendsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAllUsers = new System.Windows.Forms.Label();
            this.panelPostsContainer = new System.Windows.Forms.Panel();
            this.postsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFeed = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelCreatePost.SuspendLayout();
            this.panelFriendsContainer.SuspendLayout();
            this.panelPostsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.lblAppTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1700, 109);
            this.panelTop.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1040, 25);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1150, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblWelcome.Location = new System.Drawing.Point(148, 69);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(161, 30);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome back!";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(30, 15);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(341, 54);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "🌐 Social Sphere";
            // 
            // panelCreatePost
            // 
            this.panelCreatePost.BackColor = System.Drawing.Color.White;
            this.panelCreatePost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCreatePost.Controls.Add(this.btnCreatePost);
            this.panelCreatePost.Controls.Add(this.txtPostContent);
            this.panelCreatePost.Controls.Add(this.lblCreatePostTitle);
            this.panelCreatePost.Location = new System.Drawing.Point(25, 115);
            this.panelCreatePost.Name = "panelCreatePost";
            this.panelCreatePost.Size = new System.Drawing.Size(1050, 200);
            this.panelCreatePost.TabIndex = 1;
            // 
            // btnCreatePost
            // 
            this.btnCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(180)))));
            this.btnCreatePost.FlatAppearance.BorderSize = 0;
            this.btnCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePost.ForeColor = System.Drawing.Color.White;
            this.btnCreatePost.Location = new System.Drawing.Point(910, 150);
            this.btnCreatePost.Name = "btnCreatePost";
            this.btnCreatePost.Size = new System.Drawing.Size(120, 38);
            this.btnCreatePost.TabIndex = 2;
            this.btnCreatePost.Text = "📤 Post";
            this.btnCreatePost.UseVisualStyleBackColor = false;
            this.btnCreatePost.Click += new System.EventHandler(this.BtnCreatePost_Click);
            // 
            // txtPostContent
            // 
            this.txtPostContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtPostContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPostContent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostContent.ForeColor = System.Drawing.Color.Gray;
            this.txtPostContent.Location = new System.Drawing.Point(20, 60);
            this.txtPostContent.Multiline = true;
            this.txtPostContent.Name = "txtPostContent";
            this.txtPostContent.Size = new System.Drawing.Size(1010, 80);
            this.txtPostContent.TabIndex = 1;
            this.txtPostContent.Text = "What\'s on your mind?";
            this.txtPostContent.Enter += new System.EventHandler(this.TxtPostContent_Enter);
            this.txtPostContent.Leave += new System.EventHandler(this.TxtPostContent_Leave);
            // 
            // lblCreatePostTitle
            // 
            this.lblCreatePostTitle.AutoSize = true;
            this.lblCreatePostTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatePostTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCreatePostTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCreatePostTitle.Name = "lblCreatePostTitle";
            this.lblCreatePostTitle.Size = new System.Drawing.Size(323, 41);
            this.lblCreatePostTitle.TabIndex = 0;
            this.lblCreatePostTitle.Text = "✍ Create a New Post";
            // 
            // panelFriendsContainer
            // 
            this.panelFriendsContainer.BackColor = System.Drawing.Color.White;
            this.panelFriendsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFriendsContainer.Controls.Add(this.friendsPanel);
            this.panelFriendsContainer.Controls.Add(this.lblAllUsers);
            this.panelFriendsContainer.Location = new System.Drawing.Point(1150, 115);
            this.panelFriendsContainer.Name = "panelFriendsContainer";
            this.panelFriendsContainer.Size = new System.Drawing.Size(530, 760);
            this.panelFriendsContainer.TabIndex = 2;
            // 
            // friendsPanel
            // 
            this.friendsPanel.AutoScroll = true;
            this.friendsPanel.BackColor = System.Drawing.Color.White;
            this.friendsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.friendsPanel.Location = new System.Drawing.Point(15, 60);
            this.friendsPanel.Name = "friendsPanel";
            this.friendsPanel.Size = new System.Drawing.Size(500, 680);
            this.friendsPanel.TabIndex = 1;
            this.friendsPanel.WrapContents = false;
            // 
            // lblAllUsers
            // 
            this.lblAllUsers.AutoSize = true;
            this.lblAllUsers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAllUsers.Location = new System.Drawing.Point(20, 20);
            this.lblAllUsers.Name = "lblAllUsers";
            this.lblAllUsers.Size = new System.Drawing.Size(315, 38);
            this.lblAllUsers.TabIndex = 0;
            this.lblAllUsers.Text = "👥 Connect with Users";
            // 
            // panelPostsContainer
            // 
            this.panelPostsContainer.BackColor = System.Drawing.Color.White;
            this.panelPostsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPostsContainer.Controls.Add(this.postsPanel);
            this.panelPostsContainer.Controls.Add(this.lblFeed);
            this.panelPostsContainer.Location = new System.Drawing.Point(25, 335);
            this.panelPostsContainer.Name = "panelPostsContainer";
            this.panelPostsContainer.Size = new System.Drawing.Size(1050, 540);
            this.panelPostsContainer.TabIndex = 3;
            // 
            // postsPanel
            // 
            this.postsPanel.AutoScroll = true;
            this.postsPanel.BackColor = System.Drawing.Color.White;
            this.postsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.postsPanel.Location = new System.Drawing.Point(15, 60);
            this.postsPanel.Name = "postsPanel";
            this.postsPanel.Size = new System.Drawing.Size(1020, 460);
            this.postsPanel.TabIndex = 1;
            this.postsPanel.WrapContents = false;
            // 
            // lblFeed
            // 
            this.lblFeed.AutoSize = true;
            this.lblFeed.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFeed.Location = new System.Drawing.Point(20, 20);
            this.lblFeed.Name = "lblFeed";
            this.lblFeed.Size = new System.Drawing.Size(193, 38);
            this.lblFeed.TabIndex = 0;
            this.lblFeed.Text = "📰 Your Feed";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1700, 900);
            this.Controls.Add(this.panelPostsContainer);
            this.Controls.Add(this.panelFriendsContainer);
            this.Controls.Add(this.panelCreatePost);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Social Sphere - Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCreatePost.ResumeLayout(false);
            this.panelCreatePost.PerformLayout();
            this.panelFriendsContainer.ResumeLayout(false);
            this.panelFriendsContainer.PerformLayout();
            this.panelPostsContainer.ResumeLayout(false);
            this.panelPostsContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelCreatePost;
        private System.Windows.Forms.Label lblCreatePostTitle;
        private System.Windows.Forms.TextBox txtPostContent;
        private System.Windows.Forms.Button btnCreatePost;
        private System.Windows.Forms.Panel panelFriendsContainer;
        private System.Windows.Forms.Label lblAllUsers;
        private System.Windows.Forms.FlowLayoutPanel friendsPanel;
        private System.Windows.Forms.Panel panelPostsContainer;
        private System.Windows.Forms.Label lblFeed;
        private System.Windows.Forms.FlowLayoutPanel postsPanel;
    }
}
