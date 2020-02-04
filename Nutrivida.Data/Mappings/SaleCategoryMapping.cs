using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrivida.Domain.Entities;


namespace Nutrivida.Data.Mappings
{
    public class SaleCategoryMapping : IEntityTypeConfiguration<SaleCategory>
    {
        public void Configure(EntityTypeBuilder<SaleCategory> builder)
        {
            builder.ToTable("SaleCategories");

            builder.HasKey(x => x.Id)
                .HasName("SaleCategoryPK");

            builder.Property(x => x.Category)
                .IsRequired(true)
                .HasColumnType("varchar(100)")
                .HasColumnName("Category");

            builder.Property(x => x.Created)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime2")
                .HasColumnName("Created");

            builder
                .HasMany(x => x.Sales)
                .WithOne(y => y.SaleCategory)
                .HasForeignKey(x => x.SaleCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("SaleCategory.Possui.Expensives");
        }
    }
}
