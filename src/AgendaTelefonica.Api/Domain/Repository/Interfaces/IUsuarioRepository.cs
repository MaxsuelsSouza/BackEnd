using AgendaTelefonica.Api.Damain.Models;

namespace AgendaTelefonica.Api.Damain.Repository.Interfaces
{
    /// <summary>
    /// herda de uma class generica e implementa o obter por email do usuario
    /// </summary>
    public interface IUsuarioRepository : IRepository<Usuario, long>
    {
        Task<Usuario?> ObterPorEmail(string Email);
    }
}