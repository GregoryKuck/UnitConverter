using Microsoft.EntityFrameworkCore;
using UnitConverters.Data.Models;


namespace UnitConverters.Data
{
    public class UnitConversionContext : DbContext
    {
        public UnitConversionContext(DbContextOptions<UnitConversionContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitConversionFormulae>().ToTable("UnitConversionFormulae");
        }

        public DbSet<UnitConversionFormulae> UnitConversionFormulae { get; set; }
    }
}
