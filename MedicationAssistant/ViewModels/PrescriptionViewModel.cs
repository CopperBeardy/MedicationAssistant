using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ViewModels
{
    public class PrescriptionViewModel
    {

        public int PrescriptionModelId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd:MM:yy}")]
        public DateTime CollectedOn { get; set; }
        public IEnumerable<MedicationViewModel> Medications { get; set; }



    }
}