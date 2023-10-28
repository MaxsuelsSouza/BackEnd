using AgendaTelefonica.Api.Contratos.Contatos;
using AgendaTelefonica.Api.Damain.Models;
using AutoMapper;

namespace AgendaTelefonica.Api.AutoMapper
{
    /// <summary>
    /// Consegue converte um Contato em ContatoRequest e ContatoRequest em Contato
    /// </summary> <summary>
    /// Consegue Converte um Contato em ContatoResponse e ContatoResponse em Contato
    /// </summary>
    public class ContatosProfile : Profile
    {
        public ContatosProfile()
        {
            CreateMap<Contatos, ContatosRequestContratos>().ReverseMap();
            CreateMap<Contatos, ContatosResponseContratos>().ReverseMap();
        }
    }
}