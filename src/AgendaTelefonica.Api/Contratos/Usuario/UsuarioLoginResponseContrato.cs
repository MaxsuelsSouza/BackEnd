using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Api.Contratos.Usuario
{
    /// <summary>
    /// O que ele devolve ao usuario depois dele fazer login
    /// </summary>
    public class UsuarioLoginResponseContrato
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;


    }
}