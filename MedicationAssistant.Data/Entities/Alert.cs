using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicationAssistant.Data.Entities
{
    public class Alert : EntityBase
    {
        public virtual User User { get; set; }

        public DateTime Time { get; set; }

        public virtual Prescription Prescription { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Medication")]
        public int MedicaitonId { get; set; }
    }
}