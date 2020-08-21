using Application.Common.Adapters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Persistence
{
    public static class PersistenceDI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FODbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbContext, FODbContext>();
            services.AddScoped<IUnitOfWorkQuery, UnitOfWorkQuery>();
            services.AddScoped<IUnitOfWorkCommand, UnitOfWorkCommand>();

            return services;
        }
    }
}
