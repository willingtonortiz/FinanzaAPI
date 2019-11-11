using FinanzasBE.Data;

namespace FinanzasBE.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly FinanzasContext _context;

        public BaseRepository(FinanzasContext context)
        {
            _context = context;
        }
    }
}