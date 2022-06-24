using AzureFunctionChartCalc.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionChartCalc
{
    public class SqlContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Shouldn't be here of course
                string connString = "Server=s6rymclone-auth-mysql.mysql.database.azure.com;Database=albumservice;Uid=syweermysql;Pwd=Test123!;";
                optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
