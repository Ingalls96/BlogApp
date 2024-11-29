using System.ComponentModel.DataAnnotations;
using BlogApp.Models.Domain;
using BlogApp.Models.Identity;

namespace BlogApp.Models.Domain
{

    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PostText { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public string OwnerID { get; set; }
        public virtual BlogUser Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime EditDate { get; internal set; }
    }
}
