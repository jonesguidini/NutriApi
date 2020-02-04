using Nutrivida.Data.Context;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SQLContext DataContext) : base(DataContext)
        {
        }
    }
}