using MedicationAssistant.DAL.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories.Interfaces
{
    public interface IMedicationRepository : IRepositoryBase<Medication>
    {
        Task<IEnumerable<Medication>> GetAllMedicationsAsync();
        Task<Medication> GetMedicationByIdWithDetailsAsync(int MedicationId);
        void CreateMedication(Medication Medication);
        void UpdateMedication(Medication Medication);
        void DeleteMedication(Medication Medication);
        Task<IEnumerable<Medication>> GetAllMedicationsForUser(string user);
    }
}
