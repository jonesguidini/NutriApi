using AutoMapper;
using FluentValidation;
using Nutrivida.Business.Config;
using Nutrivida.Domain.Contracts.FluentValidation;
using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Contracts.Services;
using Nutrivida.Domain.Entities;
using Nutrivida.Domain.Entities.FluentValidation;
using Nutrivida.Domain.Filters;
using Nutrivida.Domain.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nutrivida.Business.Services
{
    public class ServiceBase<TEntity> : Notifiable, IDisposable, IServiceBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly IRepositoryBase<TEntity> repository;
        protected readonly IMapper mapper;
        protected readonly IFluentValidation<TEntity> fluentValidation;
        protected ValidationBase<TEntity> validationBase;

        public ServiceBase(
            IRepositoryBase<TEntity> _repository,
            INotificationManager _notificationManager,
            IMapper _mapper,
            IFluentValidation<TEntity> _fluentValidation
            ) : base(_notificationManager)
        {
            repository = _repository;
            mapper = _mapper;
            fluentValidation = _fluentValidation;

            // configure Validation Base
            validationBase = new ValidationBase<TEntity>();
            validationBase.SetValidation(fluentValidation.GetValidations());
        }

        public virtual async Task<TEntity> CheckIfEntityExists(TEntity obj)
        {
            if (obj == null)
            {
                await Notify("Objeto: " + typeof(TEntity).Name, "O Objeto informado não existe.");
                return null;
            }

            return obj;
        }

        public virtual async Task Delete(int id)
        {
            TEntity entity = await GetById(id);

            if (entity != null)
                await repository.Remove(entity);
            else
                await Notify(entity.GetType().Name, "O Objeto informado não existe.");
        }

        public virtual bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            _ = Notify(validator);

            return false;
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await CheckIfEntityExists(obj);

            if (!Validate(new ValidationBase<TEntity>(), obj)) return null;

            return await repository.Add(obj);
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            await CheckIfEntityExists(obj);

            if (!Validate(new ValidationBase<TEntity>(), obj)) return null;

            return await repository.Update(obj);
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            if (id == 0)
            {
                await Notify("ID", "Favor informar um ID válido.");
                return null;
            }

            TEntity entity = await repository.GetById(id);

            await CheckIfEntityExists(entity);

            return entity;
        }

        public virtual async Task<TEntity> GetById(int id, IList<string> includes)
        {
            if (id == 0)
            {
                await Notify("Id", "Favor informar um ID válido.");
                return null;
            }

            TEntity entity = await repository.GetById(id);

            await CheckIfEntityExists(entity);

            return entity;
        }

        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public virtual async Task<IQueryable<TEntity>> GetAll(IList<string> includes)
        {
            return await repository.GetAll(includes);
        }


        public virtual async Task<IQueryable<TEntity>> GetPaginated(int page, int pageSize)
        {
            if (page < 1)
                return await Task.Run(() => Enumerable.Empty<TEntity>().AsQueryable());

            return await Task.Run(() => GetAll().Result.Skip((page - 1) * pageSize).Take(pageSize));
        }

        public virtual PaginationVM<MT> GetPaginated<MT>(int page, int pageSize, Expression<Func<TEntity, bool>> where = null, IList<string> includes = null, Expression<Func<TEntity, object>> orderBy = null, TypeOrderBy tipoOrderBy = TypeOrderBy.Ascending, Expression<Func<TEntity, object>> thenBy = null) where MT : class
        {
            if (page < 1)
                return PaginationVM<MT>.Empty();

            IQueryable<TEntity> result = GetAll(includes).Result;

            if (where != null)
                result = result.Where(where);

            if (orderBy != null)
            {
                if (tipoOrderBy == TypeOrderBy.Ascending)
                {
                    if (thenBy != null)
                        result = result.OrderBy(orderBy).ThenBy(thenBy);
                    else
                        result = result.OrderBy(orderBy);
                }
                else
                {
                    if (thenBy != null)
                        result = result.OrderByDescending(orderBy).ThenByDescending(thenBy);
                    else
                        result = result.OrderByDescending(orderBy);
                }
            }

            int totalPages = (int)Math.Ceiling((decimal)result.Count() / pageSize);
            int totalRecords = result.Count();
            result = result.Skip((page - 1) * pageSize).Take(pageSize);

            List<MT> ListaMt = orderBy != null ? result.Select(mapper.Map<TEntity, MT>).ToList() : result.Select(mapper.Map<TEntity, MT>).OrderByDescending(x => x.GetType().GetProperty("Id").GetValue(x)).ToList();

            return new PaginationVM<MT> { Data = ListaMt, TotalPages = totalPages, TotalData = totalRecords };
        }

        public virtual PaginationVM<MT> GetPaginated<MT>(int page, int pageSize, IList<MT> data = null, bool orderByUser = false) where MT : class
        {
            if (page < 1)
                return PaginationVM<MT>.Empty();

            IQueryable<MT> result = data.AsQueryable();

            int totalPages = (int)Math.Ceiling((decimal)result.Count() / pageSize);
            int totalRecords = result.Count();

            if (orderByUser)
                result = result.Skip((page - 1) * pageSize).Take(pageSize);
            else
                result = result.OrderByDescending(x => x.GetType().GetProperty("Id").GetValue(x)).Skip((page - 1) * pageSize).Take(pageSize);

            return new PaginationVM<MT> { Data = result.ToList(), TotalPages = totalPages, TotalData = totalRecords };
        }


        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
