using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.RegularExpressions;
using Models.model;


namespace Actum_Api.Database
{
    public class DatabaseModel : DbContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Groups> Groups { get; set; }
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
            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Counterparty)
                .WithOne(e => e.GroupTable)
                .HasForeignKey(e => e.GroupId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Guard)
                .WithOne(e => e.GroupTable)
                .HasForeignKey(e => e.GroupId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Sublease)
                .WithOne(e => e.GroupTable)
                .HasForeignKey(e => e.GroupId)
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
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseModel>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new DatabaseModel(optionsBuilder.Options);
        }
    }
}
