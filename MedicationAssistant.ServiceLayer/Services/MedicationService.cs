using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationAssistant.ServiceLayer.Repositories
{
    public class MedicationService
    {
        private readonly IDbContextFactory<MedAstDBContext> contextFactory;
        public MedicationService(IDbContextFactory<MedAstDBContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Medication>> GetMedications()
        {
            using var context = contextFactory.CreateDbContext();
            return await new MedicationRepository(context).FindAll().ToListAsync();
        }

        public void RemoveMedication(Medication Medication)
        {
            using var context = contextFactory.CreateDbContext();
            new MedicationRepository(context).DeleteMedication(Medication);
            context.SaveChanges();
        }

        public void UpdateMedication(Medication Medication, Dictionary<string, object> newValues)
        {
            using var context = contextFactory.CreateDbContext();
            new MedicationRepository(context).UpdateMedication(SetValues(Medication, newValues));
            context.SaveChanges();
        }

        public void InsertMedication(Dictionary<string, object> values)
        {
            using var context = contextFactory.CreateDbContext();
            new MedicationRepository(context).Create(SetValues(new(), values));
            context.SaveChanges();

        }

        private static Medication SetValues(Medication med, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        med.Name = (string)newValues[item];
                        break;
                    case "Quantity":
                        med.Quantity = (int)newValues[item];
                        break;
                    case "Dosage":
                        med.Dosage = (int)newValues[item];
                        break;
                    case "DosageUnit":
                        med.DosageUnit = (DosageUnit)newValues[item];
                        break;
                    case "Frequency":
                        med.Frequency = (Frequency)newValues[item];
                        break;
                    case "FrequencyUnit":
                        med.FrequencyUnit = (double)newValues[item];
                        break;
                    case "UseDirections":
                        med.MedicineDetails.UseDirections = (string)newValues[item];
                        break;
                }
            }
            return med;
        }
    }
}