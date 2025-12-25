using DataAccessLayer;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLogicLayer
{
    public class PostBLL
    {
        private static PostDAL postDAL = new PostDAL();

        public static bool CreatePost(int userId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return false;
            }

            Post post = new Post(userId, content);
            return postDAL.CreatePost(post);
        }

        public static List<Post> GetUserPosts(int userId)
        {
            return postDAL.GetUserPosts(userId);
        }

        public static List<Post> GetFriendsPosts(int userId)
        {
            return postDAL.GetFriendsPosts(userId);
        }

        public static bool DeletePost(int postId)
        {
            return postDAL.DeletePost(postId);
        }
    }
    
}
