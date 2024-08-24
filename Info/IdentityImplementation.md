You've set up the basics of ASP.NET Core Identity for user authentication and role management, including configuring Identity options and application cookies. Here's what you can consider doing next:

### 1. **Seed Initial Data (Roles and Users):**
   - **Seed Default Roles:** Create an initial set of roles (e.g., Admin, User) that can be used to manage permissions across the application.
   - **Seed Default Admin User:** Create a default administrator user during application startup if it doesn’t already exist.

   Example:
   ```csharp
   private async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
   {
       var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
       var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

       // Seed roles
       string[] roleNames = { "Admin", "User" };
       foreach (var roleName in roleNames)
       {
           if (!await roleManager.RoleExistsAsync(roleName))
           {
               await roleManager.CreateAsync(new IdentityRole(roleName));
           }
       }

       // Seed default admin user
       var adminUser = new ApplicationUser { UserName = "admin@yourdomain.com", Email = "admin@yourdomain.com" };
       if (userManager.Users.All(u => u.Email != adminUser.Email))
       {
           var result = await userManager.CreateAsync(adminUser, "Admin@123");
           if (result.Succeeded)
           {
               await userManager.AddToRoleAsync(adminUser, "Admin");
           }
       }
   }
   ```

   Call this method in your `Program.cs` after building the app:
   ```csharp
   using (var scope = app.Services.CreateScope())
   {
       var services = scope.ServiceProvider;
       var logger = services.GetRequiredService<ILogger<Program>>();
       try
       {
           await SeedRolesAndUsers(services);
       }
       catch (Exception ex)
       {
           logger.LogError(ex, "An error occurred while seeding roles and users.");
       }
   }
   ```

### 2. **Setup Role-Based Authorization:**
   - You might want to restrict certain parts of your application to specific roles. For example, you can add `[Authorize(Roles = "Admin")]` to controllers or actions that should only be accessible to administrators.

   Example:
   ```csharp
   [Authorize(Roles = "Admin")]
   public class AdminController : Controller
   {
       // Actions only accessible by Admin
   }
   ```

### 3. **Implement Account Management:**
   - **Registration:** Ensure you have a registration page for users to sign up.
   - **Login:** A login page should already be set up with the default Identity templates.
   - **Profile Management:** Allow users to manage their profile, change passwords, etc.

### 4. **Configure Email Confirmation and Password Reset:**
   - Set up email confirmation for new users to ensure their email addresses are valid.
   - Implement password reset functionality so users can recover their accounts if they forget their password.

   In `Program.cs`, update email sending configuration:
   ```csharp
   builder.Services.Configure<IdentityOptions>(options =>
   {
       options.SignIn.RequireConfirmedEmail = true;
   });

   builder.Services.AddTransient<IEmailSender, YourEmailSenderImplementation>();
   ```

### 5. **Add Logging and Error Handling:**
   - You've already set up Serilog for logging, but consider adding custom error handling pages for a better user experience.

### 6. **Test and Debug:**
   - Thoroughly test your authentication and authorization setup. Ensure that all roles and users have the correct access levels and that registration, login, and other Identity features work as expected.

### 7. **Documentation:**
   - Document your Identity setup, including any customizations, for future reference or for other developers who might work on the project.

Implementing these steps will give you a robust Identity setup in your ASP.NET Core application.