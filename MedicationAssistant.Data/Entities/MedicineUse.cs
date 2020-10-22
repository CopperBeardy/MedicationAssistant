using MedicationAssistant.Data.Entities;
using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Data.Models
{
    public class MedicineUse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User  User{ get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Dosage { get; set; }
        
        [Required]
        public DosageUnit  DosageUnit { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
