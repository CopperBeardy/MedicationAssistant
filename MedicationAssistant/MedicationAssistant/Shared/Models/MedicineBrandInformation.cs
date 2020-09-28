using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    public class MedicineBrandInformation
    {
        public string Name { get; set; }
        public MedicineType MedicineType { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
