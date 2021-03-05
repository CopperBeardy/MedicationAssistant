using MedicationAssistant.Common.Enums;
using MedicationAssistant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.DAL
{
    public static class SeedDevData
    {
        

        public static void Seed(MedAstDBContext medAstDBContext)
        {
            string userId = "1e3ed9ff-4e8f-47de-bb1a-e7ee3d5c2473";       
        
           
           
            if (medAstDBContext.Medications.Any())
            {
                return;
            }
            //List<MedicineDetail> medicineDetails = new List<MedicineDetail>()
            //{
            //    new MedicineDetail()
            //    {
                    
            //        MedicalName = "Diazepam",
            //        UseDirections = "Take with food"
            //    },
            //    new MedicineDetail()
            //    {
                    
            //        MedicalName="Pregabalin",
            //        UseDirections="Take in the morning"
            //    },
            //    new MedicineDetail()
            //    {
                    
            //        MedicalName="Citalopram",
            //        UseDirections="Take a hour before food"
            //    }
            //};
            //medAstDBContext.MedicineDetails.AddRange(medicineDetails);
            //medAstDBContext.SaveChanges();

            List<Medication> medications = new List<Medication>()
            {
                new Medication()
                {
                    
                    MedicineDetailsId=1,
                    Dosage=5,
                    DosageUnit= DosageUnit.mg,
                    Frequency= Frequency.AsNeeded,
                    FrequencyUnit=0,
                    Name = "Diazepam",
                    Quantity=1,
                },
                new Medication()
                {
                    
                    MedicineDetailsId =2,
                    Dosage=50,
                    DosageUnit= DosageUnit.mg,
                    Frequency= Frequency.Daily,
                    FrequencyUnit=1,
                    Name = "Pregabablin",
                    Quantity=2,
                },
                new Medication()
                {
                    
                   MedicineDetailsId=3,
                    Dosage=100,
                    DosageUnit= DosageUnit.mg,
                    Frequency= Frequency.Daily,
                    FrequencyUnit=1,
                    Name = "Citalopram",
                    Quantity=1,
                }
            };

            medAstDBContext.Medications.AddRange(medications);
            medAstDBContext.SaveChanges();

            List<Prescription> prescriptions = new List<Prescription>()
            {
                new Prescription()
                {
               
                UserId= userId,
                Medications = new List<Medication>(){
                    medAstDBContext.Medications.First(x => x.MedicationId==1),
                    medAstDBContext.Medications.First(x => x.MedicationId==2)
                },
                CollectedOn = DateTime.Now.AddDays(-1)


                },
                new Prescription(){
                    
                UserId= userId,
                Medications = new List<Medication>(){
                    medAstDBContext.Medications.First(x => x.MedicationId==2),
                    medAstDBContext.Medications.First(x => x.MedicationId==3)
                },
                CollectedOn = DateTime.Now.AddDays(-3)


                }


            };
            medAstDBContext.Prescriptions.AddRange(prescriptions);
            medAstDBContext.SaveChanges();

            List<Alert> alerts = new List<Alert>()
            {
                new Alert(){
                
                UserId= userId,
                Medications = new List<Medication>(){
                    medAstDBContext.Medications.First(x => x.MedicationId==1),
                    medAstDBContext.Medications.First(x => x.MedicationId==2)
                },
                StartFrom = DateTime.Now,
                Time = DateTime.Now.AddHours(18)


                },
                  new Alert(){
                
                UserId= userId,
                Medications = new List<Medication>(){
                    medAstDBContext.Medications.First(x => x.MedicationId==3),
                },
                StartFrom = DateTime.Now.AddDays(-2),
                Time = DateTime.Now.AddHours(16)


                },
            };
            medAstDBContext.Alerts.AddRange(alerts);
            medAstDBContext.SaveChanges();

        }
    }
}
