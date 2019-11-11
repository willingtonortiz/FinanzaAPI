using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Data;
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

        public IEnumerable<Pyme> FindAll()
        {
            return _context.Pymes
                .AsNoTracking();
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

        public void DeleteAll()
        {
            IEnumerable<Pyme> pymes = _context.Pymes.AsNoTracking();

            foreach (Pyme pyme in pymes)
            {
                _context.Pymes.Remove(pyme);
            }

            _context.SaveChanges();
        }

        public Pyme FindById(int id)
        {
            return _context.Pymes
                .AsNoTracking()
                .FirstOrDefault(x => x.PymeId == id);
        }
    }
}