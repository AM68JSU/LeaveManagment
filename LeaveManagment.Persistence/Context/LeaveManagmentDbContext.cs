using LeaveManagment.Domain;
using LeaveManagment.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagment.Persistence.Context
{
    public class LeaveManagmentIdentityDbContextFactory : IDesignTimeDbContextFactory<LeaveManagmentDbContext>
    {
        public LeaveManagmentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeaveManagmentDbContext>();
            optionsBuilder.UseSqlServer("Password=123asd/;Persist Security Info=True;User ID=sa;Initial Catalog=LeaveManagment_db;Data Source=.");

            return new LeaveManagmentDbContext(optionsBuilder.Options);
        }
    }
    public class LeaveManagmentDbContext:DbContext
    {

        public LeaveManagmentDbContext(DbContextOptions<LeaveManagmentDbContext> options):base(options) 
        {
                
        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagmentDbContext).Assembly);

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifiedDate=DateTime.Now;
                if (entry.State==EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

            }
            return base.SaveChanges();
        }
    }
}
