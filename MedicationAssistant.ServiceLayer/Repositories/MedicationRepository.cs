using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationAssistant.ServiceLayer.Repositories
{
    public class MedicationRepository : RepositoryBase<Medication>, IMedicationRepository
    {
        public MedicationRepository(MedAstDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Medication>> GetAllMedicationsAsync()
        {
            try
            {
                return await FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Medications ", ex);
            }
        }
        public async Task<IEnumerable<Medication>> GetAllMedicationsForUser(string user)
        {
            try
            {
                return await FindByCondition(med => med.UserId.Equals(user)).ToListAsync();

            }
            catch (Exception ex )
            {

                throw new Exception($"unable to retrieve medications for user{user}", ex);
            }
        }

          public async Task<Medication> GetMedicationByIdWithDetailsAsync(int medicationId)
        {
            try
            {
                return await FindByCondition(med => med.MedicationId.Equals(medicationId))
                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Medication ", ex);
            }
        }

        public void CreateMedication(Medication Medication)
        {
            try
            {
                Create(Medication);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to create Medication object", ex);
            }
        }

        public void UpdateMedication(Medication Medication)
        {
            try
            {
                Update(Medication);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update Medication object", ex);
            }
        }

        public void DeleteMedication(Medication Medication)
        {
            try
            {
                
                Delete(Medication);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error occurred trying to remove entity with id: {Medication.MedicationId}", ex);
            }
        }
    }
}