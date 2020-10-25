﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.Shared.Models
{
    public class MedicationUse
    {
          public Guid Id { get; set; }
         public int Quantity { get; set; }        
        public Medicine Medicine { get; set; }       
        public Guid MedicineId { get; set; }
    }
}
