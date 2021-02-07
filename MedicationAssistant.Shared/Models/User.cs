
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicationAssistant.Shared.Models
{
    public class User
    {  // will be provider from the Azure B2c service
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();

        public List<PrescriptionItemAlert> Alerts { get; set; } = new List<PrescriptionItemAlert>();

           
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
