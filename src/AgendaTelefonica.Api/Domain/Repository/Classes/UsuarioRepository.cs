using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Damain.Repository.Interfaces;
using AgendaTelefonica.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Api.Damain.Repository.Classes
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AplicationContext _contexto;

        public UsuarioRepository(AplicationContext context)
        {
            _contexto = context;
        }
        public async Task<Usuario> Adicionar(Usuario entidade)
        {
            await _contexto.Usuario.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            return entidade;
        }
        public async Task<Usuario> Atualizar(Usuario entidade)
        {
            Usuario entidadeBanco = _contexto.Usuario
            .Where(u => u.Id == entidade.Id)
            .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Usuario>(entidadeBanco);

            await _contexto.SaveChangesAsync();
            return entidadeBanco;
        }
        public async Task Deletar(Usuario entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Deleted;
            await _contexto.SaveChangesAsync();
        }
        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _contexto
            .Usuario.AsNoTracking()
            .OrderBy(u => u.Id)
            .ToListAsync();
        }
        public async Task<Usuario?> ObterPorId(long id)
        {
            return await _contexto
            .Usuario.AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        }
        public async Task<Usuario?> ObterPorEmail(string email)
        {
            return await _contexto
            .Usuario.AsNoTracking()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(); ;
        }
    }


}