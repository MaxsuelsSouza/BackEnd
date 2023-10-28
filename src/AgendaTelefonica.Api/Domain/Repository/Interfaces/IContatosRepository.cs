using AgendaTelefonica.Api.Damain.Models;

namespace AgendaTelefonica.Api.Damain.Repository.Interfaces
{
    /// <summary>
    /// herda de uma class generica e implementa o obter por idusuario
    /// </summary>
    public interface IContatosRepository : IRepository<Contatos, long>
    {
        Task<IEnumerable<Contatos>> ObterPorIdUsuario(long idUsuario);
    }
}