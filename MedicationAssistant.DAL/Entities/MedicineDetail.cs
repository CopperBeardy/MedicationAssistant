using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.DAL.Entities
{
    public class MedicineDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicineDetailId { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Medical Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string MedicalName { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}
