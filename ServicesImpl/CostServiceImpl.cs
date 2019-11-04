using System.Collections.Generic;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.ServicesImpl
{
    public class CostServiceImpl : ICostService
    {
        private readonly FinanzasContext _context;

        public CostServiceImpl(FinanzasContext context)
        {
            _context = context;
        }

        public void DeleteAll()
        {
            IEnumerable<Cost> costs = _context.Costs.AsNoTracking();

            foreach (Cost cost in costs)
            {
                _context.Costs.Remove(cost);
            }

            _context.SaveChanges();
        }
    }
}