using System.Security.Cryptography.X509Certificates;
using BlogApp.Models;
using BlogApp.Models.Domain;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context
{
    public class AuthDBContext : IdentityDbContext<BlogUser>
    {
        public DbSet<BlogUser> MVCUsers { get; set;}
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {
            

            
        }   
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}