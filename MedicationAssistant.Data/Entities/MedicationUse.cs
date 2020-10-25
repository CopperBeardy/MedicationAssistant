using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.Data.Entities
{
    public class MedicationUse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Medicine Medicine { get; set; }

        [ForeignKey("Medicine")]
        public Guid MedicineId { get; set; }
    }
}
