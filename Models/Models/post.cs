using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    
        public class Post
        {
            public int PostId { get; set; }
            public int UserId { get; set; }
            public string Username { get; set; } // For display purposes
            public string Content { get; set; }
            public DateTime CreatedAt { get; set; }

            public Post()
            {
                CreatedAt = DateTime.Now;
            }

            public Post(int userId, string content)
            {
                UserId = userId;
                Content = content;
                CreatedAt = DateTime.Now;
            }
        }
    }
