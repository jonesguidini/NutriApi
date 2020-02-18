﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nutrivida.Data.Context;

namespace Nutrivida.Data.Migrations
{
    [DbContext(typeof(SQLContext))]
    partial class SQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nutrivida.Domain.Entities.Expensive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDelited")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpensiveCategoryId")
                        .HasColumnName("ExpensiveCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FinancialRecordId")
                        .HasColumnName("FinancialRecordId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id")
                        .HasName("ExpensivePK");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("ExpensiveCategoryId");

                    b.HasIndex("FinancialRecordId");

                    b.ToTable("Expensives");
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.ExpensiveCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnName("Category")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDelited")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("ExpensiveCategoryPK");

                    b.HasIndex("DeletedByUserId");

                    b.ToTable("ExpensiveCategories");
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.FinancialRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDelited")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("ExpensivesObservation")
                        .IsRequired()
                        .HasColumnName("ExpensivesObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("NumMeals")
                        .HasColumnName("NumMeals")
                        .HasColumnType("int");

                    b.Property<int?>("NumProducts")
                        .HasColumnName("NumProducts")
                        .HasColumnType("int");

                    b.Property<string>("SalesObservation")
                        .IsRequired()
                        .HasColumnName("SalesObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("FinancialRecordPK");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("UserId");

                    b.ToTable("FinancialRecords");
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDelited")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinancialRecordId")
                        .HasColumnName("FinancialRecordId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SaleCategoryId")
                        .HasColumnName("SaleCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id")
                        .HasName("SalePK");

                    b.HasIndex("DeletedByUserId");

                    b.HasIndex("FinancialRecordId");

                    b.HasIndex("SaleCategoryId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.SaleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnName("Category")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDelited")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("SaleCategoryPK");

                    b.HasIndex("DeletedByUserId");

                    b.ToTable("SaleCategories");
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("Username")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("UserPK");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.Expensive", b =>
                {
                    b.HasOne("Nutrivida.Domain.Entities.User", "DeletedByUser")
                        .WithMany("Expensive")
                        .HasForeignKey("DeletedByUserId")
                        .HasConstraintName("Expensive.Possui.UserDeleted")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Nutrivida.Domain.Entities.ExpensiveCategory", "ExpensiveCategory")
                        .WithMany("Expensives")
                        .HasForeignKey("ExpensiveCategoryId")
                        .HasConstraintName("Expensive.Possui.Categoria")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Nutrivida.Domain.Entities.FinancialRecord", "FinancialRecord")
                        .WithMany("Expensives")
                        .HasForeignKey("FinancialRecordId")
                        .HasConstraintName("FinancialRecord.Possui.Expensives")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.ExpensiveCategory", b =>
                {
                    b.HasOne("Nutrivida.Domain.Entities.User", "DeletedByUser")
                        .WithMany("ExpensiveCategories")
                        .HasForeignKey("DeletedByUserId")
                        .HasConstraintName("ExpensiveCategory.Possui.UserDeleted")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.FinancialRecord", b =>
                {
                    b.HasOne("Nutrivida.Domain.Entities.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedByUserId")
                        .HasConstraintName("FinancialRecord.Possui.UserDeleted")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Nutrivida.Domain.Entities.User", "User")
                        .WithMany("FinancialRecords")
                        .HasForeignKey("UserId")
                        .HasConstraintName("User.Possui.FinancialRecords")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.Sale", b =>
                {
                    b.HasOne("Nutrivida.Domain.Entities.User", "DeletedByUser")
                        .WithMany("Sale")
                        .HasForeignKey("DeletedByUserId")
                        .HasConstraintName("Sale.Possui.UserDeleted")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Nutrivida.Domain.Entities.FinancialRecord", "FinancialRecord")
                        .WithMany("Sales")
                        .HasForeignKey("FinancialRecordId")
                        .HasConstraintName("Sale.Possui.FinancialRecord")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Nutrivida.Domain.Entities.SaleCategory", "SaleCategory")
                        .WithMany("Sales")
                        .HasForeignKey("SaleCategoryId")
                        .HasConstraintName("Sale.Possui.Categoria")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Nutrivida.Domain.Entities.SaleCategory", b =>
                {
                    b.HasOne("Nutrivida.Domain.Entities.User", "DeletedByUser")
                        .WithMany("SaleCategories")
                        .HasForeignKey("DeletedByUserId")
                        .HasConstraintName("SaleCategory.Possui.UserDeleted")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
