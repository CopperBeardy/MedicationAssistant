using System;
using System.Collections.Generic;
using System.Text;

namespace MedicationAssistant.Shared.Models
{
    public class Medicine
    {
        public string  Name{ get; set; }
        public ICollection<MedicineBrandInformation> MedicineBrands { get; set; }   
    }
}
