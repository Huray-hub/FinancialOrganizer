using Application.Interfaces;
using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Persistence
{
    public static class PersistenceDI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinancialOrganizerDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<Transaction>, EfRepository<Transaction>>();
                
            return services;
        }
    }
}
