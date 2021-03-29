using MedicationAssistant.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ServiceLayer.Models
{
	public class MedicationFullDetail
	{
		public int MedicationId { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
		public string Name { get; set; }

		public string UserId { get; private set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public int Dosage { get; set; }

		[Required]
		public DosageUnit DosageUnit { get; set; }

		[Required]
		public double FrequencyUnit { get; set; }

		[Required]
		public Frequency Frequency { get; set; }

		[Required]
		public string UseDirections { get; set; }

		public byte[] TimeStamp { get; private set; }



	}
}
