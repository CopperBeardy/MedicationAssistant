using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services
{
    public interface IAlertService
    {
        Task<List<PrescriptionItemAlert>> GetPrescriptionItemAlerts(MedicationAssistantDBContext context, string userId);
        Task InsertPrescriptionItemAlert(MedicationAssistantDBContext context, PrescriptionItemAlert PrescriptionItemAlert, Dictionary<string, object> values);
        Task<bool> RemovePrescriptionItemAlert(MedicationAssistantDBContext context, PrescriptionItemAlert PrescriptionItemAlert);
        Task UpdatePrescriptionItemAlert(MedicationAssistantDBContext context, PrescriptionItemAlert PrescriptionItemAlert, Dictionary<string, object> newValues);
    }
}
