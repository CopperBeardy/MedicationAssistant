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
    public class AccountService :IAccountService
    { 

        readonly IDbContextFactory<MedAstDBContext> contextFactory;
        readonly AuthenticationStateProvider AuthenticationStateProvider;

        public AccountService(IDbContextFactory<MedAstDBContext> contextFactory,AuthenticationStateProvider authenticationStateProvider)
        {
            this.AuthenticationStateProvider = authenticationStateProvider;
            this.contextFactory = contextFactory;
        }
       
        public async Task<Account> FindAccount()
        {
            Account Account = UserHelper.GetAccount(contextFactory.CreateDbContext(), AuthenticationStateProvider);
            Account = Account == null ? Create() : await GetAccount(Account);
            return Account;
        } 
            
         
        private async Task<Account> GetAccount(Account Account)
        {
            Account.Alerts = await new AlertService(contextFactory).GetPrescriptionItemAlerts(Account.Id);
            Account.Prescriptions = await new PrescriptionService(contextFactory).GetRequiredAmountFullPrescriptions(Account.Id, 5);

            return Account;
        }

        private Account Create()
        {            
            using (var context = contextFactory.CreateDbContext())
            { 
                   Account Account = new() { Id = UserHelper.GetUserId(AuthenticationStateProvider) };
                   context.Accounts.Add(Account);
                   context.SaveChanges();
                   return Account;
            }
        }
    }
}
