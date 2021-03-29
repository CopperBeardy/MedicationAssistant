﻿using AutoMapper;
using MedicationAssistant.Common.Models;
using MedicationAssistant.ServiceLayer.Models;
using System;
using System.Collections.Generic;

namespace MedicationAssistant.ServiceLayer.Repositories
{
	public static class AlertModelConvertor
	{
		public static IReadOnlyCollection<AlertTimeCount> FromAlerts(IEnumerable<Alert> alerts, IMapper mapper) =>
	   mapper.Map<IReadOnlyCollection<AlertTimeCount>>(alerts);

		private static Alert SetValues(Alert preItem, Dictionary<string, object> newValues)
		{
			foreach (var item in newValues.Keys)
			{
				switch (item)
				{
					case "Name":
						preItem.StartFrom = (DateTime)newValues[item];
						break;
					case "Medications":
						preItem.Medications = (List<Medication>)newValues[item];
						break;
					case "StartFrom":
						preItem.StartFrom = (DateTime)newValues[item];
						break;
					case "Time":
						preItem.Time = (DateTime)newValues[item];
						break;
					case "UserId":
						preItem.UserId = (string)newValues[item];
						break;

				}
			}
			return preItem;
		}
	}
}