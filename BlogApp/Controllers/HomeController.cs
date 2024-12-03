using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using BlogApp.Data.Context;
using Microsoft.AspNetCore.Identity;
using BlogApp.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AuthDBContext _data;
    private readonly UserManager<BlogUser> _userManager;

    public HomeController(ILogger<HomeController> logger, AuthDBContext data, UserManager<BlogUser> userManager)
    {
        _logger = logger;
        _data = data;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {

        var posts = await _data.Posts
            .Include(p => p.Owner)
            .OrderByDescending(p => p.CreateDate)
            .ToListAsync();

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return View(posts);
        }

        return View(posts);        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
