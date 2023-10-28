namespace AgendaTelefonica.Api.Contratos.Usuario
{
    /// <summary>
    /// o que ele devolve ao usuario logado
    /// </summary>
    public class UsuarioResponseContrato : UsuarioRequestContrato
    {
        public long Id { get; set; }
    }
}