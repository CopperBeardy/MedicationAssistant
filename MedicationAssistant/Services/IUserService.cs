using MedicationAssistant.Data;
using MedicationAssistant.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Linq;

namespace MedicationAssistant.Services
{
    public interface IUserService
    {
        User GetUser(MedicationAssistantDBContext cont, AuthenticationStateProvider authenticationStateProvider);
    }
}

