using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.ServicesImpl
{
	public class BankServiceImpl : IBankService
	{
		private readonly FinanzasContext _context;


		public BankServiceImpl(FinanzasContext context)
		{
			_context = context;
		}

		public Bank Create(Bank bank)
		{
			_context.Banks
				.Add(bank);

			_context.SaveChanges();
			return bank;
		}

		public IEnumerable<Bank> FindAll()
		{
			return _context.Banks
				.AsNoTracking();
		}

		public Bank FindByRuc(string ruc)
		{
			return _context.Banks
				.AsNoTracking()
				.FirstOrDefault(x => x.Ruc == ruc);
		}
	}
}