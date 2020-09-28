using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    class MedicineUseDescription
    {
        //todo this will be change to a Azure B2C User type
        public string User { get; set; }

        //todo rename - better description for the number of tablets
        public int ToTake { get; set; }
        public int dosage { get; set; }
        public DosageUnit  DosageUnit { get; set; }

        public string UseDirections { get; set; }
    }
}
