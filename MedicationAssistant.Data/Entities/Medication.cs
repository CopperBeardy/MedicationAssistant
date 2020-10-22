using MedicationAssistant.Data.Models;
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
        public int Id { get; set; }

        [Required]
        public Medicine Medicine { get; set; }

        [Required]
        public MedicineBrand MedicineBrand { get; set; }

        [Required]
        public MedicineUse MedicineUse { get; set; }



        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        [ForeignKey("MedicineBrand")]
        public int MedicineBrandId { get; set; }

        [ForeignKey("MedicineUse")]
        public int MedicineUseId { get; set; }
    }
}
