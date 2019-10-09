using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IPymeService
	{
		void Save(Pyme pyme);
		Pyme FindByRuc(string ruc);
	}
}