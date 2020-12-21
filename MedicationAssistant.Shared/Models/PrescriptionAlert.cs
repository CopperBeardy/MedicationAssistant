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


        public string Title
        {     
            get
            {
                return $"Prescription to be take at - {Time} consisting of {AlertItems.Count}";
            }
        }

        public DateTime FirstUse { get; set; }
        public DateTime Time { get; set; } = new DateTime();
        public List<PrescriptionItem> AlertItems { get; set; } = new List<PrescriptionItem>();
        
        
        [Timestamp]
        public byte[] TimeStamp { get; set; }


    }
}
