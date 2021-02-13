using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Shared.Models
{
    public class PrescriptionItemAlert : IAlert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title  => $"Prescription to be take at - {Time.ToShortDateString()} ";

        public User User { get; set; }
     
        public DateTime StartFrom { get; set; } = new DateTime();

         public DateTime Time { get; set; } = new DateTime();
 
        public List<PrescriptionItem> PrescriptionItems { get; set; } 

        [Timestamp]
        public byte[] TimeStamp { get; set; } 

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}