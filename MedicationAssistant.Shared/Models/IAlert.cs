using System;
using System.Collections.Generic;

namespace MedicationAssistant.Shared.Models
{
    public interface IAlert
    {
        int Id { get; set; }
        DateTime StartFrom { get; set; }
        DateTime Time { get; set; }
        byte[] TimeStamp { get; set; }
        string Title { get; }        
        List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}