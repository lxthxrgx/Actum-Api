using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACG_Class.Model.NewModel;

namespace ACG_Api.Database
{
    public class NewDatabaseModel : DbContext
    {
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Group> Groups { get; set; }

        public NewDatabaseModel(DbContextOptions<NewDatabaseModel> options) : base(options)
        {

        }
        public NewDatabaseModel() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Counterparty>()
                .HasMany(e => e.NumberGroup)
                .WithOne(e => e.D1)
                .HasForeignKey(e => e.Id_D1)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
