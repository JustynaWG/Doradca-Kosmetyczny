using CosmeticAdvisor.Business;
using CosmeticAdvisor.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CosmeticAdvisor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Rejestracja kontekstu Dapper
            builder.Services.AddSingleton<DapperContext>();

            // Rejestracja IDbConnection
            builder.Services.AddSingleton<IDbConnection>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("Server=DESKTOP-RM3VCAU\\\\SQLEXPRESS01;Database=CosmeticAdvisorDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                return new SqlConnection(connectionString);
            });

            // Rejestracja repozytoriów i us³ug
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<ICosmeticRepository, CosmeticRepository>();
            builder.Services.AddScoped<ICosmeticService, CosmeticService>();

            builder.Services.AddScoped<IRecommendationRepository, RecommendationRepository>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();

            // Dodanie kontrolerów
            builder.Services.AddControllers();

            // Konfiguracja Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Konfiguracja middleware HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
