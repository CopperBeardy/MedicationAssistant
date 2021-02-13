using MedicationAssistant.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Shared.Models
{
    public class Medicine 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public int Dosage { get; set; } = 0;

        [Required]
        public DosageUnit DosageUnit { get; set; } 

        [Required]
        [StringLength(500, ErrorMessage = "The Description of the medication needs to be between 25 - 500 characters", MinimumLength = 5)]
        public string Description { get; set; } 

        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; } 

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}