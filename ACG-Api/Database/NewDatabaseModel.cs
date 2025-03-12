using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ACG_Class.Model.NewModel;

namespace ACG_Api.Database
{
    public class NewDatabaseModel : DbContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Sublease> Sublease { get; set; }
        public DbSet<Guard> Guard { get; set; }

        public NewDatabaseModel(DbContextOptions<NewDatabaseModel> options) : base(options)
        {
        }
        public NewDatabaseModel() : base()
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

        public class NewDatabaseModelFactory : IDesignTimeDbContextFactory<NewDatabaseModel>
        {
            public NewDatabaseModel CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<NewDatabaseModel>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseNpgsql(connectionString);

                return new NewDatabaseModel(optionsBuilder.Options);
            }
        }
}
