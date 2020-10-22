using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Data.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // will be provider from the Azure B2c service
        public string Id { get; set; }
        public List<Medication> Medications { get; set; }
    }
}
