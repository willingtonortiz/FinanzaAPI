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
    public class RecordRepository : BaseRepository
    {
        private readonly ILogger<RecordRepository> _logger;

        public RecordRepository(
            FinanzasContext context,
            ILogger<RecordRepository> logger
        ) : base(context)
        {
            _logger = logger;
        }


        #region FindAllByUserIdAsync

        public async Task<IEnumerable<Record>> FindAllByUserIdAsync(int userId)
        {
            return await _context.Records
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        #endregion

        #region FindAll

        public IEnumerable<Record> FindAll()
        {
            return _context.Records
                .AsNoTracking();
        }

        #endregion


        #region FindById

        public Record FindById(int recordId)
        {
            return _context.Records
                .AsNoTracking()
                .FirstOrDefault(x => x.RecordId == recordId);
        }

        #endregion


        #region Create

        public Record Create(Record record)
        {
            _context.Records
                .Add(record);

            _context.SaveChanges();
            //_context.Entry(record).State = EntityState.Detached;

            return record;
        }

        #endregion
    }
}