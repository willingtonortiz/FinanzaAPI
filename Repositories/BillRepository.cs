using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Repositories
{
    public class BillRepository : BaseRepository
    {
        private readonly ILogger<BillRepository> _logger;

        public BillRepository(
            FinanzasContext context,
            ILogger<BillRepository> logger
        ) : base(context)
        {
            _logger = logger;
        }


        #region FindAddByPymeIdAsync

        public async Task<IEnumerable<Bill>> FindAllByPymeIdAsync(int pymeId)
        {
            return await _context.Bills
                .AsNoTracking()
                .Where(x => x.PymeId == pymeId)
                .ToListAsync();
        }

        #endregion


        #region DeleteByIdAsync

        public async Task<Bill> DeleteByIdAsync(int billId)
        {
            Bill bill = await _context.Bills
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BillId == billId);

            _context.Bills.Remove(bill);

            await _context.SaveChangesAsync();
            _context.Entry(bill).State = EntityState.Detached;
            
            return bill;
        }

        #endregion


        #region UpdateBill

        public Bill UpdateBill(Bill bill)
        {
            _context.Bills
                .Update(bill);

            _context.SaveChanges();

            // Evitando que trackee los cambios
            _context.Entry(bill).State = EntityState.Detached;

            return bill;
        }

        #endregion


        #region DeleteAll

        public void DeleteAll()
        {
            IEnumerable<Bill> bills = _context.Bills.AsNoTracking();

            foreach (Bill bill in bills)
            {
                _context.Bills.Remove(bill);
            }

            _context.SaveChanges();
        }

        #endregion


        #region FindByPymeId

        public IEnumerable<Bill> FindByPymeId(int pymeId)
        {
            return _context.Bills
                .AsNoTracking()
                .Where(x => x.PymeId == pymeId);
        }

        #endregion


        #region FindAll

        public IEnumerable<Bill> FindAll()
        {
            return _context.Bills
                .AsNoTracking();
        }

        #endregion


        #region FindById

        public Bill FindById(int billId)
        {
            return _context.Bills
                .AsNoTracking()
                .FirstOrDefault(x => x.BillId == billId);
        }

        #endregion


        #region Create

        public Bill Create(Bill bill)
        {
            _context.Bills
                .Add(bill);

            _context.SaveChanges();
            _context.Entry(bill).State = EntityState.Detached;

            return bill;
        }

        #endregion
    }
}