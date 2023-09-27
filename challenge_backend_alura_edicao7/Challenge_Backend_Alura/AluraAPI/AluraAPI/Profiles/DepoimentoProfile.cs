using AluraAPI.Data.Dtos;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Profiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<CreateDepoimentoDto, Depoimento>();
        CreateMap<UpdateDepoimentoDto, Depoimento>();
    }
}
