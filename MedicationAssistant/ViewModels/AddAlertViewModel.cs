using AutoMapper;
using MedicationAssistant.Data;
using MedicationAssistant.Data.Entities;
using MedicationAssistant.Helpers;
using MedicationAssistant.Profiles;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public class AddAlertViewModel : IMapFrom<AlertModel>, IMapFrom<PrescriptionModel>, IAddAlertViewModel
    {
        public bool Busy;
        public bool Success;
        public bool Error;
        public string ErrorMessage = string.Empty;
        readonly NavigationManager Nav;
        readonly IPageHelper PageHelper;
        readonly IDbContextFactory<MedicationAssistantDBContext> dbFactory;
        readonly IMapper mapper;
        public EventCallback<bool> ValidationResult { get; set; }
        public EventCallback CancelRequest { get; set; }
        public AlertModel Alert { get; set; }
        public AlertModel DbAlert { get; set; }
        public List<Prescription> Prescriptions { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Alert, AlertModel>().ReverseMap();
            profile.CreateMap<Prescription, PrescriptionModel>().ReverseMap();

        }


        public AddAlertViewModel()
        {

            using var context = dbFactory.CreateDbContext();
            Alert = new AlertModel()
            {
                Prescription = new PrescriptionModel(),
                User = new UserModel()
            };

        }



        public async Task ValidationResultAsync(bool success)
        {
            if (Busy)
            {
                return;
            }

            if (!success)
            {
                Success = false;
                Error = false;
                return;
            }
            Busy = true;

            using var context = dbFactory.CreateDbContext();


            context.Set<Alert>().Add(mapper.Map<Alert>(Alert));

            try
            {
                await context.SaveChangesAsync();
                Success = true;
                Error = false;
                Busy = false;

            }
            catch (Exception ex)
            {
                Success = false;
                Error = true;
                ErrorMessage = ex.Message;
                Busy = false;
            }
        }

        /// <summary>
        /// Back to list.
        /// </summary>
        public void Cancel()
        {

            Nav.NavigateTo($"/{PageHelper.Page}");
        }
        public Task CancelAsync()
        {
            return CancelRequest.InvokeAsync(null);
        }

        public Task HandleSubmitAsync(bool isValid)
        {
            return ValidationResult.InvokeAsync(isValid);
        }
    }
}
