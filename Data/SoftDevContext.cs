using System.Data.Entity;
using Data.Models;
using Data.Models.Mapping;
using Data.Migrations;

namespace Data
{
    public partial class SoftDevContext : DbContext
    {
        static SoftDevContext()
        {
            //Database.SetInitializer<SoftDevContext>(null);
            Database.SetInitializer<SoftDevContext>(new MigrateDatabaseToLatestVersion<SoftDevContext, Configuration>());
        }

        public SoftDevContext()
            : base("SoftDevContext")
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<sysdiagram> Sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DeveloperMap());
            modelBuilder.Configurations.Add(new SoftwareMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
