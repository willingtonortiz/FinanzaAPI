using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IPymeService
	{
		Pyme FindByUserId(int userId);
		Pyme FindByRuc(string ruc);
		void Save(Pyme pyme);
	}
}