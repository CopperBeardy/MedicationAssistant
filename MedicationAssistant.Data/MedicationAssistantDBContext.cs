using MedicationAssistant.Shared.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Data
{
    public class MedicationAssistantDBContext : DbContext
    {
        public MedicationAssistantDBContext(DbContextOptions<MedicationAssistantDBContext> options)
           : base(options)
        {
            Debug.WriteLine($"{ContextId} context created");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionAlert>().Ignore(i => i.Title);
            base.OnModelCreating(modelBuilder);
        }


   
      
        public virtual DbSet<PrescriptionItem> Prescriptions { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PrescriptionAlert> PrescriptionAlerts { get; set; }


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
