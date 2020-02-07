using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Context
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
