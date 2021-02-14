using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services.Interfaces
{
    public interface IAlertService
    {
        Task<IEnumerable<PrescriptionItemAlert>> GetPrescriptionItemAlerts(string userId);
        Task InsertPrescriptionItemAlert(Dictionary<string, object> values);
        Task<bool> RemovePrescriptionItemAlert(PrescriptionItemAlert PrescriptionItemAlert);
        Task UpdatePrescriptionItemAlert(PrescriptionItemAlert PrescriptionItemAlert, Dictionary<string, object> newValues);
    }
}
