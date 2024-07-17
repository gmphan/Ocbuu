using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ocbuu.DataAcess;
using Ocbuu.DataAcess.Repository;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;
using Ocbuu.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AzureSqlDbContext>(Options => Options.UseSqlServer(
  //                                  builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AzurePgDbContext>(Options => Options.UseNpgsql(
                                    builder.Configuration.GetConnectionString("PostgresConnection")));

/*  Authentication setup */
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<AzurePgDbContext>()
        .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
    });

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
/* End Authentication setup */

builder.Services.AddScoped<IUnityOfWork, UnitiyOfWork>();
builder.Services.AddScoped<IResumeServices, ResumerServices>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Visitor}/{controller=Home}/{action=Index}/{id?}");

app.Run();
