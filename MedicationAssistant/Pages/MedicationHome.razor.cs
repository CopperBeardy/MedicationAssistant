
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
        IMapper mapper { get; set; }

        [Inject]
        private IDbContextFactory<MedAstDBContext> dbFactory { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
     
        public MedicationViewModel MedicationDash { get; set; }  
        protected override async Task OnInitializedAsync()
        {

            MedicationDash = new MedicationViewModel(dbFactory, mapper, UserHelper.GetUserId(AuthenticationStateProvider));
            await MedicationDash.LoadData();
            StateHasChanged();
        }
             

        private static Task OnInitNewRow(Dictionary<string, object> values)
        {
            values.Add("Frequency", 1);
            values.Add("DosageUnit", 1);
            return Task.CompletedTask;
        }
    }
}