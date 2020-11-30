
using System.ComponentModel.DataAnnotations;
using MedicationAssistant.Shared.Enums;

namespace MedicationAssistant.Data.Entities
{

    /// <summary>
    /// this is the class for connecting
    /// all brand with a single medicaitons
    /// </summary>
    public class Medicine : EntityBase
    {

        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public int Dosage { get; set; }

        [Required]
        public DosageUnit DosageUnit { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The Description of the medication needs to be between 25 - 500 characters", MinimumLength = 5)]
        public string Description { get; set; }

        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; }


    }
}
