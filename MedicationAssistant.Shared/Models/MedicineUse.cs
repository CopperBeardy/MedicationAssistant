using MedicationAssistant.Shared.Entities;
using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    public class MedicineUse
    {
       
        public User  User{ get; set; }
      
        public int Quantity { get; set; }

        
        public int Dosage { get; set; }
        
  
        public DosageUnit  DosageUnit { get; set; }

       public string UseDirections { get; set; }

       
    }
}
