using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaMuseu.Infrastructure.Context;
using SistemaMuseu.Application.Mappings;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MuseuContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        // Repositories
        services.AddScoped<IArtefatoRepository, ArtefatoRepository>();

        // Services
        services.AddScoped<IArtefatoService, ArtefatoService>();


        return services;
    }
}
