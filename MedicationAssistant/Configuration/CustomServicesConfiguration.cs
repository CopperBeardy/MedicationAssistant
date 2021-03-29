using MedicationAssistant.ServiceLayer.Repositories;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using MedicationAssistant.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationAssistant.Configuration
{
	public static class CustomServicesConfiguration
	{
		public static void AddServices(IServiceCollection services)
		{
			services.AddScoped<IViewModelBase, ViewModelBase>();
			services.AddScoped<IMedicationViewModel, MedicationViewModel>();
			services.AddScoped<IAlertRepository, AlertRepository>();
			services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

		}
	}
}
