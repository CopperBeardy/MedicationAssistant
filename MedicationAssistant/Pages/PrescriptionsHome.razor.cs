//using MedicationAssistant.DAL;
//using MedicationAssistant.Helpers;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace MedicationAssistant.Pages
//{
//    [Authorize]
//    public partial class PrescriptionsHome
//    {
//        [Inject]
//        private IDbContextFactory<MedAstDBContext> DbFactory { get; set; }
//        [Inject]
//        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

//        public static IEnumerable<PrescriptionModel> Prescriptions { get; set; }
//        [Inject]
//        private IPrescriptionRepository PrescriptionService { get; set; }



//        protected override async Task OnInitializedAsync()
//        {
//            PrescriptionService = new PrescriptionRepository(DbFactory);
//            string id = UserHelper.GetUserId(AuthenticationStateProvider);
//            Prescriptions = await PrescriptionService.GetPrescriptions(id);
//        }




//        //todo get all prescriptions for the current user from database
//        public async Task OnRowRemoving(PrescriptionModel prescription)
//        {
//            await PrescriptionService.RemovePrescription(prescription);
//            string id = UserHelper.GetUserId(AuthenticationStateProvider);
//            Prescriptions = await PrescriptionService.GetPrescriptions(id);
//        }

//        public async Task OnRowUpdating(PrescriptionModel prescription, Dictionary<string, object> newValues)
//        {
//            await PrescriptionService.UpdatePrescription(prescription, newValues);
//            await InvokeAsync(StateHasChanged);

//        }

//        public async Task OnRowInserting(Dictionary<string, object> values)
//        {
//            await PrescriptionService.InsertPrescription(values);
//            string id = UserHelper.GetUserId(AuthenticationStateProvider);
//            Prescriptions = await PrescriptionService.GetPrescriptions(id);
//        }
//    }
//}