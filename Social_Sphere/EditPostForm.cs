using DataAccessLayer;
using Models.Models;
using System;
using System.Windows.Forms;

namespace Social_Sphere
{
    public partial class EditPostForm : Form
    {
        private Post _post;
        private TextBox txtContent;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCancel;

        public EditPostForm(Post post)
        {
            _post = post;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Edit Post";
            this.Width = 500;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblContent = new Label { Text = "Post Content:", Left = 10, Top = 10, Width = 100 };
            txtContent = new TextBox { Left = 10, Top = 40, Width = 460, Height = 150, Multiline = true, Text = _post.Content };
            
            btnSave = new Button { Text = "Save", Left = 10, Top = 200, Width = 100, DialogResult = DialogResult.OK };
            btnSave.Click += (s, e) => SavePost();
            
            btnDelete = new Button { Text = "Delete", Left = 120, Top = 200, Width = 100, DialogResult = DialogResult.Cancel };
            btnDelete.Click += (s, e) => DeletePost();
            
            btnCancel = new Button { Text = "Cancel", Left = 230, Top = 200, Width = 100 };
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblContent);
            this.Controls.Add(txtContent);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnCancel);
        }

        private void SavePost()
        {
            if (PostDAL.EditPost(_post.PostId, _post.UserId, txtContent.Text))
            {
                MessageBox.Show("Post updated!", "Success");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void DeletePost()
        {
            if (MessageBox.Show("Delete this post?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (PostDAL.DeletePost(_post.PostId, _post.UserId))
                {
                    MessageBox.Show("Post deleted!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
