using Administration.Domain.Repositories;
using Administration.Infrastructure.Persistence;
using Administration.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Administration.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdministrationDbContext>(options => 
            options.UseMySql(configuration.GetConnectionString("AdministrationConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("AdministrationConnection"))
            ));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
