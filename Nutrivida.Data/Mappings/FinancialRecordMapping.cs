using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Mappings
{
    public class FinancialRecordMapping : IEntityTypeConfiguration<FinancialRecord>
    {
        public void Configure(EntityTypeBuilder<FinancialRecord> builder)
        {
            builder.ToTable("FinancialRecords");

            builder.HasKey(x => x.Id)
                .HasName("FinancialRecordPK");

            builder.Property(x => x.Created)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime2")
                .HasColumnName("Created");

            builder.Property(x => x.SalesObservation)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("SalesObservation");

            builder.Property(x => x.ExpensivesObservation)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("ExpensivesObservation");

            builder.Property(x => x.NumMeals)
                .IsRequired(false)
                .HasColumnType("int")
                .HasColumnName("NumMeals");

            builder.Property(x => x.NumProducts)
                .IsRequired(false)
                .HasColumnType("int")
                .HasColumnName("NumProducts");

            builder.Property(x => x.UserId)
               .IsRequired(true)
               .HasColumnType("int")
               .HasColumnName("UserId");

            builder
                .HasOne(x => x.User)
                .WithMany(y => y.FinancialRecords)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FinancialRecord.Possui.User");


            builder
                .HasMany(x => x.Sales)
                .WithOne(y => y.FinancialRecord)
                .HasForeignKey(y => y.FinancialRecordId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FinancialRecord.Possui.Sales");

            builder
                .HasMany(x => x.Expensives)
                .WithOne(y => y.FinancialRecord)
                .HasForeignKey(y => y.FinancialRecordId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FinancialRecord.Possui.Expensives");
        }
    }
}
