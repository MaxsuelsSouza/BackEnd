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
        public string? SobreNome { get; set; }
        [Required(ErrorMessage = "Ocampo e obrigatorio.")]
        public string Numero { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Endereco { get; set; }
        public string? RedeSocial { get; set; }
        public string? Nota { get; set; }

        public Contatos(
            string nome,
            string sobreNome,
            string numero,
            string email,
            string endereco,
            string redeSocial,
            string nota
        )
        {
            Nome = nome;
            SobreNome = sobreNome;
            Numero = numero;
            Email = email;
            Endereco = endereco;
            RedeSocial = redeSocial;
            Nota = nota;

        }

        public Contatos(
            string nome, string? sobreNome,
            string numero, string? email,
            string cpf, string? endereco,
            string? redeSocial, string? nota)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Numero = numero;
            Email = email;
            Cpf = cpf;
            Endereco = endereco;
            RedeSocial = redeSocial;
            Nota = nota;
        }
    }
}