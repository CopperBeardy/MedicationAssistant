using MedicationAssistant.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ServiceLayer.Models
{
    public class MedicationDashboardModel
    {

        public int MedicationModelId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Dosage { get; set; } = 0;

        [Required]
        public DosageUnit DosageUnit { get; set; }

        [Required]
        public double FrequencyUnit { get; set; }

        [Required]
        public Frequency Frequency { get; set; }

        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }


    }
}