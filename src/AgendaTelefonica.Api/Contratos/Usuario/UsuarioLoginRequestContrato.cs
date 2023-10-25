namespace AgendaTelefonica.Api.Contratos.Usuario
{
    public class UsuarioLoginRequestContrato
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public UsuarioLoginRequestContrato(string email, string senha)
        {
            Email = email;
            Senha = senha;

        }

    }
}