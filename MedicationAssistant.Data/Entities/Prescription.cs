using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicationAssistant.Shared.Enums;

namespace MedicationAssistant.Data.Entities
{
    public class Prescription : EntityBase
    {
        public virtual User User { get; set; }

        [Required]
        public int Quantity { get; set; }

        
        [Required]
        public virtual Medicine Medicine { get; set; }

        [Required]
        public double FrequencyUnit { get; set; }
        [Required]
        public Frequency Frequency { get; set; }


        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
