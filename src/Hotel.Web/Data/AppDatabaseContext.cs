using Hotel.Web.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Web.Data
{
    // AppDatabaseContext é a classe que representa o contexto do banco de dados para a aplicação.
    // Ela herda de IdentityDbContext<ApplicationUser> para integrar o sistema de identidade do ASP.NET Core,
    // permitindo o gerenciamento de usuários e roles. Além disso, define DbSet para as entidades
    // Guest, Reserve, ReserveDependent e Room, que correspondem às tabelas do banco de dados.
    public sealed class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<ReserveDependent> ReserveDependents { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
