using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetPrescriptions(MedAstDBContext context, string userId);
        Task<List<Prescription>> GetRequiredAmountFullPrescriptions(MedAstDBContext context, string userId, int count);
        Task InsertPrescription(MedAstDBContext context, Prescription Prescription, Dictionary<string, object> values);
        Task<bool> RemovePrescription(MedAstDBContext context, Prescription Prescription);
        Task UpdatePrescription(MedAstDBContext context, Prescription Prescription, Dictionary<string, object> newValues);
    }
}