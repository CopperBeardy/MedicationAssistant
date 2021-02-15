using MedicationAssistant.Data;
using MedicationAssistant.Helpers;
using MedicationAssistant.Services.Interfaces;
using MedicationAssistant.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services
{
    public class AccountService : IAccountService
    {
        readonly IDbContextFactory<MedAstDBContext> contextFactory;
        readonly AuthenticationStateProvider AuthenticationStateProvider;
        Account Account;
    
        public AccountService(IDbContextFactory<MedAstDBContext> contextFactory, AuthenticationStateProvider authenticationStateProvider)
        {
            this.AuthenticationStateProvider = authenticationStateProvider;
            this.contextFactory = contextFactory;
        }
        
        public async Task<Account> FindAccount()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                Account = context
                    .Accounts.FirstOrDefault(x =>
                    x.Id.Equals(UserHelper.GetUserId(AuthenticationStateProvider)));
            } 
            return Account == null ? Create() : await GetAccountValues(Account);          
        }

        private async Task<Account> GetAccountValues(Account Account)
        {
            Account.Alerts = await new AlertService(contextFactory).GetPrescriptionItemAlerts(Account.Id);
            Account.Prescriptions = await new PrescriptionService(contextFactory).GetRequiredAmountFullPrescriptions(Account.Id, 5);

            return Account;
        }

        private Account Create()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                Account = new() { Id = UserHelper.GetUserId(AuthenticationStateProvider) };
                context.Accounts.Add(Account);
                context.SaveChanges();
                return Account;
            }
        }
    }
}
