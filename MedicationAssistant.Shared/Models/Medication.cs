
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    public class Medication
    {
    
        public Guid Id { get; set; }     
        public Medicine Medicine { get; set; }      
         public MedicationUse MedicationUse { get; set; }
        public Guid MedicineId { get; set; }    
        public Guid MedicineUseId { get; set; }
    }
}
