using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.Shared.Models
{
    public class PrescriptionAlert : IAlert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Computed property to be display in List when alerts gathered
        /// </summary>
        public string Title =>
        $"Prescription to be take at - {Time} consisting of {AlertPrescriptionItems.Count}";
        

        /// <summary>
        /// What time the alert is to start to base its alert off
       /// </summary>
        public DateTime StartFrom { get; set; }

        /// <summary>
        /// What time the next Alert is due to be sent
        /// </summary>
        public DateTime Time { get; set; } = new DateTime();

        /// <summary>
        /// List of all Prescription items that should be 
        /// sent at the time of alert
        /// </summary>
        public List<PrescriptionItem> AlertPrescriptionItems { get; set; } = new List<PrescriptionItem>();
        
        /// <summary>
        /// For concurrency checks
        /// </summary>
        [Timestamp]
        public byte[] TimeStamp { get; set; }


    }
}
