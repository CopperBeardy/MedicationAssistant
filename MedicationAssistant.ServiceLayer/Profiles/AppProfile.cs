using AutoMapper;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace MedicationAssistant.ServiceLayer.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
           

            CreateMap<Alert, AlertTimeCount>()
                .ForMember(dest => dest.AlertId, opt => opt.MapFrom(src => src.AlertId))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ForMember(dest => dest.NumberOfMedications, opt => opt.MapFrom(src => src.Medications.Count()));

            CreateMap<Prescription, PrescriptionDateCount>()
             .ForMember(dest => dest.PrescriptionId, opt => opt.MapFrom(src => src.PrescriptionId))
             .ForMember(dest => dest.CollectedOn, opt => opt.MapFrom(src => src.CollectedOn))
             .ForMember(dest => dest.NumberOfMedications, opt => opt.MapFrom(src => src.Medications.Count()));





        }
    }
}
