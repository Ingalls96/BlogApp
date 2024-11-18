using BlogApp.Models.Identity;

namespace BlogApp.Models.Domain
{

    public class Post
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public string PostText { get; set; } = string.Empty;

        public string OwnerID { get; set; } = string.Empty; //represents the physical value in the database
        public BlogUser Owner { get; set; } = null!; //navigation property for MVCUser

        //navigation property showing relationship by convention comments/ many side
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}