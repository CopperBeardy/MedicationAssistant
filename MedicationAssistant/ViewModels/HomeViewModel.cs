using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.ServiceLayer.DTOs;
using MedicationAssistant.ServiceLayer.Repositories;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MedicationAssistant.ViewModels
{
    public class HomeViewModel
    {
        IMapper _mapper;
        [Inject]
        IPrescriptionRepository _prescriptionRepository { get; set; }
        [Inject]
        IAlertRepository _alertRepository { get; set; }
        [Inject]
        IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }

       
        public HomeViewModel(IDbContextFactory<MedAstDBContext> dbFactory,IMapper mapper)
        {
            _mapper = mapper;
            _dbFactory = dbFactory;
         }
        public IEnumerable<PrescriptionDateCount> Prescriptions { get; set; }
        public IEnumerable<AlertTimeCount> Alerts { get; set; }


        public async Task GetLists( string userId)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                _prescriptionRepository = new PrescriptionRepository(context);
                _alertRepository = new AlertRepository(context);
                Prescriptions = PrescriptionDateCount.FromPrescriptions((await _prescriptionRepository.GetRequiredAmountOfPrescriptionsAsync(userId, 5)),_mapper);
                Alerts = AlertTimeCount.FromAlerts((await _alertRepository.GetRequiredAmountOfAlertsForIdAsync(userId, 5)),_mapper);
                
            }
        }
    }
}