
using MedicationAssistant.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories.Interfaces
{
    public interface IAlertRepository : IRepositoryBase<Alert>
    {
        Task<IEnumerable<Alert>> GetAllAlertsAsync();
        Task<IEnumerable<Alert>> GetAllAlertsForIdAsync(string accountId);
        Task<IEnumerable<Alert>> GetRequiredAmountOfAlertsForIdAsync(string userId, int count);
        Task<Alert> GetAlertByIdAsync(int AlertId);
        Task<Alert> GetAlertByIdWithMedicationsAsync(int alertId);
        void CreateAlert(Alert Alert);
        void UpdateAlert(Alert Alert);
        void DeleteAlert(Alert Alert);
    }
}
