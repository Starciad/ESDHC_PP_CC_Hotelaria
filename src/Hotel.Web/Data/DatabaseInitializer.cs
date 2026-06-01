using Hotel.Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Data
{
    // DatabaseInitializer é uma classe responsável por inicializar o banco de dados com dados de exemplo.
    // Ela recebe uma instância do AppDatabaseContext e tem um método SeedAsync que garante
    // que o banco de dados seja criado e populado com uma lista de quartos (Room) se a tabela
    // estiver vazia. Isso é útil para fornecer dados iniciais para a aplicação, facilitando o desenvolvimento
    // e testes sem a necessidade de inserir manualmente os dados no banco.
    public sealed class DatabaseInitializer(AppDatabaseContext context)
    {
        public async Task SeedAsync()
        {
            _ = await context.Database.EnsureCreatedAsync();

            if (context.Rooms.Any())
            {
                return;
            }

            IEnumerable<Room> rooms =
            [
                new()
                {
                    Title = "Standard com Vista para o Mar",
                    Description = "Acorde com o som relaxante do oceano com interiores elegantes e conforto premium.",

                    Price = 1800,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Deluxe à Beira-Mar",
                    Description = "Quarto espaçoso à beira-mar com acesso exclusivo e vistas deslumbrantes do pôr do sol.",

                    Price = 2800,
                    Capacity = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1499793983690-e29da59ef1c2?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Suíte Premium com Piscina",
                    Description = "Luxo supremo com piscina privativa, terraço panorâmico e serviço de quarto premium.",

                    Price = 5500,
                    Capacity = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1611892440504-42a792e24d32?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = true
                },

                new()
                {
                    Title = "Retiro de Luxo nas Montanhas",
                    Description = "Elegante suíte na montanha com lareira e cenário panorâmico de tirar o fôlego.",

                    Price = 4200,
                    Capacity = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Quarto Executivo Minimalista",
                    Description = "Design minimalista moderno focado em conforto e produtividade.",

                    Price = 2100,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1566665797739-1674de7a421a?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = false,
                    HasPool = false
                },

                new()
                {
                    Title = "Chalé Rústico na Floresta",
                    Description = "Aconchegante chalé de madeira cercado por natureza exuberante e tranquilidade absoluta.",

                    Price = 1500,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1587061949409-02df41d5e562?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Suíte Presidencial",
                    Description = "A mais ampla e luxuosa suíte do hotel, com decoração requintada e vista panorâmica.",

                    Price = 8500,
                    Capacity = 6,
                    ImageUrl = "https://images.unsplash.com/photo-1578683010236-d716f9a3f461?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = true
                },

                new()
                {
                    Title = "Quarto Família",
                    Description = "Espaço ideal e interligado para famílias, unindo conforto, segurança e diversão.",

                    Price = 3200,
                    Capacity = 5,
                    ImageUrl = "https://images.unsplash.com/photo-1596394516093-501ba68a0ba6?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = false,
                    HasPool = false
                },

                new()
                {
                    Title = "Bangalô Sobre as Águas",
                    Description = "Experiência única em bangalôs luxuosos suspensos sobre águas cristalinas.",

                    Price = 6500,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1437648344686-224eee185e79?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = false
                },

                new()
                {
                    Title = "Cobertura Duplex",
                    Description = "Cobertura espetacular de dois andares com área de lazer exclusiva e amplos espaços.",

                    Price = 7000,
                    Capacity = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = true
                },

                new()
                {
                    Title = "Estúdio Econômico",
                    Description = "Opção prática e inteligente para viajantes curtos e profissionais de negócios.",

                    Price = 1200,
                    Capacity = 1,
                    ImageUrl = "https://images.unsplash.com/photo-1555854877-bab0e564b8d5?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = false,
                    HasPool = false
                },

                new()
                {
                    Title = "Vila Privativa",
                    Description = "Uma vila inteira para o seu grupo com áreas de lazer privativas, incluindo jardim e piscina.",

                    Price = 9500,
                    Capacity = 8,
                    ImageUrl = "https://images.unsplash.com/photo-1580587771525-78b9dba3b914?auto=format&fit=crop&w=1000&q=80",

                    HasWifi = true,
                    HasBalcony = true,
                    HasPool = true
                },

                new()
                {
                    Title = "Quarto Acessível",
                    Description = "Projetado com conforto, tecnologia e total segurança para pessoas com mobilidade reduzida.",

                    Price = 1600,
                    Capacity = 2,
                    ImageUrl = "https://images.unsplash.com/photo-1584622650111-993a426fbf0a?auto=format&fit=crop&w=1000&q=80",

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
