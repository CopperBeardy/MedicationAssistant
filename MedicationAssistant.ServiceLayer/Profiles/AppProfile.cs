using AutoMapper;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.Models;
using System.Collections.Generic;

namespace MedicationAssistant.ServiceLayer.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {

            CreateMap<Alert, AlertDashBoardModel>();
            CreateMap<IEnumerable<Alert>, IEnumerable<AlertDashBoardModel>>();
            CreateMap<Medication, MedicationDashboardModel>();
            CreateMap<IEnumerable<Medication>, IEnumerable<MedicationDashboardModel>>();
        }
    }
}
