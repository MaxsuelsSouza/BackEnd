namespace AgendaTelefonica.Api.Contratos.Contatos
{
    /// <summary>
    /// O que ele devovera apos adicionar um contato novo
    /// </summary>
    public class ContatosResponseContratos : ContatosRequestContratos
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
    }
}