using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Data.Mappings
{
    public class ExpensiveCategoryMapping : IEntityTypeConfiguration<ExpensiveCategory>
    {
        public void Configure(EntityTypeBuilder<ExpensiveCategory> builder)
        {
            builder.ToTable("ExpensiveCategories");

            builder.HasKey(x => x.Id)
                .HasName("ExpensiveCategoryPK");

            builder.Property(x => x.Category)
                .IsRequired(true)
                .HasColumnType("varchar(100)")
                .HasColumnName("Category");

            builder.Property(x => x.Created)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime2")
                .HasColumnName("Created");

            builder
                .HasMany(x => x.Expensives)
                .WithOne(y => y.ExpensiveCategory)
                .HasForeignKey(x => x.ExpensiveCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("ExpensiveCategory.Possui.Expensives");

            builder
                .HasOne(x => x.DeletedByUser)
                .WithMany(y => y.ExpensiveCategories)
                .HasForeignKey(x => x.DeletedByUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("ExpensiveCategory.Possui.UserDeleted");

            //builder
            //    .HasMany(x => x.HistoricalRegisters)
            //    .WithMany(y => y.ExpensiveCategories)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("StudentCourse");
            //    });
        }
    }
}
