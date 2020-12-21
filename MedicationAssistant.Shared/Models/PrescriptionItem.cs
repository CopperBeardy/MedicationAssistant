using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Shared.Models
{
    public class PrescriptionItem 
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Quantity { get; set; } = 0;
      
        [Required]
        public virtual Medicine Medicine { get; set; } = new Medicine();

        [Required]
        public double FrequencyUnit { get; set; } = 0;
        [Required]
        public Frequency Frequency { get; set; } = Frequency.Hourly;
        
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; } = 0;

        [Timestamp]
        public byte[] TimeStamp { get; set; }

       
    }
}
