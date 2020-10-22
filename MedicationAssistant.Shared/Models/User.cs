using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Entities
{
    public class User
    {
        public string Id { get; set; }
        public List<Medication> Medicatons { get; set; }
    }
}
