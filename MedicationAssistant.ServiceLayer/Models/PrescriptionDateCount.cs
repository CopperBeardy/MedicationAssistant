using System;

namespace MedicationAssistant.ServiceLayer.Models
{
	public class PrescriptionDateCount
	{
		public DateTime CollectedOn { get; private set; }
		public int NumberOfMedications { get; private set; }
	}
}
