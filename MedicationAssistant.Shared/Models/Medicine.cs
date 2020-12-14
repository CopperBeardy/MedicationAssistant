using MedicationAssistant.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Shared.Models
{

    /// <summary>
    /// this is the class for connecting
    /// all brand with a single medicaitons
    /// </summary>
    public class Medicine 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Dosage { get; set; } = 0;

        [Required]
        public DosageUnit DosageUnit { get; set; } = DosageUnit.g;

        [Required]
        [StringLength(500, ErrorMessage = "The Description of the medication needs to be between 25 - 500 characters", MinimumLength = 5)]
        public string Description { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; } = string.Empty;

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
