using AutoMapper;
using MedicationAssistant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ServiceLayer.DTOs
{
    public class PrescriptionDateCount
    {
        public int PrescriptionId { get; private set; }

        [DisplayFormat(DataFormatString = "{dd:MM:yy}")]
        public DateTime CollectedOn { get; private set; }

        public int NumberOfMedications { get; private set; }

        public static IReadOnlyCollection<PrescriptionDateCount> FromPrescriptions(IEnumerable<Prescription> prescriptions, IMapper mapper) =>
           mapper.Map<IReadOnlyCollection<PrescriptionDateCount>>(prescriptions);
    }
}
