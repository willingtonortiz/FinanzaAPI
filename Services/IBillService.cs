using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IBillService
	{
		IEnumerable<Bill> FindByPymeId(int pymeId);

		Bill FindById(int billId);

		Bill Create(Bill bill);
	}
}