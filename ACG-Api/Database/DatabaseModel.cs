using Microsoft.EntityFrameworkCore;
using Models.model.counterparty;
using Models.model.groups;
using Models.model.sublease;
using Models.model.guard;

namespace Actum_Api.Database
{
    public class DatabaseModel : DbContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Sublease> Sublease { get; set; }
        public DbSet<Guard> Guard { get; set; }

        public DatabaseModel(DbContextOptions<DatabaseModel> options) : base(options)
        {
        }
        public DatabaseModel() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(e => e.Counterparty)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.GroupId)
                .IsRequired().OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Guard)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.GroupId)
                .IsRequired().OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Sublease)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.GroupId)
                .IsRequired().OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
