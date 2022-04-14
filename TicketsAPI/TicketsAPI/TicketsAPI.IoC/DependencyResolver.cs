using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TicketsAPI.Data.Contexts;

namespace TicketsAPI.IoC
{
    public static class DependencyResolver
    {
        private static IConfiguration _config;

        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            _config = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json")
                          .Build();

            // Adicionar o AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            services.AddSingleton(config.CreateMapper());

            return services.AddRepoInfraestructure().AddServiceInfraestructure();
        }

        private static IServiceCollection AddServiceInfraestructure(this IServiceCollection services)
        {
            // services.AddTransient<IBankService, BankService>();

            return services;
        }

        private static IServiceCollection AddRepoInfraestructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>()
                    .AddDbContext<DataReadOnlyContext>();

            // Readonly
            // services.AddTransient<IBankRepoReadOnly, BankRepoReadOnly>();

            // Writable
            // services.AddTransient<IBankRepo, BankRepo>();

            return services;
        }
    }
}
