using Nutrivida.Domain.Entities;
using System.Threading.Tasks;

namespace Nutrivida.Domain.Contracts.Repositories
{
    public interface IAuthRepository
    {
        
         Task<User> Register(User user, string password);

         Task<User> Login(string username, string password);

         Task<bool> UserExists(string username);
    }
}