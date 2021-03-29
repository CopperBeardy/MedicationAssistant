using MedicationAssistant.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationAssistant.Configuration
{
	public static class ContextConfiguration
	{
		public static void AddDbFactory(IServiceCollection services, IConfiguration configuration)
		{
#if DEBUG
			services.AddDbContextFactory<MedAstDBContext>(opt =>
				opt.UseSqlServer(configuration.GetConnectionString("MedAstConn"))
				.EnableSensitiveDataLogging());

#else
			services.AddDbContextFactory<MedAstDBContext>(opt =>
			opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
#endif

			services.AddScoped<MedAstDBContext>(p =>
			p.GetRequiredService<IDbContextFactory<MedAstDBContext>>()
			.CreateDbContext());
		}
	}
}
