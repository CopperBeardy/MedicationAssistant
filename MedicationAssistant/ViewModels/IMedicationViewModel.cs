using MedicationAssistant.ServiceLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public interface IMedicationViewModel :IViewModelBase
    {
        Task LoadData();
       void OnRowInserting(Dictionary<string, object> values);
        void OnRowUpdating(MedicationFullDetail Medication, Dictionary<string, object> newValues);
        IEnumerable<string> DosageUnit { get; set; }
        IEnumerable<string> Frequency { get; set; }
        List<MedicationFullDetail> MedicationFullDetails { get; set; }
        string UserId { get; set; }
    }
}