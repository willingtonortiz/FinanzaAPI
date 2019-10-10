using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.ServicesImpl
{
	public class BillServiceImpl : IBillService
	{
		private readonly FinanzasContext _context;

		public BillServiceImpl(FinanzasContext context)
		{
			_context = context;
		}

		public IEnumerable<Bill> FindByPymeId(int pymeId)
		{
			return _context.Bills
				.AsNoTracking()
				.Include(x => x.Pyme)
				.Where(x => x.PymeId == pymeId);
		}

		public Bill FindById(int billId)
		{
			return _context.Bills
				.AsNoTracking()
				.FirstOrDefault(x => x.BillId == billId);
		}

		public Bill Create(Bill bill)
		{
			_context.Bills
				.Add(bill);

			_context.SaveChanges();

			return bill;
		}
	}
}