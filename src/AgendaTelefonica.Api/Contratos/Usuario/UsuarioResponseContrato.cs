using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Api.Contratos.Usuario
{
    public class UsuarioResponseContrato : UsuarioRequestContrato
    {
        public long Id { get; set; }
    }
}