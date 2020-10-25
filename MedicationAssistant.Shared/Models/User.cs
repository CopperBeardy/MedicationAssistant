using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // will be provider from the Azure B2c service
        public string Id { get; set; }
        public ICollection<MedicationUse> Medications { get; set; }
        public ICollection<Alert> Alerts { get; set; }
    }
}
