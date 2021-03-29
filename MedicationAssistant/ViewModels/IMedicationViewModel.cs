using MedicationAssistant.ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
	public interface IMedicationViewModel : IViewModelBase
	{
		Task LoadData();
		void OnRowInserting(Dictionary<string, object> values);
		void OnRowUpdating(MedicationFullDetail Medication, Dictionary<string, object> newValues);
		List<MedicationFullDetail> MedicationFullDetails { get; set; }

	}
}