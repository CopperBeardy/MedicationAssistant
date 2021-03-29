using AutoMapper;
using MedicationAssistant.DAL;
using MedicationAssistant.ServiceLayer.Models;
using MedicationAssistant.ServiceLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicationAssistant.ViewModels
{
	public class MedicationViewModel : ViewModelBase, IMedicationViewModel
	{
		public List<MedicationFullDetail> MedicationFullDetails { get; set; }

		public MedicationViewModel(IMapper mapper, IDbContextFactory<MedAstDBContext> dbFactory, ClaimsPrincipal user)
		{
			UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
			_mapper = mapper;
			_dbFactory = dbFactory;
		}

		public async Task LoadData() => MedicationFullDetails = MedicationModelConvertor.ListFromMedication(
				await new MedicationRepository(_dbFactory.CreateDbContext()).GetAllMedicationsForUser(UserId), _mapper);

		public void OnRowUpdating(MedicationFullDetail Medication, Dictionary<string, object> newValues)
		{
			var item = MedicationModelConvertor.FromMedicationFullDetail(Medication, newValues, _mapper);
			var context = _dbFactory.CreateDbContext();
			new MedicationRepository(context).UpdateMedication(item);
			context.SaveChanges();

			MedicationFullDetails[MedicationFullDetails.FindIndex(x => x.MedicationId == item.MedicationId)]
				= MedicationModelConvertor.FromMedication(item, _mapper);

		}

		public void OnRowInserting(Dictionary<string, object> values)
		{
			values.Add("UserId", UserId);
			var item = MedicationModelConvertor.SetValues(new(), values);

			var context = _dbFactory.CreateDbContext();
			new MedicationRepository(context).CreateMedication(item);
			context.SaveChanges();

			MedicationFullDetails.Add(MedicationModelConvertor.FromMedication(item, _mapper));
		}
	}
}