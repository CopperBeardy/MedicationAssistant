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

    public class AlertRepository : RepositoryBase<Alert>, IAlertRepository
    {
        public AlertRepository(MedAstDBContext context) : base(context)
        {

        }


        public async Task<IEnumerable<Alert>> GetAllAlertsAsync()
        {

            try
            {
                return await FindAll().OrderByDescending(a => a.Time).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve MedicationAlerts ", ex);
            }
        }
        public async Task<IEnumerable<Alert>> GetAllAlertsForIdAsync(string userId)
        {
            try
            {
                return await FindByCondition(alerts => alerts.UserId.Equals(userId))
                    .OrderByDescending(a => a.Time)
                    .Include(x => x.Medications)
                    .ThenInclude(x => x.MedicineDetails)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve MedicationAlerts ", ex);
            }
        }

        public async Task<IEnumerable<Alert>> GetRequiredAmountOfAlertsForIdAsync(string userId, int count)
        {
            try
            {
                return await FindByCondition(alerts => alerts.UserId.Equals(userId))
                    .OrderByDescending(a => a.Time)
                    .Take(count)
                    .Include(x => x.Medications)
                    .ThenInclude(x => x.MedicineDetails)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve MedicationAlerts ", ex);
            }
        }


        public async Task<Alert> GetAlertByIdAsync(int alertId)
        {
            try
            {
                return await FindByCondition(alert => alert.AlertId.Equals(alertId)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Alerts ", ex);
            }
        }

        public async Task<Alert> GetAlertByIdWithMedicationsAsync(int alertId)
        {
            try
            {
                return await FindByCondition(alert => alert.AlertId.Equals(alertId)).Include(x => x.Medications).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Alerts ", ex);
            }
        }

        public void CreateAlert(Alert Alert)
        {
            try
            {
                Create(Alert);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to Inserting Alert object", ex);
            }
        }

        public void UpdateAlert(Alert Alert)
        {
            try
            {
                Update(Alert);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update Alert object", ex);
            }
        }

        public void DeleteAlert(Alert Alert)
        {
            try
            {
                Delete(Alert);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred trying to remove entity with id: {Alert.AlertId}", ex);
            }
        }
    }
}