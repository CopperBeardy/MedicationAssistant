using MedicationAssistant.Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.Services.Interfaces
{
    public interface IAccountService
    {
       void Create();
        Task<Account> GetAccount(Account Account);
    }
}
