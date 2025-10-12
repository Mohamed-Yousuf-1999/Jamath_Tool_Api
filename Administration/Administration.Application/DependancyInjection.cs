using Administration.Application.Contributors.DTOs;
using Administration.Application.Contributors.Mapping;
using Administration.Domain.DTOs;
using Administration.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Administration.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(asm));

            services.AddLogging();

            var sp = services.BuildServiceProvider();
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

            var configuration = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<ContributorProfile>();
                cfg.AddMaps(typeof(UserProfile).Assembly);

            }, loggerFactory);

            services.AddSingleton(configuration);
            services.AddSingleton<IMapper>(sp => configuration.CreateMapper());

            return services;
        }
    }
}
