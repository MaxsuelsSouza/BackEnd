using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.Api.Damain.Models;

namespace AgendaTelefonica.Api.Damain.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario, long>
    {
        Task<Usuario?> ObterPorEmail(string Email);
    }
}