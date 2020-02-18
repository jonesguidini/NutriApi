using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Mappings
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(x => x.Id)
                .HasName("SalePK");

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("Description");

            builder.Property(x => x.Value)
               .IsRequired(true)
               .HasColumnType("decimal(18,2)")
               .HasColumnName("Value");

            builder.Property(x => x.Created)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime2")
                .HasColumnName("Created");

            builder.Property(x => x.SaleCategoryId)
               .IsRequired(true)
               .HasColumnType("int")
               .HasColumnName("SaleCategoryId");

            builder.Property(x => x.FinancialRecordId)
               .IsRequired(true)
               .HasColumnType("int")
               .HasColumnName("FinancialRecordId");

            builder
                .HasOne(x => x.SaleCategory)
                .WithMany(y => y.Sales)
                .HasForeignKey(x => x.SaleCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Sale.Possui.Categoria");

            builder
                .HasOne(x => x.FinancialRecord)
                .WithMany(y => y.Sales)
                .HasForeignKey(x => x.FinancialRecordId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Sale.Possui.FinancialRecord");

            builder
                .HasOne(x => x.DeletedByUser)
                .WithMany(y => y.Sale)
                .HasForeignKey(x => x.DeletedByUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Sale.Possui.UserDeleted");
        }
    }
}
