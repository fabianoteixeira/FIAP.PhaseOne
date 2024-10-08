using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Application.Mapping;
using FIAP.PhaseOne.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.PhaseOne.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) {

            services.AddScoped<IContactService, ContactService>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
