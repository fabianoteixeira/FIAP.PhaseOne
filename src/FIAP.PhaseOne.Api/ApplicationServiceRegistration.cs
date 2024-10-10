using FIAP.PhaseOne.Api.Mapping;

namespace FIAP.PhaseOne.Api;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
