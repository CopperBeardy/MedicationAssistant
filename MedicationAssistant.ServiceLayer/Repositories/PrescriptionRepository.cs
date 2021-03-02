using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MedicationAssistant.ServiceLayer.Repositories
{
    public class PrescriptionRepository : RepositoryBase<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(MedAstDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            try
            {
                return await FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Prescriptions ", ex);
            }
        }

        public async Task<IEnumerable<Prescription>> GetRequiredAmountOfPrescriptionsAsync(string userId, int count)
        {
            try
            {
                var result = await FindByCondition(prescription => prescription.UserId.Equals(userId))
                    .OrderByDescending(x => x.CollectedOn)
                    .Take(count)
                    .Include(x => x.Medications)
                    .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Prescriptions ", ex);
            }
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsForUserAsync(string userId)
        {
            try
            {
                return await FindByCondition(prescription => prescription.UserId.Equals(userId))
                    .OrderByDescending(x => x.CollectedOn)
                    .Include(m => m.Medications)
                    .ThenInclude(d => d.MedicineDetails)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Prescriptions ", ex);
            }
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int PrescriptionId)
        {
            try
            {
                return await FindByCondition(x => x.PrescriptionId.Equals(PrescriptionId))
                .Include(m => m.Medications)
                .ThenInclude(d => d.MedicineDetails)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Prescriptions ", ex);
            }
        }

        public void CreatePrescription(Prescription Prescription)
        {
            try
            {
                Create(Prescription);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to create Prescription", ex);
            }
        }

        public void UpdatePrescription(Prescription Prescription)
        {
            try
            {
                Update(Prescription);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to Update Prescription", ex);
            }
        }

        public void DeletePrescription(Prescription Prescription)
        {
            try
            {
                Delete(Prescription);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to remove Prescription", ex);
            }
        }


    }
}