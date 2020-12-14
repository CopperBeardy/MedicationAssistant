
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicationAssistant.Data;

namespace MedicationAssistant.Shared.Models
{
    public class User
    {  // will be provider from the Azure B2c service
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public virtual ICollection<Prescription> Medications { get; set; } = new List<Prescription>();

        public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

      
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
