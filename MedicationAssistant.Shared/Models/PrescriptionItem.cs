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

        public int Quantity { get; set; } 
      
        [Required]
        public virtual Medicine Medicine { get; set; } 

        [Required]
        public double FrequencyUnit { get; set; } 
        [Required]
        public Frequency Frequency { get; set; } 
        
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; } 

        [Timestamp]
        public byte[] TimeStamp { get; set; }

       
    }
}
