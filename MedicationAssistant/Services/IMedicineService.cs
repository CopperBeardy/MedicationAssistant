using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetMedicines();
        Task InsertMedicine(Medicine medince, Dictionary<string, object> values);
        Task<bool> RemoveMedicine(Medicine medicine);
        Task UpdateMedicine(Medicine medicine, Dictionary<string, object> newValues);
    }
}
