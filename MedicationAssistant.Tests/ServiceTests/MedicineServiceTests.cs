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
  
    public class MedicineServiceTests  : MedicineSeedDataFixture
    {
        
        [Fact]
        public async void ShouldReturnListOfMedicines()
        {
                var result = await new MedicineService().GetMedicines(MakeContext());
                Assert.NotEmpty(result);
                Assert.Equal(2, result.Count());
                Assert.IsAssignableFrom<IEnumerable<Medicine>>(result);
      }


        [Fact]
        public async void ShouldReturnRemoveMedicineSuccessWhenPassedExistingMedicineObject()
        {
             var result = await new MedicineService().RemoveMedicine(MakeContext(), new Medicine() { Id = 1 });
            Assert.True(result);
            Assert.IsAssignableFrom<bool>(result);
        }
    }
}
