using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Api.Damain.Services.Interface
{
    /// <summary>
    /// interface generica para criançao de serviços do tipo CRUD.
    /// </summary>
    /// <typeparam name="RQ">Contrato de request</typeparam>
    /// <typeparam name="RS">Contrato de response</typeparam>
    /// <typeparam name="I">Tipo do ID</typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Obter(I idUsuario);
        Task<RS> ObterPorId(I id, I idUsuario);
        Task<RS> Adicionar(RQ entidade, I idUsuario);
        Task<RS> Atualizar(I id, RQ entidade, I idUsuario);
        Task Deletar(I id, I idUsuario);
    }
}
