using System.ComponentModel.DataAnnotations;

namespace AgendaTelefonica.Api.Damain.Models
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Senha { get; set; } = string.Empty;


        /// <summary>
        /// irar ser usado na service para validaçao de email
        /// </summary>
        public Usuario(string email)
        {
            Email = email;
        }
        public Usuario(string senha, string email)
        {
            Senha = senha;
            Email = email;
        }
    }
}