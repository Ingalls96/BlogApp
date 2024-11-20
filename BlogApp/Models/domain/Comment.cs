using BlogApp.Models.Identity;

namespace BlogApp.Models.Domain
{


    public class Comment()
    {

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; }

        public string CommentText { get; set; } = string.Empty;

        public string OwnerID { get; set; } = string.Empty; //represents the physical value in the database
        public BlogUser Owner { get; set; } = null!; //navigation property for MVCUser

        public int PostId { get; set; }
        //navigation princple one side 
        public Post Post { get; set; } = null!;
    }
}