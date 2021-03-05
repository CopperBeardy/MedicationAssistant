using MedicationAssistant.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MedicationAssistant.DAL
{
    public class MedAstDBContext : DbContext
    {
        public MedAstDBContext(DbContextOptions<MedAstDBContext> options) :base(options)
        {
           
            Debug.WriteLine($"{ContextId} context created");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicineDetail> MedicineDetails { get; set; }
        public DbSet<Alert> Alerts { get; set; }


        public override void Dispose()
        {
            Debug.WriteLine($"{ContextId} context disposed.");
            base.Dispose();
        }
        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{ContextId} context disposed async.");
            return base.DisposeAsync();
        }

    }
}
