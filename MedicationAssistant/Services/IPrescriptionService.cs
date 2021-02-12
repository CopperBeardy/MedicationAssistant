using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetPrescriptions(MedicationAssistantDBContext context);
        Task<List<Prescription>> GetRequiredAmountFullPrescriptions(MedicationAssistantDBContext context, string userId);
        Task InsertPrescription(MedicationAssistantDBContext context, Prescription Prescription, Dictionary<string, object> values);
        Task<bool> RemovePrescription(MedicationAssistantDBContext context, Prescription Prescription);
        Task UpdatePrescription(MedicationAssistantDBContext context, Prescription Prescription, Dictionary<string, object> newValues);
    }
}
