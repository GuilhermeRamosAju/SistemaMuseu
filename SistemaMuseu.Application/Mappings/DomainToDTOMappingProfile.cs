using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<ArtefatoDTO, Artefato>().ReverseMap();
    }

}
