using AluraAPI.Data.Dtos;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Profiles;

public class DestinoProfile : Profile
{
    public DestinoProfile()
    {
        CreateMap<CreateDestinoDto, Destino>();
        CreateMap<UpdateDestinoDto, Destino>();
        CreateMap<Destino, ReadDestinoDto>();
    }
}
