using LTrinhWebNhom3.Data;
using LTrinhWebNhom3.Models;
using LTrinhWebNhom3.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Đặt trước AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
 .AddDefaultTokenProviders()
 .AddDefaultUI()
 .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.LogoutPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<IProjectImageRespository, EFProjectImageRespository>();
builder.Services.AddScoped<IPortfolioRepository, EFPortfolioRepository >();
builder.Services.AddScoped<IProjectRepository, EFProjectRespository>();
builder.Services.AddScoped<ITagRepository, EFTagRepository>();
builder.Services.AddScoped<IPortfolioImageRepository, EFPortfolioImageRepository>();
builder.Services.AddScoped<IApplicationUserRepository, EFApplicationUserRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.MapRazorPages();
app.Run();
