using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories
{
    public class AlertService
    {
        private readonly IDbContextFactory<MedAstDBContext> contextFactory;

        public AlertService(IDbContextFactory<MedAstDBContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Alert>> GetAllAlertsForUser(string userId)
        {
            using var context = contextFactory.CreateDbContext();
            return await new AlertRepository(context).FindAll()
                                    .OrderByDescending(time => time.Time)
                                    .Take(5)
                                    .ToListAsync();
        }

        public void RemoveAlert(Alert Alert)
        {
            using var context = contextFactory.CreateDbContext();
            new AlertRepository(context).DeleteAlert(Alert);
            context.SaveChanges();
        }

        public void UpdateMedicationAlert(Alert Alert, Dictionary<string, object> newValues)
        {
            using var context = contextFactory.CreateDbContext();
            new AlertRepository(context).UpdateAlert(SetValues(Alert, newValues));
            context.SaveChanges();
        }

        public void InsertAlert(Dictionary<string, object> values)
        {
            using var context = contextFactory.CreateDbContext();
            new AlertRepository(context).Create(SetValues(new Alert(), values));
            context.SaveChanges();
        }


        private static Alert SetValues(Alert preItem, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        preItem.StartFrom = (DateTime)newValues[item];
                        break;
                    case "Medications":
                        preItem.Medications = (List<Medication>)newValues[item];
                        break;
                    case "StartFrom":
                        preItem.StartFrom = (DateTime)newValues[item];
                        break;
                    case "Time":
                        preItem.Time = (DateTime)newValues[item];
                        break;
                    case "UserId":
                        preItem.UserId = (string)newValues[item];
                        break;

                }
            }
            return preItem;
        }
    }
}