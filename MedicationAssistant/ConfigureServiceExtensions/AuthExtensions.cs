using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace MedicationAssistant.ConfigureServiceExtensions
{
    public static class AuthExtensions
    {  
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAdB2C"));

            services.AddControllersWithViews().AddMicrosoftIdentityUI();

            services.AddAuthorization();

            return services;
        }
    }
}