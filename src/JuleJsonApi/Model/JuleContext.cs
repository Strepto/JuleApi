using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuleJsonApi.Model
{
    public class JuleContext : DbContext
    {


        public JuleContext(DbContextOptions<JuleContext> options): base(options)
        {
        }

        public JuleContext()
        {
        }

        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<Drikke> Drikker { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RatingMap(modelBuilder.Entity<Rating>());
            new DrikkeMap(modelBuilder.Entity<Drikke>());
            new BrukerMap(modelBuilder.Entity<Bruker>());
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                }

                ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow;
            }
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }

}
