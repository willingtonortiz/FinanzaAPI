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

		public IEnumerable<Bill> FindByRuc(string ruc)
		{
			return _context.Bills
				.AsNoTracking()
				.Where(x => x.Drawer.Ruc == ruc);
		}
	}
}