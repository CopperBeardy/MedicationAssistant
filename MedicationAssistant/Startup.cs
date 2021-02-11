using MedicationAssistant.Data;
using MedicationAssistant.Helpers;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MedicationAssistant.Shared.Models;
using MedicationAssistant.Services;
using MedicationAssistant.ConfigureServiceExtensions;

namespace MedicationAssistant
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            AuthExtensions.AddConfig(services, Configuration);
            services.AddRazorPages();
            services.AddServerSideBlazor()
                .AddMicrosoftIdentityConsentHandler();
     
            services.AddDbContextFactory<MedicationAssistantDBContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ServiceExtensions.AddConfig(services, Configuration);
            services.AddHttpContextAccessor();
         

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
