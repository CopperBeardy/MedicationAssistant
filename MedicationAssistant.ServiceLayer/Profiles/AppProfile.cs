using AutoMapper;
using MedicationAssistant.DAL.Entities;
using MedicationAssistant.ServiceLayer.Models;
using System.Linq;

namespace MedicationAssistant.ServiceLayer.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            
                CreateMap<Alert, AlertTimeCount>()
                    .ForMember(dest => dest.NumberOfMedications,
                                opt => opt.MapFrom(src => src.Medications.Count()));

                CreateMap<Prescription, PrescriptionDateCount>()
                    .ForMember(dest => dest.NumberOfMedications,
                                opt => opt.MapFrom(src => src.Medications.Count()));


                CreateMap<Medication, MedicationFullDetail>().ReverseMap();


           
        }
    }
}
