using System.ComponentModel.DataAnnotations;

namespace Nutrivida.Domain.DTOs
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "Informe o nome")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }
    }
}