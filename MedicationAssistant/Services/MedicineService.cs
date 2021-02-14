using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationAssistant.Data;
using MedicationAssistant.Services.Interfaces;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;

using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.Services
{
    public class MedicineService : IMedicineService
    {
        readonly IDbContextFactory<MedAstDBContext> contextFactory;
        public MedicineService(IDbContextFactory<MedAstDBContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        private List<Medicine> Medicines { get; set; }
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    Medicines = await context.Medicines.ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("could not retrieve Medicines ", ex);
                }
            }
            return Medicines;
        }

        public async Task<bool> RemoveMedicine(Medicine medicine)
        {
            bool success = false;
            using (var context = contextFactory.CreateDbContext())
            {
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
            }
            return success;
        }

        public async Task UpdateMedicine(Medicine medicine, Dictionary<string, object> newValues)
        {
            using (var context = contextFactory.CreateDbContext())
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

        public async Task InsertMedicine(Dictionary<string, object> values)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                try
                {
                    context.Medicines.Add(SetValues(new(), values));
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while trying to Inserting Medicine object", ex);
                }
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