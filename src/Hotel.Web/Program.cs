using Hotel.Web.Databases;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;

namespace Hotel.Web
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            _ = builder.Services.AddControllersWithViews();
            _ = builder.Services.AddDbContext<AppDatabaseContext>(options =>
            {
                _ = options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString"));
            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                _ = app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using IServiceScope serviceScope = app.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            try
            {
                AppDatabaseContext context = serviceProvider.GetRequiredService<AppDatabaseContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                ILogger logger = serviceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred during the migration process.");
            }

            app.Run();
        }
    }
}
