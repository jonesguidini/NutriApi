using Microsoft.EntityFrameworkCore;
using Nutrivida.CrossCutting;
using Nutrivida.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Nutrivida.Data.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<SaleCategory> SaleCategories { get; set; }
        public DbSet<ExpensiveCategory> ExpensiveCategories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Expensive> Expensives { get; set; }
        public DbSet<FinancialRecord> FinancialRecords { get; set; }


        /// <summary>
        /// Aplica as configuracoes de mapeamento
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type[] types = typeof(EntityTypeConfiguration<>).GetTypeInfo().Assembly.GetTypes();
            IEnumerable<Type> typesToRegister = types
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                type.GetTypeInfo().BaseType != null &&
                                type.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType &&
                                type.GetTypeInfo().BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                ModelBuilderExtensions.AddConfiguration(modelBuilder, configurationInstance);
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(GetType().Assembly, "Nutrivida.Data.Mappings");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Created").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
