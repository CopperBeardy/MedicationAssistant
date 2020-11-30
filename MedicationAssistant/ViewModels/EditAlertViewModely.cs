using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicationAssistant.Data;
using MedicationAssistant.Data.Entities;
using MedicationAssistant.Helpers;
using MedicationAssistant.Profiles;
using Microsoft.AspNetCore.Components;

using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.ViewModels
{
    public class EditAlertViewModel : IMapFrom<AlertModel>, IMapFrom<PrescriptionModel>, IDisposable
    {
        public bool Busy;
        public bool Success;
        public bool Error;
        public string ErrorMessage = string.Empty;
        public bool ConcurrencyError;
        readonly NavigationManager Nav;
        readonly IPageHelper PageHelper;
        readonly IDbContextFactory<MedicationAssistantDBContext> dbFactory;
        readonly MedicationAssistantDBContext context;
        readonly IMapper mapper;
        readonly EditSuccess EditSuccessState;
        public AlertModel Alert { get; set; }
        public AlertModel DbAlert { get; set; }
        public List<Prescription> Prescriptions { get; set; }

      
        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Alert, AlertModel>().ReverseMap();
            profile.CreateMap<Prescription, PrescriptionModel>().ReverseMap();
        
        }

        public  EditAlertViewModel()
        {
            context = dbFactory.CreateDbContext();
            _ = GetViewModel();
        }
        public async Task GetViewModel()
        {
            Busy = true;

            try
            {               
              
                Alert = mapper.Map<AlertModel>( await context.Alerts
                    .SingleOrDefaultAsync(c => c.Id == AlertId));
            }
            finally
            {
                Busy = false;
            }
            
            Alert = new AlertModel()
            {
                Prescription = new PrescriptionModel(),
                User = new UserModel()
            };

        }
        
        public int AlertId { get; set; }

   

        public async Task ValidationResultAsync(bool success)
        {
            if (Busy)
            {
                return;
            }

            if (!success)
            {
                // still need to edit model
                Error = false;
                ConcurrencyError = false;
                return;
            }

            Busy = true; // async
            try
            {
                await context.SaveChangesAsync();
                EditSuccessState.Success = true;
                // go to view to see the record
                Nav.NavigateTo($"/viewmed/{Alert.Id}");
            }
            catch (DbUpdateConcurrencyException dbex)
            {
                EditSuccessState.Success = false;

                // concurrency issues!
                ConcurrencyError = true;

                // get values from database
                var dbValues = dbex.Entries[0].GetDatabaseValues();

                if (dbValues == null)
                {
                    // deleted - show contact not found
                    Nav.NavigateTo($"/viewmed/{Alert.Id}");
                    return;
                }

                // bind to show labels on form
                DbAlert = (AlertModel)dbValues.ToObject();

                // move to original so second submit works (unless there is another concurrent edit)
                dbex.Entries[0].OriginalValues.SetValues(dbValues);
                Error = false;
                Busy = false;
            }
            catch (Exception ex)
            {
                EditSuccessState.Success = false;
                // unknown exception
                Error = true;
                ErrorMessage = ex.Message;
                Busy = false;
            }
        }

        /// <summary>
        /// Bail out!
        /// </summary>
        public void Cancel()
        {
            Busy = true;
            Nav.NavigateTo($"/{PageHelper.Page}");
        }

        /// <summary>
        /// Implement <see cref="IDisposable"/>.
        /// </summary>

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
