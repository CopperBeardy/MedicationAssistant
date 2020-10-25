using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Data.Entities
{
    public class Alert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public User User { get; set; }

        public DateTime Time { get; set; }

        public MedicationUse Medication { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [ForeignKey("Medication")]
        public Guid MedicaitonId { get; set; }
    }
}