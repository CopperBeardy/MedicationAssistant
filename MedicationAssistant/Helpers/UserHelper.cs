using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;
using System.Security.Claims;

namespace MedicationAssistant.Helpers
{
    public static class UserHelper 
    { 
        public static string GetUserId(AuthenticationStateProvider authenticationStateProvider) =>
           authenticationStateProvider.GetAuthenticationStateAsync()
           .Result.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}