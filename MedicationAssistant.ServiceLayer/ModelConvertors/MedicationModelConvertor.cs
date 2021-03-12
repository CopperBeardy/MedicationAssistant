using AutoMapper;
using MedicationAssistant.Common.Enums;
using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationAssistant.ServiceLayer.Repositories
{
    public static class MedicationModelConvertor
    {
        public static MedicationFullDetail FromMedication(Medication medicaton, IMapper mapper)
           => mapper.Map<MedicationFullDetail>(medicaton);
        public static Medication FromMedicationFullDetail(MedicationFullDetail mfd, Dictionary<string, object> values, IMapper mapper) =>
            SetValues(mapper.Map<Medication>(mfd), values);

        public static List<MedicationFullDetail> ListFromMedication(IEnumerable<Medication> meds, IMapper mapper)
            => mapper.Map<List<MedicationFullDetail>>(meds);
       



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