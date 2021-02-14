using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicationAssistant.Shared.Models
{
    public interface IAlert
    {
        int Id { get; set; }
        DateTime StartFrom { get; set; }
        DateTime Time { get; set; }
        byte[] TimeStamp { get; set; }
        string Title { get; }        
        IEnumerable<PrescriptionItem> PrescriptionItems { get; set; }
    }
}