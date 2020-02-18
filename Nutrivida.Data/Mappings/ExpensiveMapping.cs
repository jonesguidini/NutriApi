using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Mappings
{
    public class ExpensiveMapping : IEntityTypeConfiguration<Expensive>
    {
        public void Configure(EntityTypeBuilder<Expensive> builder)
        {
            builder.ToTable("Expensives");

            builder.HasKey(x => x.Id)
                .HasName("ExpensivePK");
            
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

            builder.Property(x => x.ExpensiveCategoryId)
               .IsRequired(true)
               .HasColumnType("int")
               .HasColumnName("ExpensiveCategoryId");

            builder.Property(x => x.FinancialRecordId)
               .IsRequired(true)
               .HasColumnType("int")
               .HasColumnName("FinancialRecordId");

            builder
                .HasOne(x => x.ExpensiveCategory)
                .WithMany(y => y.Expensives)
                .HasForeignKey(x => x.ExpensiveCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Expensive.Possui.Categoria");

            builder
                .HasOne(x => x.FinancialRecord)
                .WithMany(y => y.Expensives)
                .HasForeignKey(x => x.FinancialRecordId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Expensive.Possui.FinancialRecord");

            builder
                .HasOne(x => x.DeletedByUser)
                .WithMany(y => y.Expensive)
                .HasForeignKey(x => x.DeletedByUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Expensive.Possui.UserDeleted");
        }
    }
}
