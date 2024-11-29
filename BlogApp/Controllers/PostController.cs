using AspNetCoreGeneratedDocument;
using BlogApp.Data.Context;
using BlogApp.Models.Domain;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private readonly AuthDBContext _context;
        private readonly UserManager<BlogUser> _userManager;

        public PostController(AuthDBContext context,UserManager<BlogUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Post post)
        {
            if (!ModelState.IsValid)
            {

                post.OwnerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Add the post to the database
                _context.Add(post);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(post);
        }

        //POST DETAILS- GET Post details to display
        [HttpGet]
        public async Task<IActionResult> PostDetails(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Owner)
                .Include(p => p.Comments)
                .ThenInclude(c => c.Owner)
                .FirstOrDefaultAsync(m => m.PostId == id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //DELETE POST FUNCTION- GET post for deletion
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //DELETE POST CONFIRM - confirm deletion of post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDeleteConfirmed(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Home");
            }
            var post = await _context.Posts.FindAsync(id);
            if(post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        //COMMENT FUNCTION - POST comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int postId, string commentText)
        {
            if (string.IsNullOrEmpty(commentText))
            {
                return RedirectToAction("PostDetails", new {id = postId});
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var comment = new Comment
            {
                CommentText = commentText,
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                OwnerID = user.Id,
                PostId = postId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("PostDetails", new {id = postId});
        }
    }
}