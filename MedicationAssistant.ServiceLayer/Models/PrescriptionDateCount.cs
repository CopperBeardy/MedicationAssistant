using AutoMapper;
using MedicationAssistant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ServiceLayer.Models
{
    public class PrescriptionDateCount
    {
        public DateTime CollectedOn { get; private set; }
        public int NumberOfMedications { get; private set; }
    }
}
