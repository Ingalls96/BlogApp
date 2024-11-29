using BlogApp.Data.Config;
using BlogApp.Data.Context;
using BlogApp.Models;
using BlogApp.Data;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BlogApp.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController

        private AuthDBContext _data;
        private readonly UserManager<BlogUser> _userManager;

        public UserController(AuthDBContext context, UserManager<BlogUser> userManager)
        {
            _data = context;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListUsers()
        {
            List<BlogUser> userList = await _data.BlogUsers.ToListAsync<BlogUser>();
            return View(userList);
        }

        //EDIT CONTROLLER - Call User Information to the page 
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _data.BlogUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //EDIT CONTROLLER - Save new edits to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, BlogUser updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingUser = await _data.BlogUsers.FindAsync(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                // Update the entity with the new values
                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;

                try
                {
                    _data.Update(existingUser);
                    await _data.SaveChangesAsync();
                    return RedirectToAction(nameof(ListUsers));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error while saving changes: " + ex.Message);
                    return View(updatedUser);
                }
            }

            return View(updatedUser);
        }

        //DELETE USER FUNCTION - Get user info
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _data.BlogUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user); // Return the user to confirm deletion
        }

        //DELETE USER FUNCTION - Deletion of user

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            // Debug log to check the passed id
            Console.WriteLine($"Deleting user with ID: {id}");

            if (string.IsNullOrEmpty(id))
            {
                return Redirect("/User/ListUsers");
            }
            var user = await _data.BlogUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _data.BlogUsers.Remove(user);
            await _data.SaveChangesAsync();

            return Redirect("/User/ListUsers"); // Redirect to the list of users
        }

        //CREATE USER - Get Action for empty field view

        public IActionResult Create()
        {
            return View(new BlogUser());
        }

        //CREATE USER -Post Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogUser newUser, string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Validate the password before attempting to create the user
                    var passwordValidationResult = ValidatePassword(password);
                    if (!passwordValidationResult.IsValid)
                    {
                        // Add password validation errors to ModelState
                        foreach (var error in passwordValidationResult.Errors)
                        {
                            ModelState.AddModelError("Password", error);
                        }

                        // Return the view with the error messages
                        return View(newUser);
                    }


                    // Create the user using UserManager with a password
                    var result = await _userManager.CreateAsync(newUser, password);

                    if (result.Succeeded)
                    {
                        // Redirect to the list of users after successful creation
                        return RedirectToAction(nameof(ListUsers));
                    }
                    else
                    {
                        // Add errors from the Identity result to the model state
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error creating user: " + ex.Message);
                }
            }
            return View(newUser);
        }

        // Password validation method
        private (bool IsValid, List<string> Errors) ValidatePassword(string password)
        {
            var errors = new List<string>();

            // Check password length
            if (password.Length < 8)
            {
                errors.Add("Password must be at least 8 characters long.");
            }

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
            {
                errors.Add("Password must contain at least one uppercase letter.");
            }

            // Check for at least one digit
            if (!password.Any(char.IsDigit))
            {
                errors.Add("Password must contain at least one number.");
            }

            // Check for at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                errors.Add("Password must contain at least one special character.");
            }

            return (errors.Count == 0, errors);
        }
        //GET USER DETAILS
        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound(); // Return a NotFound if ID is null or empty.
            }

            var user = await _data.Users
                .Include(u => u.Posts) // Include posts associated with the user
                .Include(u => u.Comments) // Include comments associated with the user
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // If no user is found, return a NotFound response.
            }

            // If user is found, pass it to the view
            return View(user);
        }
    }


}

