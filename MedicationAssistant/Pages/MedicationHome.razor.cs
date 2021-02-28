using MedicationAssistant.Convertor;
using MedicationAssistant.DAL;
using MedicationAssistant.ServiceLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
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
        private IDbContextFactory<MedAstDBContext> DbFactory { get; set; }
        [Inject]
        private IMedicationRepository repo { get; set; }

        private IEnumerable<Medication> Medications = Enumerable.Empty<Medication>();
        private IEnumerable<string> DosageUnits = Enumerable.Empty<string>();
        private IEnumerable<string> Frequencies = Enumerable.Empty<string>();

        protected override async Task OnInitializedAsync()
        {
            vm = new MedicationHomeViewModel(repo);
            DosageUnits = EnumValueConvertor.DosageUnits;
            Frequencies = EnumValueConvertor.FrequencyUnits;

            MedicationService = new MedicationRepository(DbFactory);
            Medications = await MedicationService.GetMedications();


        }

        private async Task OnRowRemoving(Medication Medication)
        {
            await MedicationService.RemoveMedication(Medication);
            Medications = Medications.Where(m => m != Medication);
            _ = InvokeAsync(StateHasChanged);
        }

        private async Task OnRowUpdating(Medication Medication, Dictionary<string, object> newValues)
        {
            await MedicationService.UpdateMedication(Medication, newValues);
        }

        private async Task OnRowInserting(Dictionary<string, object> values)
        {
            await MedicationService.InsertMedication(values);
            Medications = await MedicationService.GetMedications();
            _ = InvokeAsync(StateHasChanged);
        }

        private static Task OnInitNewRow(Dictionary<string, object> values)
        {
            values.Add("Frequency", 1);
            return Task.CompletedTask;
        }
    }
}