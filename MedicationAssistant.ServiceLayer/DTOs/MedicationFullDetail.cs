using AutoMapper;
using MedicationAssistant.Common.Enums;
using MedicationAssistant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationAssistant.ServiceLayer.DTOs
{
    public class MedicationFullDetail
    {

        public int MedicationId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name of the medication needs to be between 5 - 100 characters", MinimumLength = 5)]
        public string Name { get; set; }

        
        public  string UserId { get; private set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Dosage { get; set; }

        [Required]
        public DosageUnit DosageUnit { get; set; }

        [Required]
        public double FrequencyUnit { get; set; }

        [Required]
        public Frequency Frequency { get; set; }

        public string UseDirections { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public static MedicationFullDetail FromMedication(Medication medicaton, IMapper mapper)
            => mapper.Map<MedicationFullDetail>(medicaton);
        
        public static Medication  FromMedicationFullDetail(MedicationFullDetail mfd, IMapper mapper)
            => mapper.Map<Medication>(mfd);
        
    }
}
