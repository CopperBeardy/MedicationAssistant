using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Data.Entities
{
    public class User
    {  // will be provider from the Azure B2c service
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public virtual ICollection<Prescription> Medications { get; set; }

        public virtual ICollection<Alert> Alerts { get; set; }

        public User()
        {
            Medications = new List<Prescription>();
            Alerts = new List<Alert>();
        }
    }
}
