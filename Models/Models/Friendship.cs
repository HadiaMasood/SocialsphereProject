using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Friendship
    {
        public int FriendshipId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Friendship()
        {
            CreatedAt = DateTime.Now;
        }

        public Friendship(int userId, int friendId)
        {
            UserId = userId;
            FriendId = friendId;
            CreatedAt = DateTime.Now;
        }
    }
}
