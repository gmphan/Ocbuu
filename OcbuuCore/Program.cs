using OcbuuCore.Injectors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ocbuu.DataAcess;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Services has InjectServicesFromAssemblies because of extension.
builder.Services.InjectServicesFromAssemblies(builder.Configuration);

// inject Serilog
builder.InjectSerilogSetup();


var app = builder.Build();

// Seed the admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Resolve AdminSeederInjector and call SeedAdminUser
        var adminSeeder = services.GetRequiredService<AdminSeederInjector>();
        await adminSeeder.SeedAdminUser(services);
    }
    catch (Exception ex)
    {
        // Log errors (optional)
        Log.Error(ex, "An error occurred while seeding the admin user.");
    }
}

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Visitor}/{controller=Home}/{action=Index}/{id?}");

app.Run();
