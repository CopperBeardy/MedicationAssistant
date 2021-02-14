using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MedicationAssistant.Shared.Models
{
    public class Account
    {  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public IEnumerable<Prescription> Prescriptions { get; set; } 
        public IEnumerable<PrescriptionItemAlert> Alerts { get; set; } 
        
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}