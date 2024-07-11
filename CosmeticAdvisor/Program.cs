using CosmeticAdvisor.Repositories;
using CosmeticAdvisor.Services;
using CosmeticAdvisor.Data; // aby uzyskaæ dostêp do kontekstu EF Core
using Microsoft.EntityFrameworkCore; // aby uzyskaæ dostêp do konfiguracji bazy danych

namespace CosmeticAdvisor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodaj kontekst bazy danych do kontenera DI
            builder.Services.AddDbContext<CosmeticAdvisorContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-RM3VCAU\\\\SQLEXPRESS01;Database=CosmeticAdvisorDB;Trusted_Connection=True;MultipleActiveResultSets=true")));

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