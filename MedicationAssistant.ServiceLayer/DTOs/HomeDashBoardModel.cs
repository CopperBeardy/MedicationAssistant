
using System.Collections.Generic;

namespace MedicationAssistant.ServiceLayer.Models
{
    public class HomeDashBoardModel
    {
      
        public IEnumerable<PrescriptionDashBoardModel> Prescriptions { get; set; }
        public IEnumerable<AlertDashBoardModel> Alerts { get; set; }
    }
}