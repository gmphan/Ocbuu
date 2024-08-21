using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ocbuu.DataAcess;
using Ocbuu.DataAcess.Repository;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Models;
using Ocbuu.Services;
using OcbuuCore.Injectors;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Services has InjectServicesFromAssemblies because of extension.
builder.Services.InjectServicesFromAssemblies(builder.Configuration);

// inject Serilog
builder.InjectSerilogSetup();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Visitor}/{controller=Home}/{action=Index}/{id?}");

app.Run();
