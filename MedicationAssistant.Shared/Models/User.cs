
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicationAssistant.Shared.Models
{
    public class User
    {  // will be provider from the Azure B2c service
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public virtual ICollection<PrescriptionItem> Prescriptions { get; set; } = new List<PrescriptionItem>();

        public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

      
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
