using System.Linq;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.ServicesImpl
{
	public class PymeServiceImpl : IPymeService
	{
		private readonly FinanzasContext _context;

		public PymeServiceImpl(FinanzasContext context)
		{
			_context = context;
		}

		public Pyme FindByRuc(string ruc)
		{
			return _context.Pymes
				.AsNoTracking()
				.FirstOrDefault(x => x.Ruc == ruc);
		}

		public void Save(Pyme pyme)
		{
			_context.Pymes
				.Add(pyme);
			_context.SaveChanges();
		}
	}
}