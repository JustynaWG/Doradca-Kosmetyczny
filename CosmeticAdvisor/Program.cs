using CosmeticAdvisor.Repositories;
using CosmeticAdvisor.Services;

namespace CosmeticAdvisor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodaj DapperContext jako singleton
            builder.Services.AddSingleton<DapperContext>();

            // Dodaj repozytoria i us³ugi do kontenera DI
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<ICosmeticRepository, CosmeticRepository>();
            builder.Services.AddScoped<ICosmeticService, CosmeticService>();

            builder.Services.AddScoped<IRecommendationRepository, RecommendationRepository>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();



            // Dodaj inne us³ugi do kontenera
            builder.Services.AddControllers();

            // Konfiguracja Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<DapperContext>();


            var app = builder.Build();

            // Konfiguracja pipeline ¿¹dañ HTTP
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