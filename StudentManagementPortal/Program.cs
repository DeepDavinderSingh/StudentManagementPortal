using Microsoft.EntityFrameworkCore;
using StudentManagement.DataAccessLayer.Data;
using StudentManagement.DataAccessLayer.Repository;
using StudentManagement.DataAccessLayer.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using StudentManagement.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area=Students}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapControllerRoute(
            name: "default",
            pattern: "{area=Students}/{controller=Home}/{action=Index}/{id?}"); 

app.Run();