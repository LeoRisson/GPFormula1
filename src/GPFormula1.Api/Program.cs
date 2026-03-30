using GPFormula1.Dominio.Interfaces;
using GPFormula1.Dominio.Servicos;
using GPFormula1.Infra.Data;
using GPFormula1.Infra.Repositorios;
using GPFormula1.Infra.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GPFormula1.Api
{
    public class Program
    {
        private static IConfiguration? Configuration;

        public static async Task Main(string[] args)
        {
            try
            {
                var app = CriarWebApplication(args);
                await app.RunAsync();
            }
            catch (Exception ex)
            {
                // TODO: logar erro
                Console.WriteLine(ex.Message);
            }
        }

        private static WebApplication CriarWebApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Configuration = builder.Configuration;

            ConfigurarServicos(builder.Services);

            var app = builder.Build();

            ConfigurarAplicacao(app);

            return app;
        }

        private static void ConfigurarServicos(IServiceCollection Pcol_Services)
        {
            // DbContext
            Pcol_Services.AddDbContext<F1DbContext>(options =>
                options.UseSqlServer(Configuration!.GetConnectionString("DefaultConnection")));

            // Repositórios
            Pcol_Services.AddScoped<IPilotoRepositorio, PilotoRepositorio>();
            Pcol_Services.AddScoped<IEquipeRepositorio, EquipeRepositorio>();
            Pcol_Services.AddScoped<ITemporadaRepositorio, TemporadaRepositorio>();
            Pcol_Services.AddScoped<IGrandePremioRepositorio, GrandePremioRepositorio>();
            Pcol_Services.AddScoped<IResultadoCorridaRepositorio, ResultadoCorridaRepositorio>();

            //servicos
            Pcol_Services.AddScoped<IPilotoService, PilotoService>();
            Pcol_Services.AddScoped<IEquipeService, EquipeService>();
            Pcol_Services.AddScoped<ITemporadaService, TemporadaService>();
            Pcol_Services.AddScoped<IGrandePremioService, GrandePremioService>();
            Pcol_Services.AddScoped<IResultadoCorridaService, ResultadoCorridaService>();

            // Controllers
            Pcol_Services.AddControllers();

            // Swagger
            Pcol_Services.AddEndpointsApiExplorer();
            Pcol_Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GPFormula1 API",
                    Version = "v1"
                });
            });
        }

        private static void ConfigurarAplicacao(WebApplication app)
        {
            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GPFormula1 API v1");
                });
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            // Endpoint simples para teste
            app.MapGet("/api/teste", () => "API funcionando!");
        }
    }
}