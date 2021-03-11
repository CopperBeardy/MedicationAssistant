
using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.Helpers;
using MedicationAssistant.ServiceLayer.DTOs;
using MedicationAssistant.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Pages
{
    [Authorize]
    public partial class MedicationHome
    {
        [Inject]
        IMapper _mapper { get; set; }
        [Inject]
        IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }
       [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
     
        public MedicationViewModel MedicationDash { get; set; }  
        protected override async Task OnInitializedAsync()
        {

            MedicationDash = new MedicationViewModel( _dbFactory, UserHelper.GetUserId(AuthenticationStateProvider),_mapper);
            await MedicationDash.LoadData();
            StateHasChanged();
        }
             

        private static Task OnInitNewRow(Dictionary<string, object> values)
        {
            values.Add("Frequency", 1);
            values.Add("DosageUnit", 1);
            values.Add("MedicineDetails.UseDirections", "");
            return Task.CompletedTask;
        }


        public async Task OnRowUpdating(MedicationFullDetail Medication, Dictionary<string, object> newValues)
        {
             MedicationDash.Updating(Medication, newValues);
           await MedicationDash.LoadData();
            StateHasChanged();
        }

        public async Task OnRowInserting(Dictionary<string, object> values)
        {
             MedicationDash.Inserting(values);
            await MedicationDash.LoadData();
            StateHasChanged();
            //await MedicationService.InsertMedication(values);
            //Medications = await MedicationService.GetMedications();
            //_ = InvokeAsync(StateHasChanged);
        }
    }
}