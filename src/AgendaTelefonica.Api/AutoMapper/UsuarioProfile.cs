using AgendaTelefonica.Api.Contratos.Usuario;
using AgendaTelefonica.Api.Damain.Models;
using AutoMapper;

namespace AgendaTelefonica.Api.AutoMapper
{
    /// <summary>
    /// consegue converte um Usuario em usuarioRequest e usuarioRequest em Usuario
    /// </summary> <summary>
    /// consegue converte um Usuario em usuarioResponse e usuarioResponse em Usuario
    /// </summary>
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequestContrato>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseContrato>().ReverseMap();
        }
    }
}