using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MedicationAssistant.Shared.Models
{
    public class PrescriptionItemAlert : IAlert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title  => $"Prescription to be take at - {Time.ToShortDateString()} ";

        public Account Account { get; set; }
     
        public DateTime StartFrom { get; set; } = new DateTime();

         public DateTime Time { get; set; } = new DateTime();
 
        public IEnumerable<PrescriptionItem> PrescriptionItems { get; set; } 

        [Timestamp]
        public byte[] TimeStamp { get; set; } 

        [ForeignKey("Account")]
        public string AccountId { get; set; }
    }
}