using MedicationAssistant.DAL;
using MedicationAssistant.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Repositories
{
    public class PrescriptionService
    {
        private readonly IDbContextFactory<MedAstDBContext> contextFactory;
        public PrescriptionService(IDbContextFactory<MedAstDBContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task<IEnumerable<Prescription>> GetPrescriptions(string userId)
        {
            using var context = contextFactory.CreateDbContext();
            return await new PrescriptionRepository(context)
                .GetAllPrescriptionsAsync();
        }

        public async Task<Prescription> GetPrescriptionWithId(int prescriptionId)
        {
            using var context = contextFactory.CreateDbContext();
            return await new PrescriptionRepository(context)
                .GetPrescriptionByIdWithMedicationsAsync(prescriptionId);
        }

        public async Task<IEnumerable<Prescription>> GetRequiredAmountFullPrescriptions(string userId, int count)
        {
            using var context = contextFactory.CreateDbContext();
            return await new PrescriptionRepository(context)
                .GetRequiredAmountOfPrescriptionsWithMedicationsForUserAsync(userId, count);
        }
        public void RemovePrescription(Prescription Prescription)
        {
            using var context = contextFactory.CreateDbContext();
            new PrescriptionRepository(context).DeletePrescription(Prescription);
            context.SaveChanges();
        }

        public void UpdatePrescription(Prescription Prescription, Dictionary<string, object> newValues)
        {
            using var context = contextFactory.CreateDbContext();
            new PrescriptionRepository(context).UpdatePrescription(SetValues(Prescription, newValues));
            context.SaveChanges();
        }

        public void InsertPrescription(Dictionary<string, object> values)
        {
            using var context = contextFactory.CreateDbContext();
            new PrescriptionRepository(context).CreatePrescription(SetValues(new(), values));
            context.SaveChanges();
        }

        private static Prescription SetValues(Prescription pre, Dictionary<string, object> newValues)
        {
            foreach (var item in newValues.Keys)
            {
                switch (item)
                {
                    case "Name":
                        pre.CollectedOn = (DateTime)newValues[item];
                        break;
                    case "Medications":
                        pre.Medications = (List<Medication>)newValues[item];
                        break;
                }
            }
            return pre;
        }

    }
}