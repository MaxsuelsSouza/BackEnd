namespace AgendaTelefonica.Api.Contratos.Usuario
{
    /// <summary>
    /// O que ele espera que o usuario envie para poder fazer login
    /// </summary>
    public class UsuarioLoginRequestContrato
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;



    }
}