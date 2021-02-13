using MedicationAssistant.Shared.Enums;
using System;
using System.Collections.Generic;

namespace MedicationAssistant.Convertor
{
    public static class DosageUnitValueConvertor
    {
        public static IEnumerable<string> ConvertUnits()
        {
            List<string> tempDU = new List<string>();
            foreach(var d in Enum.GetValues(typeof(DosageUnit)))
            {
                tempDU.Add(Enum.GetName(typeof(DosageUnit),d));
            }
            return tempDU;
        }
    }
}