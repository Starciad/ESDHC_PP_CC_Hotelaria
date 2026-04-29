using Microsoft.EntityFrameworkCore;
using Hotelaria.Server.Models;

namespace Hotelaria.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}