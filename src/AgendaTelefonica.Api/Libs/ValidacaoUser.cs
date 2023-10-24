using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.Api.Damain.Models;

namespace AgendaTelefonica.Api.Libs
{
    public class ValidacaoUser
    {
        public static void Validation(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentException("Preencha todos os Campos");
            if (string.IsNullOrWhiteSpace(usuario.Email)) throw new ArgumentException("Preencha o campo email");
            if (!ValidacaoEmail.validEmail(usuario.Email)) throw new ArgumentException("Email inválido");

        }
    }
}