using Hotel.Web.Data;
using Hotel.Web.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace Hotel.Web
{
    internal static class Program
    {
        [MTAThread]
        private static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Registra os serviços necessários na injeção de dependência.
            // Adiciona suporte a controladores e views para o padrão MVC.
            _ = builder.Services.AddControllersWithViews();

            // Configura o Entity Framework Core para usar SQLite como banco de dados.
            _ = builder.Services.AddDbContext<AppDatabaseContext>(options =>
            {
                _ = options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString"));
            });

            // Configura a autenticação usando cookies e define o caminho para a página de login.
            _ = builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            // Configura o Identity para gerenciar usuários e roles, definindo as regras de senha.
            _ = builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDatabaseContext>()
            .AddDefaultTokenProviders();

            // Constrói a aplicação a partir das configurações definidas.
            WebApplication app = builder.Build();

            // Configura o pipeline de processamento das requisições HTTP.
            if (!app.Environment.IsDevelopment())
            {
                _ = app.UseExceptionHandler("/Home/Error");
                
                // HSTS (HTTP Strict Transport Security) é uma política de segurança que
                // instrui os navegadores a se comunicarem apenas por HTTPS, aumentando
                // a segurança da aplicação.
                _ = app.UseHsts();
            }

            // Redireciona HTTP para HTTPS e habilita arquivos estáticos.
            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            // Ativa o roteamento e os middlewares de autenticação e autorização.
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            // Define a rota padrão para os controladores,direcionando para HomeController e Index action.
            _ = app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            // Cria um escopo de serviço para acessar os serviços registrados na injeção de dependência.
            using IServiceScope serviceScope = app.Services.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            try
            {
                // Aplica as migrations pendentes antes de iniciar a aplicação.
                // Isso garante que o banco de dados esteja atualizado com a estrutura
                // definida pelas migrations.
                AppDatabaseContext context = serviceProvider.GetRequiredService<AppDatabaseContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                // Em caso de erro durante a aplicação das migrations, registra o erro usando o logger.
                ILogger logger = serviceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred during the migration process.");
            }

            // Após garantir que o banco de dados esteja atualizado,
            // executa a rotina de seed para inserir dados iniciais.
            // Todos os dados advém da classe DatabaseInitializer,
            // que é responsável por popular o banco de dados com
            // informações essenciais para o funcionamento da aplicação.
            using (IServiceScope scope = app.Services.CreateScope())
            {
                // Obtém o provedor de serviços para acessar os serviços
                // registrados na injeção de dependência.
                IServiceProvider services = scope.ServiceProvider;

                // Executa a rotina de seed para garantir dados iniciais.
                AppDatabaseContext context = services.GetRequiredService<AppDatabaseContext>();
                DatabaseInitializer databaseInitializer = new(context);

                await databaseInitializer.SeedAsync();
            }

            // Inicia a aplicação, permitindo que ela comece a processar as requisições HTTP.
            // O método Run é bloqueante, ou seja, a aplicação permanecerá em execução
            // até que seja encerrada manualmente ou por algum evento externo.
            app.Run();
        }
    }
}
