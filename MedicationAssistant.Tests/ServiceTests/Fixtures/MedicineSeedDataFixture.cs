using MedicationAssistant.Data;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.Tests.ServiceTests.Fixtures
{
    public class MedicineSeedDataFixture : IDisposable
    {
        public MedicationAssistantDBContext context { get; private set; } 
        public MedicineSeedDataFixture()
        {

            var options = new DbContextOptionsBuilder<MedicationAssistantDBContext>()
                     .UseInMemoryDatabase(databaseName: "MockDB")
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                     .Options;

            context = new MedicationAssistantDBContext(options);

            context.Medicines.Add( new Medicine()
            {
                Name = "Sample Med",
                Description = "Sample of a medicine",
                Dosage = 20,
                DosageUnit = DosageUnit.g,
                UseDirections = "use as sampled"
            });

            context.Medicines.Add(new Medicine()
            {
                Name = "Sample Med Number 2",
                Description = "Sample of a medicine Number 2",
                Dosage = 5,
                DosageUnit = DosageUnit.mg,
                UseDirections = "use as sample instructs"
            });

            context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
            
        }
    }
}
