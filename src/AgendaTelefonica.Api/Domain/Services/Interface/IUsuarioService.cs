using AgendaTelefonica.Api.Contratos.Usuario;

namespace AgendaTelefonica.Api.Damain.Services.Interface
{
    public interface IUsuarioService : IService<
    UsuarioRequestContrato, UsuarioResponseContrato, long>
    {
        Task<UsuarioLoginResponseContrato> Autenticar(
            UsuarioLoginRequestContrato usuarioLoginRequestContrato);
        Task<UsuarioResponseContrato> ObterPorEmail(string telefone);
    }
}