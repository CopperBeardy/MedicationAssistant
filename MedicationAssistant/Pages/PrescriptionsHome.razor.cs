using MedicationAssistant.Data;
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
        IDbContextFactory<MedicationAssistantDBContext> dbFactory { get; set; }

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public IEnumerable<Prescription> Prescriptions;

        public User User;

        public IEnumerable<Medicine> Medicines;

        IEnumerable<Medicine> Values { get; set; }


        Prescription selectedPrescription;
        public Prescription SelectedPrescription
        {
            get { return selectedPrescription; }
            set
            {
                selectedPrescription = value;
                InvokeAsync(StateHasChanged);
            }
        }
        protected override async Task OnInitializedAsync()
        {    
            User = UserService.GetUser(dbFactory.CreateDbContext(),AuthenticationStateProvider);

            using (var context = dbFactory.CreateDbContext())
            {

                Prescriptions = await new PrescriptionService().GetRequiredAmountFullPrescriptions(dbFactory.CreateDbContext(), User.Id);

                Medicines = context.Medicines.ToList();


            }

            if (!Prescriptions.Count().Equals(0))
            {
                SelectedPrescription = Prescriptions.First();
            }


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
