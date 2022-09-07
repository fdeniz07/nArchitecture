using RentACar.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Persistence.Contexts;
using RentACar.Persistence.Repositories;

namespace RentACar.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            //services.AddDbContext<BaseDbContext>(options =>
            //                                         options.UseSqlServer(
            //                                             configuration.GetConnectionString("RentACarCampConnectionString")));
            services.AddDbContext<BaseDbContext>(options =>options.UseNpgsql(configuration.GetConnectionString("RentACarCampConnectionString")));
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();

            return services;
        }
    }
}
