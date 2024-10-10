using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FIAP.PhaseOne.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) {

            services.AddMediatR((x) => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
