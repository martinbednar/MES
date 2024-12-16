using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<AutoScrewingProcessData> AutoScrewingProcessData { get; set; }
        public DbSet<ConductivityProcessData> ConductivityProcessData { get; set; }
        public DbSet<FitAndFunctionMeasurement> FitAndFunctionMeasurements { get; set; }
        public DbSet<FitAndFunctionProcessData> FitAndFunctionProcessData { get; set; }
        public DbSet<ManualScrewingProcessData> ManualScrewingProcessData { get; set; }
        public DbSet<NgAutoScrewingProcessData> NgAutoScrewingProcessData { get; set; }
        public DbSet<PressingProcessData> PressingProcessData { get; set; }
        public DbSet<PressingReworkProcessData> PressingReworkProcessData { get; set; }
        public DbSet<ScanProcessData> ScanProcessData { get; set; }
        public DbSet<PartAllProcessData> PartAllProcessData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Insert connection string here.");
        }
    }
}
