using AutoMapper;
using MedicationAssistant.DAL;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.ViewModels
{
    public class ViewModelBase : IViewModelBase
    {
       
        public IMapper _mapper { get; set; }
       
        public IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }
       
       
    }
}