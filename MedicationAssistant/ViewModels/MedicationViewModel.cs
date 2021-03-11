using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.ServiceLayer.Convertor;
using MedicationAssistant.ServiceLayer.DTOs;
using MedicationAssistant.ServiceLayer.Repositories;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public class MedicationViewModel 
    {

        IMapper _mapper;
     
        [Inject]
        IMedicationRepository _medicationRepository { get; set; }

        
        IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }

        public IEnumerable<string> _dosageUnit;
        public IEnumerable<string> _frequency;
        public readonly string _userId;

        
        public List<MedicationFullDetail> MedicationFullDetails { get; set; } 

        public MedicationViewModel(IDbContextFactory<MedAstDBContext> dbFactory,string userId,IMapper mapper)
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
                _medicationRepository = new MedicationRepository(context);
                var result = await _medicationRepository.GetAllMedicationsForUser(_userId);
                List<MedicationFullDetail> meds = new();
                foreach (var pre in result)
                {
                    meds.Add( MedicationFullDetail.FromMedication(pre,_mapper));
                }
                MedicationFullDetails = meds;
               
            }
        }
        


        public void Updating(MedicationFullDetail Medication, Dictionary<string, object> newValues)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
              
                var item = MedicationService.SetValues(
                        MedicationFullDetail.FromMedicationFullDetail(Medication, _mapper), newValues);
         
                 new MedicationRepository(context).UpdateMedication(item );
                  context.SaveChanges();
           }
            
        }

        public void Inserting(Dictionary<string, object> values)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                values.Add("UserId", _userId);
                var item = MedicationService.SetValues(new(), values);

                new MedicationRepository(context).CreateMedication(item);
                context.SaveChanges();
            }
            //await MedicationService.InsertMedication(values);
            //Medications = await MedicationService.GetMedications();
            //_ = InvokeAsync(StateHasChanged);
        }
    }
}