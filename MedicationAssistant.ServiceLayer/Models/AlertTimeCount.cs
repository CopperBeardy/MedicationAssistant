using AutoMapper;
using MedicationAssistant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.Models
{
    public class AlertTimeCount
    {
        public DateTime Time { get; private set; }
        public int NumberOfMedications { get; private set; }

    }
}
