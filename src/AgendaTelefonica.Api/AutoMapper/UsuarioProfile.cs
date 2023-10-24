using AgendaTelefonica.Api.Contratos.Usuario;
using AgendaTelefonica.Api.Damain.Models;
using AutoMapper;

namespace AgendaTelefonica.Api.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequestContrato>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseContrato>().ReverseMap();
        }
    }
}