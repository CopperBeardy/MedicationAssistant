
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ServiceLayer.Models
{
    public class PrescriptionDashBoardModel
    {

        public int PrescriptionModelId { get; set; }
        [Required]
        public HomeDashBoardModel Account { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd:MM:yy}")]
        public DateTime CollectedOn { get; set; }
        public IEnumerable<MedicationDashboardModel> Medications { get; set; }



    }
}