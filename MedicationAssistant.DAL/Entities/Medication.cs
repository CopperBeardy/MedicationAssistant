using MedicationAssistant.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.DAL.Entities
{
    public class Medication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicationId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Dosage { get; set; }

        [Required]
        public DosageUnit DosageUnit { get; set; }

        [Required]
        public double FrequencyUnit { get; set; }

        [Required]
        public Frequency Frequency { get; set; }

        [Required]
        public MedicineDetails MedicineDetails { get; set; }

        [ForeignKey(nameof(MedicineDetails))]
        public int MedicineDetailsId { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }


    }
}