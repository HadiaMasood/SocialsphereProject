using System;

namespace Models.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; } // Base64 or file path
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public int PostsCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserProfile()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            FollowersCount = 0;
            FollowingCount = 0;
            PostsCount = 0;
        }
    }
}
