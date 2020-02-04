using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nutrivida.Data.Context
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
