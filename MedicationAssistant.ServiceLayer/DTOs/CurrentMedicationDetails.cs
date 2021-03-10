using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.DTOs
{
    public class CurrentMedicationDetails
    {
        public int MedicineDetailsId { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The usage of the medication needs to be between 25 - 250 characters", MinimumLength = 5)]
        public string UseDirections { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Medical Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string MedicalName { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
