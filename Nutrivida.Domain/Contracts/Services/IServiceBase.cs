using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Filters;
using Nutrivida.Domain.VMs;

namespace Nutrivida.Domain.Contracts.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);

        Task<TEntity> Update(TEntity obj);

        Task Delete(Guid id);

        Task<IQueryable<TEntity>> GetById(Guid id);

        Task<IQueryable<TEntity>> GetById(Guid id, IList<string> includes);

        Task<IQueryable<TEntity>> GetAll();

        Task<IQueryable<TEntity>> GetAll(IList<string> includes);

        Task<IQueryable<TEntity>> GetPaginated(int page, int pageSize);

        PaginationVM<MT> GetPaginated<MT>(int page, int pageSize, Expression<Func<TEntity, bool>> where = null, IList<string> includes = null, Expression<Func<TEntity, object>> orderBy = null, TypeOrderBy tipoOrderBy = TypeOrderBy.Ascending, Expression<Func<TEntity, object>> thenBy = null) where MT : class;

        PaginationVM<MT> GetPaginated<MT>(int page, int pageSize, IList<MT> data = null, bool orderByUser = false) where MT : class;

        bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity;
    }
}
