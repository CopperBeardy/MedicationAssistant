using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.Helpers;
using MedicationAssistant.ServiceLayer.ModelConvertors;
using MedicationAssistant.ServiceLayer.Models;
using MedicationAssistant.ServiceLayer.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public class MedicationViewModel : ViewModelBase, IMedicationViewModel
    {
        public IEnumerable<string> DosageUnit { get; set; }= EnumValueConvertor.DosageUnits;
        public IEnumerable<string> Frequency { get; set; }= EnumValueConvertor.FrequencyUnits;
        public string UserId { get; set; }

        public List<MedicationFullDetail> MedicationFullDetails { get; set; }

        public MedicationViewModel(IMapper mapper,IDbContextFactory<MedAstDBContext> dbFactory,AuthenticationStateProvider authenticationStateProvider) 
        {  
            UserId = UserHelper.GetUserId(authenticationStateProvider);
            _mapper = mapper;
            _dbFactory = dbFactory;          
         }

        public async Task LoadData()
        {
           
            var context = _dbFactory.CreateDbContext();
            MedicationFullDetails = MedicationModelConvertor.ListFromMedication(
                   await new MedicationRepository(context).GetAllMedicationsForUser(UserId), _mapper);
        }

        public void OnRowUpdating(MedicationFullDetail Medication, Dictionary<string, object> newValues)
        {   
            var item = MedicationModelConvertor.FromMedicationFullDetail(Medication,newValues, _mapper);
            var context = _dbFactory.CreateDbContext();
            new MedicationRepository(context).UpdateMedication(item);
            context.SaveChanges();
            
            MedicationFullDetails[MedicationFullDetails.FindIndex(x => x.MedicationId == item.MedicationId)] 
                = MedicationModelConvertor.FromMedication(item,_mapper);
                
        }

        public void OnRowInserting(Dictionary<string, object> values)
        {
            values.Add("UserId", UserId);
            var item = MedicationModelConvertor.SetValues(new(), values);

            var context = _dbFactory.CreateDbContext();              
                new MedicationRepository(context).CreateMedication(item);
                context.SaveChanges();
           
            MedicationFullDetails.Add(MedicationModelConvertor.FromMedication(item,_mapper));
            
        }

       
    }
}