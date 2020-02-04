using Microsoft.EntityFrameworkCore;
using Nutrivida.Data.Context;
using Nutrivida.Domain.Contracts.Repositories;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nutrivida.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly SQLContext sqlContext;
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Construtor de contexto do banco de dados
        /// </summary>
        /// <param name="_sqlContext"></param>
        public RepositoryBase(SQLContext _sqlContext)
        {
            sqlContext = _sqlContext;
            DbSet = sqlContext.Set<TEntity>();
        }

        /// <summary>
        /// Método padrão para Adicionar e salvar entidades no BD
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> Add(TEntity obj)
        {
            DbSet.Add(obj);
            await SaveChanges();
            return obj;
        }

        /// <summary>
        /// Método padrão para Atualizar entidade no BD
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> Update(TEntity obj)
        {
            sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await SaveChanges();
            return obj;
        }

        /// <summary>
        /// Método padrão para Remover entidade no BD
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual async Task Remove(TEntity obj)
        {
            DbSet.Remove(GetById(obj.Id).Result.SingleOrDefault());
            await SaveChanges();
        }

        /// <summary>
        /// Método que retorna registro de entidade filtrada por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<IQueryable<TEntity>> GetById(int id)
        {
            return await Task.Run(() => FindAsync(x => x.Id == id, null));
        }

        /// <summary>
        /// Método que retorna registro de entidade com respectivos includes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<IQueryable<TEntity>> GetById(int id, IList<string> includes)
        {
            IQueryable<TEntity> entidades = DbSet;

            foreach (var include in includes)
                entidades = entidades.Include(include);

            return await Task.Run(() => entidades.Where(x => x.Id == id).AsQueryable());
        }

        /// <summary>
        /// Método padrão para retornar todas entidades do BD
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return await FindAsync(x => x.Id != null, null);
        }

        public virtual async Task<IQueryable<TEntity>> GetAll(IList<string> includes)
        {
            IQueryable<TEntity> entidades = DbSet;

            foreach (var include in includes)
                entidades = entidades.Include(include);

            return await Task.Run(() => entidades.AsQueryable());
        }

        /// <summary>
        /// Método para efetuar filtro em registros de entidades
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            var registers = await DbSet.AsNoTracking().Where(predicate).ToListAsync();
            return registers.AsQueryable();
        }

        /// <summary>
        /// Efetua commit para save no banco de dados 
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChanges()
        {
            return await sqlContext.SaveChangesAsync();
        }

        /// <summary>
        /// Método padrão para filtrar registros passando entidade e opcionamente includes (objeto) para consulta
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = DbSet.Where(predicate).AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        /// <summary>
        /// Método padrão que complementa o método Find para trazer de modo Assincrono registros em formato QueryRiable
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Task.Run(() => Find(predicate, includes));
        }
    }
}
