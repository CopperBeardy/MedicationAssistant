using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.DTOs
{
    public class PrescriptionDateCount
    {
        public int PrescriptionId { get; private set; }

        [DisplayFormat(DataFormatString = "{dd:MM:yy}")]
        public DateTime CollectedOn { get; private set; }

        public int NumberOfMedications { get; private set; }
    }
}
