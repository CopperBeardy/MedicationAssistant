using MedicationAssistant.Common.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories.Interfaces
{
	public interface IPrescriptionRepository : IRepositoryBase<Prescription>
	{
		Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
		Task<IEnumerable<Prescription>> GetPrescriptionsForUserAsync(string UserId);
		Task<IEnumerable<Prescription>> GetRequiredPrescriptionsAsync(string UserId, int count);
		Task<Prescription> GetPrescriptionByIdAsync(int PrescriptionId);
		void CreatePrescription(Prescription Prescription);
		void UpdatePrescription(Prescription Prescription);
		void DeletePrescription(Prescription Prescription);
	}
}
