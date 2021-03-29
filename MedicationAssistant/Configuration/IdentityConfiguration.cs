using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace MedicationAssistant.Configuration
{
	public static class IdentityConfiguration
	{
		public static void AddServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
				.AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAdB2C"));

			services.AddControllersWithViews().AddMicrosoftIdentityUI();

			services.AddAuthorization();

			services.AddServerSideBlazor();

			// set up authorized user
			services.AddScoped(sp =>
			{
				var provider = sp.GetService<AuthenticationStateProvider>();
				var state = provider.GetAuthenticationStateAsync().Result;
				return state.User.Identity.IsAuthenticated ?
					state.User : null;
			});
		}

	}
}
