using MedicationAssistant.Data;
using MedicationAssistant.Services.Interfaces;
using MedicationAssistant.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services
{
    public class AccountService :IAccountService
    { 

        readonly IDbContextFactory<MedAstDBContext> contextFactory;
        public AccountService(IDbContextFactory<MedAstDBContext> contextFactory)
        {

            this.contextFactory = contextFactory;
        }
       
            
        public async Task<Account> GetAccount(Account Account)
        {
           
            Account.Alerts = await new AlertService(contextFactory).GetPrescriptionItemAlerts(Account.Id);
            Account.Prescriptions = await new PrescriptionService(contextFactory).GetRequiredAmountFullPrescriptions(Account.Id, 5);

            return Account;
        }

        public void Create()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                //var x = context.Accounts.Find(account);

                context.Accounts.Add(new() { Id = "" });
                context.SaveChanges();
            }
        }

    }
}
