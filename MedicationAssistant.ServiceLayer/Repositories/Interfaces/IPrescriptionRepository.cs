using MedicationAssistant.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories.Interfaces
{
    public interface IPrescriptionRepository : IRepositoryBase<Prescription>
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        Task<IEnumerable<Prescription>> GetPrescriptionsWithMedicationsForUserAsync(string UserId);
        Task<IEnumerable<Prescription>> GetRequiredAmountOfPrescriptionsWithMedicationsForUserAsync(string UserId, int count);
        Task<Prescription> GetPrescriptionByIdWithMedicationsAsync(int PrescriptionId);
        void CreatePrescription(Prescription Prescription);
        void UpdatePrescription(Prescription Prescription);
        void DeletePrescription(Prescription Prescription);
    }
}
