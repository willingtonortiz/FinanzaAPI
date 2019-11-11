using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.Repositories
{
    public class BillRepository : BaseRepository
    {
        public BillRepository(FinanzasContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bill>> FindAllByPymeIdAsync(int pymeId)
        {
            return await _context.Bills
                .AsNoTracking()
                .Where(x => x.PymeId == pymeId)
                .ToListAsync();
        }
        
        public async Task<Bill> DeleteByIdAsync(int billId)
        {
            Bill bill = await _context.Bills
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BillId == billId);

            _context.Bills.Remove(bill);

            await _context.SaveChangesAsync();
            return bill;
        }

        public Bill UpdateBill(Bill bill)
        {
            _context.Bills
                .Update(bill);

            _context.SaveChanges();

            return bill;
        }
        
        public void DeleteAll()
        {
            IEnumerable<Bill> bills = _context.Bills.AsNoTracking();

            foreach (Bill bill in bills)
            {
                _context.Bills.Remove(bill);
            }

            _context.SaveChanges();
        }

        public IEnumerable<Bill> FindByPymeId(int pymeId)
        {
            return _context.Bills
                .AsNoTracking()
                .Where(x => x.PymeId == pymeId);
        }

        public IEnumerable<Bill> FindAll()
        {
            return _context.Bills
                .AsNoTracking();
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