using MedicationAssistant.ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public interface IDashboardViewModel
    {
        IEnumerable<AlertTimeCount> Alerts { get; set; }
        IEnumerable<PrescriptionDateCount> Prescriptions { get; set; }
        public string UserId { get;  set; }
        Task GetLists();

    }

}