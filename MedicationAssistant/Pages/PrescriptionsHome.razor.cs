using MedicationAssistant.Data;
using MedicationAssistant.Helpers;
using MedicationAssistant.Services;
using MedicationAssistant.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Pages
{
    public partial class PrescriptionsHome
    {
        [Inject]
        IDbContextFactory<MedAstDBContext> dbFactory { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
          
        public IEnumerable<Prescription> Prescriptions;     

     
        protected override async Task OnInitializedAsync()
        {    
            string id= UserHelper.GetUserId(AuthenticationStateProvider);           
            Prescriptions = await new PrescriptionService(dbFactory).GetPrescriptions(id);   
        }
        //todo get all prescriptions for the current user from database
        public void OnRowRemoving(Prescription prescription)
        {

        }

        public void OnRowUpdating(Prescription prescription, Dictionary<string, object> newValues)
        {
        }

        public void OnRowInserting(Dictionary<string, object> values)
        {

        }
    }
}