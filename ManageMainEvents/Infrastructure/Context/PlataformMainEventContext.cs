using System.IO;
using ManageMainEvents.Domain.Model.MainEvents;
using ManageMainEvents.Domain.Model.Owners;
using ManageMainEvents.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManageMainEvents.Infrastructure.Context
{
    public class PlataformMainEventContext: DbContext
    {
        public DbSet<MainEvent> MainEvents { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MainEventMapping());
            modelBuilder.ApplyConfiguration(new OwnerMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
