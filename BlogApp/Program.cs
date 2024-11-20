using BlogApp.Data.Context;
using BlogApp.Models;
using BlogApp.Data.Config;
using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//logging for app
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddIdentity<BlogUser, IdentityRole>(options => {
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;    
}).AddEntityFrameworkStores<AuthDBContext>().AddDefaultTokenProviders();

//Add connection string
//builder.Services.AddDbContext<BasicDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BasicMVCContextString")));
builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//register the admin creation
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using(var scope = scopeFactory.CreateScope())
{
    await AuthConfig.ConfigAdmin(scope.ServiceProvider);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
