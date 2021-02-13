using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System.Security.Claims;

namespace MedicationAssistant.Helpers
{
    public static class UserHelper 
    { 
        public static User GetUser(MedAstDBContext cont,AuthenticationStateProvider authStateProvide) =>
            cont.Users.FirstOrDefault(x => x.Id.Equals(authStateProvide.GetAuthenticationStateAsync()
                .Result.User.FindFirst(ClaimTypes.NameIdentifier).Value));
    }
}