using MedicationAssistant.Data;
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
        private List<Prescription> Prescriptions { get; set; }

        public async Task<IEnumerable<Prescription>> GetPrescriptions(MedicationAssistantDBContext context)
        {
            try
            {
                Prescriptions = await context.Prescriptions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Prescriptions ", ex);
            }
            finally
            {
                context.Dispose();
            }
            return Prescriptions;
        }

        public async Task<IEnumerable<Prescription>> GetRequiredAmountFullPrescriptions(MedicationAssistantDBContext context, string userId)
        {
            try
            {
                Prescriptions = await context.Prescriptions.Where(x => x.UserId.Equals(userId))
                            .Include(items => items.PrescriptionItems)
                            .ThenInclude(m => m.Medicine)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("could not retrieve Prescriptions ", ex);
            }
            finally
            {
                context.Dispose();
            }
            return Prescriptions;
        }

        public async Task<bool> RemovePrescription(MedicationAssistantDBContext context, Prescription Prescription)
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
            finally
            {
                context.Dispose();
            }


            return success;
        }

        public async Task UpdatePrescription(MedicationAssistantDBContext context, Prescription Prescription, Dictionary<string, object> newValues)
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
            finally
            {
                context.Dispose();
            }


        }

        public async Task InsertPrescription(MedicationAssistantDBContext context, Prescription Prescription, Dictionary<string, object> values)
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
            finally
            {
                context.Dispose();
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
