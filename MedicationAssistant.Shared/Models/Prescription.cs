using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.Shared.Models
{
    public class Prescription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public User User { get; set; }
        public DateTime CollectedOn { get; set; } = DateTime.Now;
        public List<PrescriptionItem> PrescriptionItems { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } 
    }
}
