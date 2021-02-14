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
        Task<IEnumerable<Medicine>> GetMedicines();
        Task InsertMedicine(Dictionary<string, object> values);
        Task<bool> RemoveMedicine(Medicine medicine);
        Task UpdateMedicine(Medicine medicine, Dictionary<string, object> newValues);
    }
}
