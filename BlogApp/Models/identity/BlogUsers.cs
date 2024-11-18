using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using BlogApp.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Models.Identity{

    public class BlogUser: IdentityUser{
        [Key]
        public override string Id { get; set; }
        public string FirstName { get; set; }   

        public string LastName { get; set; }

        //navigation properties
        public ICollection<Post> Posts {get; set;} = new List<Post>();

        public ICollection<Comment> Comments {get; set;} = new List<Comment>();

        public string FullName() => FirstName + " " + LastName;

        public int GetNumericId() => int.Parse(Id);
    }
}