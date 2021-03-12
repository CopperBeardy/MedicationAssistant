using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.Helpers;
using MedicationAssistant.ServiceLayer.Models;
using MedicationAssistant.ServiceLayer.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationAssistant.ViewModels
{
    public class DashboardViewModel : ViewModelBase, IDashboardViewModel
    {
        
        public IEnumerable<PrescriptionDateCount> Prescriptions { get; set; }
        public IEnumerable<AlertTimeCount> Alerts { get; set; }
        public string UserId { get;  set; }

        public DashboardViewModel(IDbContextFactory<MedAstDBContext> dbFactory, IMapper mapper,AuthenticationStateProvider authenticationStateProvider)
        {
            _mapper = mapper;
            _dbFactory = dbFactory;
            UserId = UserHelper.GetUserId(authenticationStateProvider);
        }

        public async Task GetLists()
        {
            var context = _dbFactory.CreateDbContext();
            Prescriptions = PrescriptionModelConvertor.FromPrescriptions((await new PrescriptionRepository(context)
                .GetRequiredAmountOfPrescriptionsAsync(UserId, 5)), _mapper);
            Alerts = AlertModelConvertor.FromAlerts((await new AlertRepository(context)
                .GetRequiredAmountOfAlertsForIdAsync(UserId, 5)), _mapper);
        }
    }
}