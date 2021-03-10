using AutoMapper;
using MedicationAssistant.Common.Enums;
using MedicationAssistant.DAL;
using MedicationAssistant.ServiceLayer.Convertor;
using MedicationAssistant.ServiceLayer.DTOs;
using MedicationAssistant.ServiceLayer.Repositories;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public class MedicationViewModel
    {

        IMapper _mapper;
        [Inject]
        IMedicationRepository _medicationRepository { get; set; }
        [Inject]
        IPrescriptionRepository _prescriptionRepository { get; set; }

        [Inject]
        IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }

        public IEnumerable<string> _dosageUnit;
        public IEnumerable<string> _frequency;
        public readonly string _userId;
        public List<MedicationFullDetail> MedicationFullDetails { get; set; } 

        public MedicationViewModel(IDbContextFactory<MedAstDBContext> dbFactory,IMapper mapper, string userId)
        {
            _mapper = mapper;
            _dbFactory = dbFactory;
            _userId = userId;
            _dosageUnit = EnumValueConvertor.DosageUnits;
            _frequency = EnumValueConvertor.FrequencyUnits;
           
        }

        public async Task LoadData() 
        {
            
            using (var context = _dbFactory.CreateDbContext())
            {
                _prescriptionRepository = new PrescriptionRepository(context);
                var result = await _prescriptionRepository.GetPrescriptionsForUserAsync(_userId);
                List<MedicationFullDetail> meds = new();
                foreach (var pre in result)
                {
                    meds.AddRange(pre.Medications.Select(med => MedicationFullDetail.FromMedication(med,_mapper)).Distinct());
                }
                MedicationFullDetails = meds;
               
            }
        }
        

        public async Task OnRowUpdating(MedicationFullDetail Medication, Dictionary<string, object> newValues)
        {
            var x = 1;
            //await MedicationService.UpdateMedication(Medication, newValues);
        }

        public async Task OnRowInserting(Dictionary<string, object> values)
        {
            //await MedicationService.InsertMedication(values);
            //Medications = await MedicationService.GetMedications();
            //_ = InvokeAsync(StateHasChanged);
        }

      


    }
}