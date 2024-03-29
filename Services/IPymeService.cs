using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IPymeService
	{
		IEnumerable<Pyme> FindAll();
		Pyme FindById(int id);
		Pyme FindByRuc(string ruc);
		void Save(Pyme pyme);
		void DeleteAll();
	}
}