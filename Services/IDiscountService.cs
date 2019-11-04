using System.Collections.Generic;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
    public interface IDiscountService
    {
        IEnumerable<Discount> FindAll();
        Discount Create(Discount discount);
        void DeleteAll();
    }
}