
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Data.Entities
{
    public class Medication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }     
        public Medicine Medicine { get; set; }      
          
        public MedicationUse MedicationUse { get; set; }

        [ForeignKey("Medicine")]
        public Guid MedicineId { get; set; }      
    
        [ForeignKey("MedicineUse")]
        public Guid MedicineUseId { get; set; }
    }
}
