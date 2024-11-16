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
        services.AddScoped<ICompraRepository, CompraRepository>();
        services.AddScoped<IDoacaoRepository, DoacaoRepository>();
        services.AddScoped<IEventoRepository, EventoRepository>();
        services.AddScoped<IExposicaoRepository, ExposicaoRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        services.AddScoped<IRestauracaoRepository, RestauracaoRepository>();
        services.AddScoped<ISecaoRepository, SecaoRepository>();
        services.AddScoped<IVisitanteRepository, VisitanteRepository>();

        // Services
        services.AddScoped<IArtefatoService, ArtefatoService>();
        services.AddScoped<ICompraService, CompraService>();
        services.AddScoped<IDoacaoService, DoacaoService>();
        services.AddScoped<IEventoService, EventoService>();
        services.AddScoped<IExposicaoService, ExposicaoService>();
        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IFuncionarioService, FuncionarioService>();
        services.AddScoped<IRestauracaoService, RestauracaoService>();
        services.AddScoped<ISecaoService, SecaoService>();
        services.AddScoped<IVisitanteService, VisitanteService>();


        return services;
    }
}
