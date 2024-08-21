Separating the setup in `Program.cs` into different files is a common practice to keep the code clean, organized, and maintainable. You can achieve this by using extension methods to encapsulate different parts of the configuration and service registration. Here’s how you can do it:

### 1. **Create Extension Methods for Service Configurations**

You can create static classes with extension methods that encapsulate the service configuration logic. For example, let's break down the `Program.cs` setup into separate methods for Identity, Serilog, and other services.

#### a. **Serilog Configuration:**

Create a class `SerilogSetup.cs`:

```csharp
public static class SerilogSetup
{
    public static void AddSerilogSetup(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day));
    }
}
```

#### b. **Identity Configuration:**

Create a class `IdentitySetup.cs`:

```csharp
public static class IdentitySetup
{
    public static void AddIdentitySetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AzurePgDbContext>(Options => Options.UseNpgsql(
                                        configuration.GetConnectionString("PostgresConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AzurePgDbContext>()
                .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/AccessDenied";
        });
    }
}
```

#### c. **Other Services Configuration:**

Create a class `ServiceSetup.cs`:

```csharp
public static class ServiceSetup
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnityOfWork, UnitiyOfWork>();
        services.AddScoped<IResumeServices, ResumerServices>();
        // Add other service registrations here
    }
}
```

### 2. **Use the Extension Methods in `Program.cs`**

Now, in your `Program.cs`, you can simply call these methods:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure Serilog from appsettings.json
builder.AddSerilogSetup();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Identity setup
builder.Services.AddIdentitySetup(builder.Configuration);

// Add application-specific services
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
```

### 3. **Organize Your Code Structure**

To keep your project well-organized, consider placing these extension methods in a folder named `Extensions` or `Setup` within your project. This helps maintain a clean structure and makes it easy to find related setup code.

### Summary
By following this approach, your `Program.cs` file becomes much cleaner, and the setup logic is modularized into separate files. This makes your project easier to maintain and enhances readability.