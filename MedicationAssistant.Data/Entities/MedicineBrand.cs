using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Data.Models
{
    public class MedicineBrand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public MedicineType MedicineType { get; set; }

        public string Image { get; set; }


      
    }
}
