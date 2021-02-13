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
        public async Task<IEnumerable<Prescription>> GetPrescriptions(MedAstDBContext context, string userId)
        {
            try
            {
                return await context.Prescriptions
                                    .Where(prescription => prescription.UserId.Equals(userId))
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

        public async Task<List<Prescription>> GetRequiredAmountFullPrescriptions(MedAstDBContext context, string userId, int count)
        {
            try
            {
                return await context.Prescriptions
                                    .Where(prescription => prescription.UserId.Equals(userId))
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

        public async Task<bool> RemovePrescription(MedAstDBContext context, Prescription Prescription)
        {
            bool success = false;
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
            return success;
        }

        public async Task UpdatePrescription(MedAstDBContext context, Prescription Prescription, Dictionary<string, object> newValues)
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

        public async Task InsertPrescription(MedAstDBContext context, Prescription Prescription, Dictionary<string, object> values)
        {
            try
            {
                context.Prescriptions.Add(SetValues(Prescription, values));
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to Inserting Prescription object", ex);
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
                        pre.PrescriptionItems = (List<PrescriptionItem>)newValues[item];
                        break;
                }
            }
            return pre;
        }
    }
}