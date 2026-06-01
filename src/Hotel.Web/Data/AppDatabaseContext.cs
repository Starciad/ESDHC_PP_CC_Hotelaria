using Hotel.Web.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Data
{
    public sealed class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<ReserveDependent> ReserveDependents { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
