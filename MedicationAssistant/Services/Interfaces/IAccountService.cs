using MedicationAssistant.Shared.Models;
using System.Threading.Tasks;

namespace MedicationAssistant.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> FindAccount();        
    }
}
