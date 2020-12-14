using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicationAssistant.Data;

namespace MedicationAssistant.Shared.Models
{
    public class Alert 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual User User { get; set; } = new User();

        public DateTime Time { get; set; } = DateTime.Now;

        public virtual Prescription Prescription { get; set; }= new Prescription();

        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; } = 0;
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        
    }
}