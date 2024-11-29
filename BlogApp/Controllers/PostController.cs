using BlogApp.Data.Context;
using BlogApp.Models.Domain;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private readonly AuthDBContext _context;

        public PostController(AuthDBContext context)
        {
            _context = context;
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
                // Set the OwnerID based on the logged-in user (optional)
                post.OwnerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Add the post to the database
                _context.Add(post);
                await _context.SaveChangesAsync();

                // Redirect to the list of posts or wherever you'd like
                return RedirectToAction("Index", "Home");
            }

            // If the model is invalid, return to the form with validation errors
            return View(post);
        }
    }
}