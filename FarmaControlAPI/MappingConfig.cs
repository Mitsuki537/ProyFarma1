using AutoMapper;
using SharedModels;
using SharedModels.Dtos.Usuario;

namespace FarmaControlAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //Usario DTOs
            CreateMap<Usuario,UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDto>().ReverseMap();
        }
    }
}
