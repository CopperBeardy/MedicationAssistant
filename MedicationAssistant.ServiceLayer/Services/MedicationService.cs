using MedicationAssistant.Common.Enums;
using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationAssistant.ServiceLayer.Repositories
{
    public static class MedicationService
    {
        public static Medication SetValues(Medication med, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "UserId":
                        med.UserId = (string)newValues[item];
                        break;
                    case "Name":
                        med.Name = (string)newValues[item];
                        break;
                    case "Quantity":
                        med.Quantity = (int)newValues[item];
                        break;
                    case "Dosage":
                        med.Dosage = (int)newValues[item];
                        break;
                    case "DosageUnit":
                        med.DosageUnit = (DosageUnit)newValues[item];
                        break;
                    case "Frequency":
                        med.Frequency = (Frequency)newValues[item];
                        break;
                    case "FrequencyUnit":
                        med.FrequencyUnit = (double)newValues[item];
                        break;
                    case "UseDirections":
                        med.UseDirections = (string)newValues[item];
                        break;
                }
            }
            return med;
        }
    }
}