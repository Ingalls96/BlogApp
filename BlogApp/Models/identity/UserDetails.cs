using BlogApp.Models.Domain;

namespace BlogApp.Models.Identity
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}