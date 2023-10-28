using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonica.Api.Damain.Models
{
    public class Contatos
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Ocampo e obrigatorio.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ocampo e obrigatorio.")]
        public string Numero { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Nota { get; set; }


        /// <summary>
        /// irar ser usado na service para que o usuario atualize os dados de um contato
        /// </summary>
        public Contatos(
             string numero, string? email
             , string? nota, string nome)
        {
            Numero = numero;
            Email = email;
            Nota = nota;
            Nome = nome;
        }
    }
}