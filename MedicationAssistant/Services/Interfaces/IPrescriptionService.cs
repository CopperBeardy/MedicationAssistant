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
        Task<IEnumerable<Prescription>> GetPrescriptions( string userId);
        Task<IEnumerable<Prescription>> GetRequiredAmountFullPrescriptions( string userId, int count);
        Task InsertPrescription(Dictionary<string, object> values);
        Task<bool> RemovePrescription( Prescription Prescription);
        Task UpdatePrescription(Prescription Prescription, Dictionary<string, object> newValues);
    }
}