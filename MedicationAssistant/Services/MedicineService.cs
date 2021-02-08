using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationAssistant.Data;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Services
{
    public class MedicineService : IMedicineService
    {
         private List<Medicine> Medicines { get; set; }

        public async Task<IEnumerable<Medicine>> GetMedicines(MedicationAssistantDBContext context)
        {
            try
            { 
                Medicines = await context.Medicines.ToListAsync();               
            }
            catch (Exception ex)
            {

                throw new Exception("could not retrieve Medicines ",ex);
            }
            finally
            {
                context.Dispose();
            }              
                

           
            return Medicines;
        }

        public async Task<bool> RemoveMedicine(MedicationAssistantDBContext context,Medicine medicine)
        {
            bool success = false;
            
                try
                {
              
                    if (await context.Medicines.AnyAsync(x => x.Id == medicine.Id))
                    {

                        context.Medicines.Remove(medicine);
                        await context.SaveChangesAsync();
                        success = true;

                    }
                }
                catch (Exception ex)
                {

                    throw new Exception($"Error occured trying to remove entity with id: {medicine.Id}", ex);
                }
                finally
                {
                    context.Dispose();
                }
            

            return success;
        }

        public async Task UpdateMedicine(MedicationAssistantDBContext context,Medicine medicine, Dictionary<string, object> newValues)
        {
           
                try
                {
                    if (await context.Medicines.AnyAsync(x => x.Id == medicine.Id))
                    {

                        context.Medicines.Update(SetValues(medicine, newValues));

                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to update Medicine object", ex);
                }
            finally
            {
                context.Dispose();
            }

          
        }

        public async Task InsertMedicine(MedicationAssistantDBContext context,Medicine medicine, Dictionary<string, object> values)
        {
           
                try
                {
                    context.Medicines.Add(SetValues(medicine, values)); 
                await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to Inserting Medicine object", ex);
                  }
                   finally
                    {
                context.Dispose();
                    }
              

            
        }


        private Medicine SetValues(Medicine med, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        med.Name = (string)newValues[item];
                        break;
                    case "Dosage":
                        med.Dosage = (int)newValues[item];
                        break;
                    case "Description":
                        med.Description = (string)newValues[item];
                        break;
                    case "UseDirections":
                        med.UseDirections = (string)newValues[item];
                        break;
                    case "DosageUnit":
                        med.DosageUnit = (DosageUnit)newValues[item];
                        break;
                }
            }

            return med;
        }

    }
}
