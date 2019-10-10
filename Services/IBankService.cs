using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IBankService
	{
		IEnumerable<Bank> FindAll();

		Bank FindByRuc(string ruc);
		
		Bank Create(Bank bank);
	}
}