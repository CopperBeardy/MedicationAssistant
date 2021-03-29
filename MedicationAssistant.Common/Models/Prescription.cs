using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicationAssistant.Common.Models
{
	public class Prescription
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PrescriptionId { get; set; }

		[Required]
		public string UserId { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd:MM:yy}")]
		public DateTime CollectedOn { get; set; }

		public IEnumerable<Medication> Medications { get; set; }


	}
}