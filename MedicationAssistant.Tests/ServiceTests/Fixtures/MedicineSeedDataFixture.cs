using Microsoft.EntityFrameworkCore;
using System;

namespace MedicationAssistant.Tests.ServiceTests.Fixtures
{
    public class MedicineSeedDataFixture : IDisposable
    {
        public MedAstDBContext context { get; private set; }
        public DbContextOptions<MedAstDBContext> contextOptions { get; set; }
        public MedAstDBContext MakeContext()
        {
            return new MedAstDBContext(contextOptions);
        }

        public MedicineSeedDataFixture()
        {

            contextOptions = new DbContextOptionsBuilder<MedAstDBContext>()
                     .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

            context = new MedAstDBContext(contextOptions);

            //context.Medicines.Add( new Medicine()
            //{
            //    Name = "Sample Med",
            //    Description = "Sample of a medicine",
            //    Dosage = 20,
            //    DosageUnit = DosageUnit.g,
            //    UseDirections = "use as sampled"
            //});

            //context.Medicines.Add(new Medicine()
            //{
            //    Name = "Sample Med Number 2",
            //    Description = "Sample of a medicine Number 2",
            //    Dosage = 5,
            //    DosageUnit = DosageUnit.mg,
            //    UseDirections = "use as sample instructs"
            //});

            context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

    }
}
