using MedicationAssistant.Common.Models;
using MedicationAssistant.DAL;
using MedicationAssistant.ServiceLayer.Repositories.Interfaces;
using MedicationAssistant.Tests.ServiceTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedicationAssistant.Tests.RepositoryTests.AlertRepositoryTests
{
	public class GetAllAlertsAsyncTests : DataContextFixture

	{
		[Fact]
		public async Task GetListOfAllAlertsInDatabase()
		{
			List<Alert> alerts = new List<Alert>()
			{
				It.IsAny<Alert>(),
				It.IsAny<Alert>(),
				It.IsAny<Alert>(),
			};

			var repo = new Mock<IAlertRepository>();
			repo.Setup(a => a.GetAllAlertsAsync()).ReturnsAsync(alerts).Verifiable();

			var result = await repo.Object.GetAllAlertsAsync();

			Assert.Equal(3, result.Count());
			repo.Verify(a => a.GetAllAlertsAsync(), Times.Once);
		}

		[Fact]
		public async Task CheckReturnedListIsInDescendingOrder()
		{
			var x = new DateTime();

			IEnumerable<Alert> alerts = new List<Alert>()
			{
				new Alert(){ Time = x.AddHours(3)},
				new Alert(){ Time = x.AddHours(1)},
				new Alert(){ Time = x.AddHours(8)}
			};

			var repo = new Mock<IAlertRepository>();
			repo.Setup(a => a.GetAllAlertsAsync())
				.ReturnsAsync(alerts.OrderByDescending(a => a.Time)).Verifiable();


			var result = await repo.Object.GetAllAlertsAsync();

			Assert.Equal(3, result.Count());
			Assert.Equal(x.AddHours(8), result.First().Time);
			repo.Verify(a => a.GetAllAlertsAsync(), Times.Once);
		}


		[Fact]
		public async Task ThrowsExceptionInDatabase()
		{

			var repo = new Mock<IAlertRepository>();
			repo.Setup(a => a.GetAllAlertsAsync()).ThrowsAsync(new Exception("Exception has been thrown")).Verifiable();

			var result = await Record.ExceptionAsync(async () => await repo.Object.GetAllAlertsAsync());

			repo.Verify(a => a.GetAllAlertsAsync(), Times.Once);
			Assert.IsType<Exception>(result);
		}
	}
}
