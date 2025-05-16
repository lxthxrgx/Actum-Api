using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ACG_Api.model;

namespace ACG_Api.Database
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
                .HasForeignKey(e => e.Id_Group)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Guard)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.Id_Group)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Sublease)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.Id_Group)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        }

        public class DatabaseModelFactory : IDesignTimeDbContextFactory<DatabaseModel>
        {
            public DatabaseModel CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<DatabaseModel>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseNpgsql(connectionString);

                return new DatabaseModel(optionsBuilder.Options);
            }
        }
}
