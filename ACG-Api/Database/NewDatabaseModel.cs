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
        public required DbSet<Counterparty> Counterparty { get; set; }
        public required DbSet<Group> Groups { get; set; }

        public NewDatabaseModel(DbContextOptions<NewDatabaseModel> options) : base(options)
        {

        }
        public NewDatabaseModel() { }

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
}
