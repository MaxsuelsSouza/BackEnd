using AgendaTelefonica.Api.Contratos.Contatos;
using AgendaTelefonica.Api.Damain.Models;
using AutoMapper;

namespace AgendaTelefonica.Api.AutoMapper
{
    public class ContatosProfile : Profile
    {
        public ContatosProfile()
        {
            CreateMap<Contatos, ContatosRequestContratos>().ReverseMap();
            CreateMap<Contatos, ContatosResponseContratos>().ReverseMap();
        }
    }
}