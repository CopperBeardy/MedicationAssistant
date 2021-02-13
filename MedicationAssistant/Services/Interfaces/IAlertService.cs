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
        Task<List<PrescriptionItemAlert>> GetPrescriptionItemAlerts(MedAstDBContext context, string userId);
        Task InsertPrescriptionItemAlert(MedAstDBContext context, PrescriptionItemAlert PrescriptionItemAlert, Dictionary<string, object> values);
        Task<bool> RemovePrescriptionItemAlert(MedAstDBContext context, PrescriptionItemAlert PrescriptionItemAlert);
        Task UpdatePrescriptionItemAlert(MedAstDBContext context, PrescriptionItemAlert PrescriptionItemAlert, Dictionary<string, object> newValues);
    }
}
