using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.VMs
{
    public class PaginationVM<TEntity> where TEntity : BaseEntity
    {
        public IList<TEntity> PaginationResult { get; set; }
        public int TotalPages { get; set; }
        public int TotalData { get; set; }

        public static PaginationVM<TEntity> Empty() => new PaginationVM<TEntity> { PaginationResult = Enumerable.Empty<TEntity>().ToList(), TotalPages = 0 };
    }
}
