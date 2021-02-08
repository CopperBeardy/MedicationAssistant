using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetMedicines(MedicationAssistantDBContext dbContext);
        Task InsertMedicine(MedicationAssistantDBContext dbContext, Medicine medince, Dictionary<string, object> values);
        Task<bool> RemoveMedicine(MedicationAssistantDBContext dbContext, Medicine medicine);
        Task UpdateMedicine(MedicationAssistantDBContext dbContext,Medicine medicine, Dictionary<string, object> newValues);
    }
}
