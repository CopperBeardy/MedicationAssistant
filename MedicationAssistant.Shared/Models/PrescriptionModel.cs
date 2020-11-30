using MedicationAssistant.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Data
{
    public class PrescriptionModel : ModelBase
    {
        public virtual UserModel User { get; set; }

        [Required]
        public int Quantity { get; set; }

        
        [Required]
        public virtual MedicineModel Medicine { get; set; }

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
