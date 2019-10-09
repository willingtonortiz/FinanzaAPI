using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IBillService
	{
		IEnumerable<Bill> FindByRuc(string ruc);
	}
}