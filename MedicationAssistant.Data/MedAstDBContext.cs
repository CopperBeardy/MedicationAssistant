using MedicationAssistant.Shared.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Data
{
    public class MedAstDBContext : DbContext
    {
        public MedAstDBContext(DbContextOptions<MedAstDBContext> options)
           : base(options)
        {
            Debug.WriteLine($"{ContextId} context created");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PrescriptionItemAlert> PrescriptionAlerts { get; set; }

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
