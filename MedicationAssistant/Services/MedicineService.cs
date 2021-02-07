using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedicationAssistant.Data;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Services
{
    public class MedicineService : IMedicineService
    {
        readonly IDbContextFactory<MedicationAssistantDBContext> _dbContextFactory;

        private List<Medicine> Medicines { get; set; }



        public MedicineService(IDbContextFactory<MedicationAssistantDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

        }
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Medicines = await context.Medicines.ToListAsync();
            }

            if (Medicines.Count == 0 || Medicines == null)
            {
                Medicines = new List<Medicine>();
            }
            return Medicines;
        }

        public async Task<bool> RemoveMedicine(Medicine medicine)
        {
            bool success = false;
            MedicationAssistantDBContext context = _dbContextFactory.CreateDbContext();
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

        public async Task UpdateMedicine(Medicine medicine, Dictionary<string, object> newValues)
        {
            using (var context = _dbContextFactory.CreateDbContext())
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

            }
        }

        public async Task InsertMedicine(Medicine medicine, Dictionary<string, object> values)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    context.Medicines.Add(SetValues(medicine, values));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to Inserting Medicine object", ex);
                }
                await context.SaveChangesAsync();

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
