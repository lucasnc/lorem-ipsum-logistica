using AutoMapper;
using LoremIpsum.Data.Entities;
using LoremIpsum.Domain.Dtos;

namespace LoremIpsum.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ClienteDto, Cliente>()
                .ReverseMap();

            CreateMap<ClienteDtoCreate, Cliente>()
                .ReverseMap();

            CreateMap<ClienteDtoUpdate, Cliente>()
                .ReverseMap();

            CreateMap<EnderecoDto, Endereco>()
                .ReverseMap();

            CreateMap<EnderecoDtoCreate, Endereco>()
                .ReverseMap();

            CreateMap<EnderecoDtoUpdate, Endereco>()
                .ReverseMap();
        }
    }
}
