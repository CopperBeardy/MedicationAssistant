using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicationAssistant.Data
{
    public class AlertModel : ModelBase 
    {
        public virtual UserModel User { get; set; }

        public DateTime Time { get; set; }

        public virtual PrescriptionModel Prescription { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Medication")]
        public int MedicaitonId { get; set; }
    }
}