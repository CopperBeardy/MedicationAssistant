using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Models
{

    /// <summary>
    /// this is the clas for connecting
    /// all brand with a single medicaitons
    /// </summary>
    public class Medicine
    {
         public Guid Id { get; set; } 
        public string  Name{ get; set; }
        public int Dosage { get; set; }
        public DosageUnit DosageUnit { get; set; }
        public string Description { get; set; }
        public string UseDirections { get; set; }

       
    }
}
