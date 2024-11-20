using BlogApp.Data.Config;
using BlogApp.Data.Context;
using BlogApp.Models;
using BlogApp.Data;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class UserController : Controller
{
    // GET: UserController

    private AuthDBContext _data;

    public UserController(AuthDBContext context)
    {
        _data = context;
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

}
}
