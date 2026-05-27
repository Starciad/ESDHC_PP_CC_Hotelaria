using Hotel.Web.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Databases
{
    public sealed class AppDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }
    }
}
