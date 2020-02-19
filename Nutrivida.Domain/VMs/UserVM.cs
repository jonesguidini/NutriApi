using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class UserVM : DeletedEntityVM
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}