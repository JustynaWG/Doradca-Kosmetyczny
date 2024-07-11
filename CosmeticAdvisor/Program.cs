using CosmeticAdvisor.Repositories;
using CosmeticAdvisor.Services;
using CosmeticAdvisor.Data; // aby uzyska� dost�p do kontekstu EF Core
using Microsoft.EntityFrameworkCore; // aby uzyska� dost�p do konfiguracji bazy danych

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

            // Dodaj repozytoria i us�ugi do kontenera DI
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<ICosmeticRepository, CosmeticRepository>();
            builder.Services.AddScoped<ICosmeticService, CosmeticService>();

            builder.Services.AddScoped<IRecommendationRepository, RecommendationRepository>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();

            // Dodaj inne us�ugi do kontenera
            builder.Services.AddControllers();

            // Konfiguracja Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Konfiguracja pipeline ��da� HTTP
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