using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
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

            builder.Property(x => x.Id)
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

            builder.HasKey(x => x.Id)
                .HasName("ExpensivePK");

            builder.Property(x => x.Created)
                .ValueGeneratedOnAdd()
                .HasColumnType("datetime2")
                .HasColumnName("Created");

            builder.Property(x => x.DateDeleted)
                .IsRequired(false)
                .HasColumnType("datetime2")
                .HasColumnName("DateDeleted");

            builder.Property(x => x.DeletedByUserId)
                //.IsRequired(false)
                //.HasColumnType("guid")
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("DeletedByUserId");




            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("Description");

            builder.Property(x => x.ExpensiveCategoryId)
               .IsRequired(true)
               .HasColumnType("guid")
               .HasColumnName("ExpensiveCategoryId");

            builder.Property(x => x.FinancialRecordId)
               .IsRequired(true)
               .HasColumnType("guid")
               .HasColumnName("FinancialRecordId");

            builder.Property(x => x.Value)
               .IsRequired(true)
               .HasColumnType("decimal(18,2)")
               .HasColumnName("Value");

            builder
                .HasOne(x => x.ExpensiveCategory)
                .WithMany(y => y.Expensives)
                .HasForeignKey(x => x.ExpensiveCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("ExpensiveCategory.Possui.Categoria");

            builder
                .HasOne(x => x.FinancialRecord)
                .WithMany(y => y.Expensives)
                .HasForeignKey(x => x.FinancialRecordId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("ExpensiveCategory.Possui.FinancialRecord");
        }
    }
}
