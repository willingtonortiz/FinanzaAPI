using System.Collections.Generic;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.ServicesImpl
{
    public class DiscountServiceImpl : IDiscountService

    {
        private readonly FinanzasContext _context;

        public DiscountServiceImpl(FinanzasContext context)
        {
            _context = context;
        }

        public IEnumerable<Discount> FindAll()
        {
            return _context.Discounts
                .AsNoTracking();
        }

        public Discount Create(Discount discount)
        {
            _context.Discounts
                .Add(discount);

            _context.SaveChanges();

            return discount;
        }

        public void DeleteAll()
        {
            IEnumerable<Discount> discounts = _context.Discounts.AsNoTracking();

            foreach (Discount discount in discounts)
            {
                _context.Discounts.Remove(discount);
            }

            _context.SaveChanges();
        }
    }
}