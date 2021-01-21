using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;

namespace MedicationAssistant.Services
{
    public class UserService : IUserService
    {
        readonly AuthenticationStateProvider authenticationStateProvider;
        readonly IDbContextFactory<MedicationAssistantDBContext> dbFactory;
        User user;
        string userId = string.Empty;
        public UserService(AuthenticationStateProvider authenticationStateProvider,
            IDbContextFactory<MedicationAssistantDBContext> dbFactory)
        {
            this.dbFactory = dbFactory;
            this.authenticationStateProvider = authenticationStateProvider;
            userId = GetUserId();
            User user = new User();
        }

        public User GetUser()
        {

            using (var cont = dbFactory.CreateDbContext())
            {
                user = cont.Users.FirstOrDefault(x => x.Id.Equals(userId));

                if (user == null)
                {
                    cont.Users.Add(new User() { Id = userId });
                    cont.SaveChanges();
                    cont.Dispose();
                }
                else
                {
                    GetAlerts(cont);
                    GetPrescriptions(cont);
                }
            }

            return user;
        }

        private void GetAlerts(MedicationAssistantDBContext cont)
        {
            user.Alerts = cont.PrescriptionAlerts
                    .Where(alert => alert.UserId.Equals(userId))
                    .OrderByDescending(time => time.Time)
                    .Take(5)
                    .ToList();
            if (user.Alerts == null)
            {
                user.Alerts = new List<PrescriptionItemAlert>();
            }

        }

        private void GetPrescriptions(MedicationAssistantDBContext cont)
        {
            user.Prescriptions = cont.Prescriptions
                    .Where(prescription => prescription.UserId.Equals(userId))
                    .OrderByDescending(time => time.CollectedOn)
                    .Take(5)
                    .Include(items => items.PrescriptionItems)
                    .ThenInclude(m => m.Medicine)
                    .ToList();

            if (user.Prescriptions == null)
            {
                user.Prescriptions = new List<Prescription>();
            }

        }

        private string GetUserId() =>
            authenticationStateProvider.GetAuthenticationStateAsync()
            .Result.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    }
}

