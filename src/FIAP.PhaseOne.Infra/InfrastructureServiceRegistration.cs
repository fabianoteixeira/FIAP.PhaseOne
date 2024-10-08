using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Infra.Context;
using FIAP.PhaseOne.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.PhaseOne.Infra
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));

            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
