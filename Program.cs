using E_commerce.Database;
using Microsoft.EntityFrameworkCore;
using E_commerce.Database.context;

namespace E_commerce.Database.Entity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // Configure session options
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60); // Adjust addas needed
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add DbContext for ApplicationDbContext (ensure connection string is properly set in appsettings.json)
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);  // Use SQL Server database
            });

            // Build the app
            var app = builder.Build();

            // Configure middleware for session and other routing
            app.UseSession();  // Add session middleware
            app.UseRouting();
            app.UseSession();  // Add session middleware

            app.UseStaticFiles();  // Serve static files (like CSS, JS, images)

            // Use Authorization for protected resources
            app.UseAuthorization();

            // If in development mode, enable exception page
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();  // HTTP Strict Transport Security
            }

            app.UseHttpsRedirection();  // Enforce HTTPS
            app.MapRazorPages();  // Map Razor Pages

            app.Run();  // Run the app
        }
    }
}
