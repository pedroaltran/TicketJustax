using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TicketsAPI.Data.Configs;
using TicketsAPI.Domain.Entities;

namespace TicketsAPI.Data.Contexts
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            _config = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json")
                         .Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("DatabaseConnection");

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketConfig());
            modelBuilder.ApplyConfiguration(new TicketDoubtConfig());
            modelBuilder.ApplyConfiguration(new TicketInteractionConfig());
            modelBuilder.ApplyConfiguration(new TicketStageConfig());
            modelBuilder.ApplyConfiguration(new TicketTypeConfig());
        }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketDoubtEntity> TicketDoubts { get; set; }
        public DbSet<TicketInteractionEntity> TicketInteractions { get; set; }
        public DbSet<TicketStageEntity> TicketStages { get; set; }
        public DbSet<TicketTypeEntity> TicketTypes { get; set; }

    }
}
