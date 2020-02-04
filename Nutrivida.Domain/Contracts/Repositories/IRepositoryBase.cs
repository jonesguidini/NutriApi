using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task Remove(TEntity obj);

        Task<IQueryable<TEntity>> GetById(Guid id);

        Task<IQueryable<TEntity>> GetById(Guid id, IList<string> includes);

        Task<IQueryable<TEntity>> GetAll();

        Task<IQueryable<TEntity>> GetAll(IList<string> includes);

        Task<IQueryable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
