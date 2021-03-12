using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories
{
    public static class PrescriptionModelConvertor
    {
        public static IReadOnlyCollection<PrescriptionDateCount> FromPrescriptions(IEnumerable<Prescription> prescriptions, IMapper mapper) =>
           mapper.Map<IReadOnlyCollection<PrescriptionDateCount>>(prescriptions);

        private static Prescription SetValues(Prescription pre, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        pre.CollectedOn = (DateTime)newValues[item];
                        break;
                    case "Medications":
                        pre.Medications = (List<Medication>)newValues[item];
                        break;
                }
            }
            return pre;
        }

    }
}