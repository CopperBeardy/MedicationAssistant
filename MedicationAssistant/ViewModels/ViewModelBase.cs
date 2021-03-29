using AutoMapper;
using MedicationAssistant.DAL;
using Microsoft.EntityFrameworkCore;

namespace MedicationAssistant.ViewModels
{
	public class ViewModelBase : IViewModelBase
	{
		public IMapper _mapper { get; set; }
		public IDbContextFactory<MedAstDBContext> _dbFactory { get; set; }
		protected string UserId { get; set; }
	}
}