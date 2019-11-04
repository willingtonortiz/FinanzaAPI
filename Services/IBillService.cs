using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IBillService
	{
		IEnumerable<Bill> FindByPymeId(int pymeId);

		IEnumerable<Bill> FindAll();

		Bill FindById(int billId);

		Bill Create(Bill bill);

		IEnumerable<Bill> FindByUserId(int userId);

		void DeleteAll();
	}
}