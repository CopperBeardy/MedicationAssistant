using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicationAssistant.ViewModels
{
	public class AlertDashBoardModel
	{

		public int AlertModelId { get; set; }

		public string Title => $"Prescription to be take at - {Time.ToShortDateString()} ";

		[Required]
		public string UserId { get; set; }

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd:MM:yy}"),]
		public DateTime StartFrom { get; set; } = new DateTime();

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm}")]
		public DateTime Time { get; set; } = new DateTime();

		public IEnumerable<MedicationViewModel> Medications { get; set; }




	}
}