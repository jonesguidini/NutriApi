using System.ComponentModel.DataAnnotations;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.DTOs
{
    public class UserForRegisterDto : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}