using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
	public interface IRecordService
	{
		IEnumerable<Record> FindAll();
		Task<IEnumerable<Record>> FindByUserId(int id);
		Record FindById(int id);
		Record Save(Record record);
		//void DeleteAll();
	}
}