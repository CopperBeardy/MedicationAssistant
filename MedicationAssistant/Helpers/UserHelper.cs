using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MedicationAssistant.Helpers
{
    public static class UserHelper
    {
        public static string GetUserId(AuthenticationStateProvider authenticationStateProvider)
        {
            return authenticationStateProvider.GetAuthenticationStateAsync()
                .Result.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}