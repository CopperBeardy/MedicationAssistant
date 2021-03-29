using AutoMapper;
using MedicationAssistant.Common.Models;
using MedicationAssistant.ServiceLayer.Models;
using System;
using System.Collections.Generic;

namespace MedicationAssistant.ServiceLayer.Repositories
{
	public static class PrescriptionModelConvertor
	{
		public static IReadOnlyCollection<PrescriptionDateCount> FromPrescriptions(IEnumerable<Prescription> prescriptions, IMapper mapper) =>
		   mapper.Map<IReadOnlyCollection<PrescriptionDateCount>>(prescriptions);

		private static Prescription SetValues(Prescription pre, Dictionary<string, object> newValues)
		{
			foreach (var item in newValues.Keys)
			{
				switch (item)
				{
					case "Name":
						pre.CollectedOn = (DateTime)newValues[item];
						break;
					case "Medications":
						pre.Medications = (List<Medication>)newValues[item];
						break;
				}
			}
			return pre;
		}

	}
}