using System.Collections.Generic;
using System.Threading.Tasks;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
    public interface IBillService
    {
        IEnumerable<Bill> FindByPymeId(int pymeId);
        Task<IEnumerable<Bill>> FindAllByPymeIdAsync(int pymeId);

        IEnumerable<Bill> FindAll();

        Bill FindById(int billId);

        Bill Create(Bill bill);

        Task<Bill> DeleteByIdAsync(int billId);
        void DeleteAll();
    }
}