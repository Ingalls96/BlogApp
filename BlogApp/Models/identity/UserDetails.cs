using BlogApp.Models.Domain;

namespace BlogApp.Models.Identity
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public List<Post> Posts { get; set; } // Assuming Post is a model that holds posts
        public List<Comment> Comments { get; set; } // Assuming Comment is a model that holds comments
    }
}