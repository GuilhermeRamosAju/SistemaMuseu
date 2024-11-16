using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<ArtefatoDTO, Artefato>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o Id ao mapear de DTO para Entidade
            .ReverseMap();  // ReverseMap para mapear de Entidade para DTO

        CreateMap<FornecedorDTO, Fornecedor>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o Id ao mapear de DTO para Entidade
            .ReverseMap();

        CreateMap<CompraDTO, Compra>()
             .ForMember(dest => dest.Fornecedor, opt => opt.Ignore());

        CreateMap<Compra, CompraDTO>();

        CreateMap<DoacaoDTO, Doacao>()
            .ForMember(dest => dest.Artefato, opt => opt.Ignore()) 
            .ReverseMap();

        CreateMap<Doacao, DoacaoDTO>();

        CreateMap<EventoDTO, Evento>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o Id ao mapear de DTO para Entidade
            .ReverseMap();

        CreateMap<ExposicaoDTO, Exposicao>()
            .ForMember(dest => dest.Responsavel, opt => opt.Ignore()) // Ignora o Id ao mapear de DTO para Entidade
            .ReverseMap();

        CreateMap<Exposicao, ExposicaoDTO>();

        CreateMap<FuncionarioDTO, Funcionario>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o Id ao mapear de DTO para Entidade
            .ReverseMap();

        CreateMap<RestauracaoDTO, Restauracao>()
            .ForMember(dest => dest.Artefato, opt => opt.Ignore()) 
            .ReverseMap();

        CreateMap<Restauracao, RestauracaoDTO>();

        CreateMap<SecaoDTO, Secao>()
             .ForMember(dest => dest.Responsavel, opt => opt.Ignore()); // Ignora o Id ao mapear de DTO para Entidade

        CreateMap<Secao, SecaoDTO>();

        CreateMap<VisitanteDTO, Visitante>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o Id ao mapear de DTO para Entidade
            .ReverseMap();
    }

}
