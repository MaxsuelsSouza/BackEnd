using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Damain.Repository.Interfaces;
using AgendaTelefonica.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Api.Damain.Repository.Classes
{
    public class ContatosRepository : IContatosRepository
    {
        private readonly AplicationContext _contexto;
        public ContatosRepository(AplicationContext context)
        {
            _contexto = context;
        }

        public async Task<Contatos> Adicionar(Contatos entidade)
        {
            await _contexto.Contatos.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            return entidade;
        }
        public async Task<Contatos> Atualizar(Contatos entidade)
        {
            Contatos entidadeBanco = _contexto.Contatos
            .Where(u => u.Id == entidade.Id)
            .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Contatos>(entidadeBanco);

            await _contexto.SaveChangesAsync();
            return entidadeBanco;
        }
        public async Task Deletar(Contatos entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Deleted;
            await _contexto.SaveChangesAsync();
        }
        public async Task<IEnumerable<Contatos>> Obter()
        {
            return await _contexto
            .Contatos.AsNoTracking()
            .OrderBy(u => u.Id)
            .ToListAsync();
        }
        public async Task<Contatos?> ObterPorId(long id)
        {
            return await _contexto
            .Contatos.AsNoTracking()
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Contatos>> ObterPorIdUsuario(long idUsuario)
        {
            return await _contexto
            .Contatos.AsNoTracking()
            .Where(n => n.IdUsuario == idUsuario)
            .OrderBy(n => n.Id)
            .ToListAsync();
        }
    }
}