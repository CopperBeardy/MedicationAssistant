using MedicationAssistant.Data.Entities;
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


        public virtual DbSet<Alert> Alerts { get; set; }
      
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Entities.User> Users { get; set; }


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
