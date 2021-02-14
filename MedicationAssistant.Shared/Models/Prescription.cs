using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MedicationAssistant.Shared.Models
{
    public class Prescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Account Account { get; set; }
        public DateTime CollectedOn { get; set; } = DateTime.Now;
        public IEnumerable<PrescriptionItem> PrescriptionItems { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; } 
    }
}