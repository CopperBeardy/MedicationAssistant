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
    public static class UserService 
    {
       
        public static User GetUser(MedicationAssistantDBContext cont,AuthenticationStateProvider authenticationStateProvider) =>  
             cont.Users.FirstOrDefault(x => x.Id.Equals( GetUserId(authenticationStateProvider)));
       
        private static string GetUserId(AuthenticationStateProvider authenticationStateProvider) =>
            authenticationStateProvider.GetAuthenticationStateAsync()
            .Result.User.FindFirst(ClaimTypes.NameIdentifier).Value;

    }
}

