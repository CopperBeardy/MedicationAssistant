using AutoMapper;
using MedicationAssistant.Data;
using MedicationAssistant.Data.Entities;
using MedicationAssistant.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
    public interface IAddAlertViewModel
    {
      
        void Cancel();
        Task ValidationResultAsync(bool success);

        AlertModel Alert { get; set; }
        List<Prescription> Prescriptions { get; set; }
    }
}
