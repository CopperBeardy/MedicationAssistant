using MedicationAssistant.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicationAssistant.Shared.Entities
{

    /// <summary>
    /// this is the clas for connecting
    /// all brand with a single medicaitons
    /// </summary>
    public class Medicine
    {
        public int Id { get; set; }

        public string  Name{ get; set; }

        public string Description { get; set; }

        public ICollection<MedicineBrand> MedicineBrands { get; set; }   
    }
}
