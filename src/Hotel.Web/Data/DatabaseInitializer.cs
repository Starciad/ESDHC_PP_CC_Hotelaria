using Hotel.Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Data
{
    public sealed class DatabaseInitializer(AppDatabaseContext context)
    {
        public async Task SeedAsync()
        {
            _ = await context.Database.EnsureCreatedAsync();

            if (context.Rooms.Any())
            {
                return;
            }

            List<Room> rooms =
            [
                new()
                {
                    Title = "Standard Ocean View",
                    Description = "Wake up to the relaxing sound of the ocean with elegant interiors and premium comfort.",

                    Price = 1800,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Deluxe Beachfront",
                    Description = "Spacious beachfront room with exclusive access and breathtaking sunset views.",

                    Price = 2800,
                    Capacity = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1499793983690-e29da59ef1c2?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Premium Pool Suite",
                    Description = "Ultimate luxury with a private pool, panoramic terrace and premium room service.",

                    Price = 5500,
                    Capacity = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = true
                },

                new()
                {
                    Title = "Luxury Mountain Retreat",
                    Description = "Elegant mountain-side suite with fireplace and breathtaking panoramic scenery.",

                    Price = 4200,
                    Capacity = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Minimalist Executive Room",
                    Description = "Modern minimalist design focused on comfort and productivity.",

                    Price = 2100,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1566665797739-1674de7a421a?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = false,
                    HasPool = false
                }
            ];

            await context.Rooms.AddRangeAsync(rooms);
            _ = await context.SaveChangesAsync();
        }
    }
}
