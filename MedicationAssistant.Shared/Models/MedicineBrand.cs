using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    public class MedicineBrand
    {
    
       public string Name { get; set; }
       
        public MedicineType MedicineType { get; set; }

        public string Image { get; set; }

    }
}
