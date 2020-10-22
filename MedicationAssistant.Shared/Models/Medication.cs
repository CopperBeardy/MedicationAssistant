using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Entities
{
    public class Medication
    {
     
        public int Id { get; set; }     
        public Medicine Medicine { get; set; }      
        public MedicineBrand MedicineBrand { get; set; }      
        public MedicineUse MedicineUse { get; set; }
        public int MedicineId { get; set; }      
        public int MedicineBrandId { get; set; }
        public int MedicineUseId { get; set; }
    }
}
