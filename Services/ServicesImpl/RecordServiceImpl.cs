using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using FinanzasBE.Repositories;
using FinanzasBE.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.ServicesImpl
{
    public class RecordServiceImpl : IRecordService
    {
        private readonly FinanzasContext _context;
        private readonly RecordRepository _recordRepository;
        public RecordServiceImpl(
            FinanzasContext context,
            RecordRepository recordRepository
        )
        {
            _context = context;
            this._recordRepository = recordRepository;
        }

        public IEnumerable<Record> FindAll()
        {
            return this._recordRepository.FindAll();
        }

        public Record FindById(int id)
        {
            return this._recordRepository.FindById(id);
        }

        public Task<IEnumerable<Record>> FindByUserId(int id)
        {
            return this._recordRepository.FindAllByUserIdAsync(id);
        }

        public Record Save(Record record)
        {
            return this._recordRepository.Create(record);
        }
    }
}