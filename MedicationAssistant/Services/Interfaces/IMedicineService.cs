using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetMedicines(MedAstDBContext dbContext);
        Task InsertMedicine(MedAstDBContext dbContext, Medicine medince, Dictionary<string, object> values);
        Task<bool> RemoveMedicine(MedAstDBContext dbContext, Medicine medicine);
        Task UpdateMedicine(MedAstDBContext dbContext,Medicine medicine, Dictionary<string, object> newValues);
    }
}
