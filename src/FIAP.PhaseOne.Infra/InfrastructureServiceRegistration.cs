using FIAP.PhaseOne.Domain.ContactAggregate;
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

            using var scope = services.BuildServiceProvider().CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dataContext.Database.Migrate();

            return services;
        }
    }
}
