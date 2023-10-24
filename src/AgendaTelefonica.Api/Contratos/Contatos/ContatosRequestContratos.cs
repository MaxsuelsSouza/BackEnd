using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Api.Contratos.Contatos
{
    public class ContatosRequestContratos
    {
        public string Nome { get; set; } = string.Empty;
        public string? SobreNome { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Endereco { get; set; }
        public string? RedeSocial { get; set; }
        public string? Nota { get; set; }
    }
}