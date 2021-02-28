
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.DAL.Entities
{
    public class Alert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlertId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd:MM:yy}")]
        public DateTime StartFrom { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm}")]
        public DateTime Time { get; set; }

        public IEnumerable<Medication> Medications { get; set; }


        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}