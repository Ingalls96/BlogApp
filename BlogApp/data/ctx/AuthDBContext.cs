using System.Security.Cryptography.X509Certificates;
using BlogApp.Models;
using BlogApp.Models.Domain;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context
{
    public class AuthDBContext : IdentityDbContext<BlogUser>
    {
        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            
            model.Entity<IdentityUserRole<string>>()
                .HasIndex(r => r.UserId)
                .IsUnique(false);
            
            model.Entity<BlogUser>().HasData(
                new BlogUser { Id = "1", FirstName = "Default Application User", LastName = "DumDum", UserName ="user", Email = "blah@blah.com", PhoneNumber = "555-555-5555" }
            );

        }
    }
}