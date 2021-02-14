using MedicationAssistant.Convertor;
using MedicationAssistant.Data;
using MedicationAssistant.Services;
using MedicationAssistant.Shared.Enums;
using MedicationAssistant.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Pages
{
    public partial class MedicineHome
    {
        [Inject]
        IDbContextFactory<MedAstDBContext> dbFactory { get; set; }
   
        IEnumerable<Medicine> Medicines = Enumerable.Empty<Medicine>();
        IEnumerable<string> DosageUnits = Enumerable.Empty<string>();

        protected override async Task OnInitializedAsync()
        {
          
            Medicines = await new MedicineService(dbFactory).GetMedicines();
            DosageUnits = DosageUnitValueConvertor.ConvertUnits();
        }

        async Task OnRowRemoving(Medicine Medicine)
        {
            await new MedicineService(dbFactory).RemoveMedicine( Medicine);
            Medicines = Medicines.Where(m => m != Medicine);
            await InvokeAsync(() => StateHasChanged());
        }

        async Task OnRowUpdating(Medicine Medicine, Dictionary<string, object> newValues)
        {
            await new MedicineService(dbFactory).UpdateMedicine( Medicine, newValues);
        }

        async Task OnRowInserting(Dictionary<string, object> values)
        {
            var newMed = new Medicine();
            await new MedicineService(dbFactory).InsertMedicine(values);
            Medicines = (new Medicine[] { newMed }).Concat(Medicines);
            await InvokeAsync(() => StateHasChanged());
        }

        Task OnInitNewRow(Dictionary<string, object> values)
        {
            values.Add("DosageUnit", 1);
            return Task.CompletedTask;
        }
    }
}