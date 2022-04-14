using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TicketsAPI.Data.Contexts
{
    public class DataReadOnlyContext : DbContext
    {
        private readonly IConfiguration _config;
        public DataReadOnlyContext(DbContextOptions<DataReadOnlyContext> options) : base(options)
        {
            _config = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json")
                         .Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("DatabaseConnectionReadOnly");

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new BankAccountConfig());
        }

        // public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
