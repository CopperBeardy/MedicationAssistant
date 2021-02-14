using MedicationAssistant.Data;
using MedicationAssistant.Services.Interfaces;
using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        readonly IDbContextFactory<MedAstDBContext> contextFactory;
        public PrescriptionService(IDbContextFactory<MedAstDBContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<Prescription>> GetPrescriptions(string userId)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    return await context.Prescriptions
                                        .Where(prescription => prescription.AccountId.Equals(userId))
                                        .OrderByDescending(time => time.CollectedOn)
                                        .Include(items => items.PrescriptionItems)
                                        .ThenInclude(m => m.Medicine)
                                        .ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("could not retrieve Prescriptions ", ex);
                }
            }
        }

        public async Task<Prescription> GetById(int id)
        {
            using (var context = contextFactory.CreateDbContext()) 
            {
                return await context.Prescriptions.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<Prescription>> GetRequiredAmountFullPrescriptions(string userId, int count)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    return await context.Prescriptions
                                        .Where(prescription => prescription.AccountId.Equals(userId))
                                        .OrderByDescending(time => time.CollectedOn)
                                        .Take(count)
                                        .Include(items => items.PrescriptionItems)
                                        .ThenInclude(m => m.Medicine)
                                        .ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("could not retrieve Prescriptions ", ex);
                }
            }
        }
        public async Task<bool> RemovePrescription(Prescription Prescription)
        {
            bool success = false;
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    if (await context.Prescriptions.AnyAsync(x => x.Id == Prescription.Id))
                    {
                        context.Prescriptions.Remove(Prescription);
                        await context.SaveChangesAsync();
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error occured trying to remove entity with id: {Prescription.Id}", ex);
                }
            }
            return success;
        }

        public async Task UpdatePrescription(Prescription Prescription, Dictionary<string, object> newValues)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    if (await context.Prescriptions.AnyAsync(x => x.Id == Prescription.Id))
                    {
                        context.Prescriptions.Update(SetValues(Prescription, newValues));
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to update Prescription object", ex);
                }
            }
        }

        public async Task InsertPrescription(Dictionary<string, object> values)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {

                    context.Prescriptions.Add(SetValues(new Prescription(), values));
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to Inserting Prescription object", ex);
                }
            }
        }
        private Prescription SetValues(Prescription pre, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        pre.CollectedOn = (DateTime)newValues[item];
                        break;
                    case "PrescriptionItems":
                        pre.PrescriptionItems = (IQueryable<PrescriptionItem>)newValues[item];
                        break;
                }
            }
            return pre;
        }
    }
}