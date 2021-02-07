using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicationAssistant.Services;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using MedicationAssistant.Data;
using MedicationAssistant.Pages;
using MedicationAssistant.Tests.ServiceTests.Fixtures;

namespace MedicationAssistant.Tests.ServiceTests
{
  
    public class MedicineServiceTests :IClassFixture<MedicineSeedDataFixture>
    {
        MedicineSeedDataFixture fixture;
        public MedicineServiceTests(MedicineSeedDataFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public async void ShouldReturnListOfMedicines()
        {
            
            var dbcontextFactory = new Mock<IDbContextFactory<MedicationAssistantDBContext>>();
            dbcontextFactory.Setup(x => x.CreateDbContext()).Returns(fixture.context); 
        
           Mock<IMedicineService> medicineService = new Mock<IMedicineService>();
           
            //should this be a different context
            var list = fixture.context.Medicines.ToList();
            medicineService.Setup(ms => ms.GetMedicines())
                .ReturnsAsync(list);

            var sut = new MedicineService(dbcontextFactory.Object);

            var result = await sut.GetMedicines();

            Assert.NotEmpty(result);            
            Assert.Equal(2,result.Count());
            Assert.IsAssignableFrom<IEnumerable<Medicine>>(result);
        }

        [Fact]
        public async void ShouldReturnEmptyListOfMedicines()
        {
            var dbcontextFactory = new Mock<IDbContextFactory<MedicationAssistantDBContext>>();
            dbcontextFactory.Setup(x => x.CreateDbContext()).Returns(fixture.context);
            
            foreach (var item in fixture.context.Medicines)
            {
                fixture.context.Remove(item);
            }
            await fixture.context.SaveChangesAsync();

            Mock<IMedicineService> medicineService = new Mock<IMedicineService>();

            //should this be a different context
            
            medicineService.Setup(ms => ms.GetMedicines())
                .ReturnsAsync(new List<Medicine>());

            var sut = new MedicineService(dbcontextFactory.Object);

            var result = await sut.GetMedicines();

            Assert.Empty(result);          
            Assert.IsAssignableFrom<IEnumerable<Medicine>>(result);
        }

        [Fact]
        public async void ShouldReturnRemoveMedicineSuccessWhenPassedExistingMedicineObject()
        {
            this.fixture = new MedicineSeedDataFixture();
            var dbcontextFactory = new Mock<IDbContextFactory<MedicationAssistantDBContext>>();
            dbcontextFactory.Setup(x => x.CreateDbContext()).Returns(fixture.context);


            Mock<IMedicineService> medicineService = new Mock<IMedicineService>();

            //should this be a different context
         
            medicineService.Setup(ms => ms.RemoveMedicine(It.IsAny<Medicine>() )).ReturnsAsync(true);
          
            var sut = new MedicineService(dbcontextFactory.Object);


            var result = await sut.RemoveMedicine(new Medicine() { Id= 1});

            Assert.True(result);
            Assert.IsAssignableFrom<bool>(result);
        }





    }
}
