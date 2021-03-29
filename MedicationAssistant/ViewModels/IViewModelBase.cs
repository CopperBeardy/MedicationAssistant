using AutoMapper;
using MedicationAssistant.DAL;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.ViewModels
{
	public interface IViewModelBase
	{
		IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }
		IMapper _mapper { get; set; }
	}
}