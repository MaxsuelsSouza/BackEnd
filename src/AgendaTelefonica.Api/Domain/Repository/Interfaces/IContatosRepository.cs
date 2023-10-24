using AgendaTelefonica.Api.Damain.Models;

namespace AgendaTelefonica.Api.Damain.Repository.Interfaces
{
    public interface IContatosRepository : IRepository<Contatos, long>
    {
        Task<IEnumerable<Contatos>> ObterPorIdUsuario(long idUsuario);
    }
}