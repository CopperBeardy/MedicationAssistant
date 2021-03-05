using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.DTOs
{
    public class AlertTimeCount
    {

        public  int AlertId { get; private set; }

        [DisplayFormat( DataFormatString = "{hh:mm}")]
        public   DateTime Time { get; private set; }

        public int NumberOfMedications { get; private set; }

    }
}
