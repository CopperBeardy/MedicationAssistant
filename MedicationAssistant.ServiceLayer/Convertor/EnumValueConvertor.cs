using MedicationAssistant.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MedicationAssistant.ServiceLayer.Convertor
{
    public static class EnumValueConvertor
    {
        public static IEnumerable<string> DosageUnits => Enum.GetNames(typeof(DosageUnit)).ToList();

        public static IEnumerable<string> FrequencyUnits => Enum.GetNames(typeof(Frequency)).ToList();

    }
}