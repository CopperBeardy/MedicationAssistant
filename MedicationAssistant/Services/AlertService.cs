using MedicationAssistant.Data;
using MedicationAssistant.Services.Interfaces;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Services
{
    public class AlertService : IAlertService
    {
        readonly IDbContextFactory<MedAstDBContext> contextFactory;
        public AlertService(IDbContextFactory<MedAstDBContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<PrescriptionItemAlert>> GetPrescriptionItemAlerts(string userId)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    return await context.PrescriptionAlerts
                                        .Where(alert => alert.AccountId.Equals(userId))
                                        .Include(items => items.PrescriptionItems)
                                        .OrderByDescending(time => time.Time)
                                        .Take(5)
                                        .ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("could not retrieve PrescriptionItemAlerts ", ex);
                }
            }
        }

        public async Task<bool> RemovePrescriptionItemAlert(PrescriptionItemAlert PrescriptionItemAlert)
        {
            bool success = false;
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    if (await context.PrescriptionAlerts.AnyAsync(x => x.Id == PrescriptionItemAlert.Id))
                    {
                        context.PrescriptionAlerts.Remove(PrescriptionItemAlert);
                        await context.SaveChangesAsync();
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error occured trying to remove entity with id: {PrescriptionItemAlert.Id}", ex);
                }
            }
            return success;
        }

        public async Task UpdatePrescriptionItemAlert(PrescriptionItemAlert PrescriptionItemAlert, Dictionary<string, object> newValues)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    if (await context.PrescriptionAlerts.AnyAsync(x => x.Id == PrescriptionItemAlert.Id))
                    {
                        context.PrescriptionAlerts.Update(SetValues(PrescriptionItemAlert, newValues));
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to update PrescriptionItemAlert object", ex);
                }
            }
        }

        public async Task InsertPrescriptionItemAlert( Dictionary<string, object> values)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    context.PrescriptionAlerts.Add(SetValues(new(), values));
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to Inserting PrescriptionItemAlert object", ex);
                }
            }
        }


        private PrescriptionItemAlert SetValues(PrescriptionItemAlert preItem, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        preItem.StartFrom = (DateTime)newValues[item];
                        break;
                }
            }
            return preItem;
        }
    }
}