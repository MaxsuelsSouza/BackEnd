namespace AgendaTelefonica.Api.Damain.Repository.Interfaces
{
    /// <summary>
    /// interface generica para criançao de Repositorio do tipo CRUD.
    /// </summary>
    /// <typeparam name="T">tipo do repositorio</typeparam>
    /// <typeparam name="I">tipo do indentificador dela</typeparam>
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> Obter();
        Task<T?> ObterPorId(I id);
        Task<T> Adicionar(T entidade);
        Task<T> Atualizar(T entidade);
        Task Deletar(T entidade);
    }
}