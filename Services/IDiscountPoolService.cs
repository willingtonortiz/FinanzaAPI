using System.Collections.Generic;
using FinanzasBE.DTOs.Input;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
    public interface IDiscountPoolService
    {
        IEnumerable<DiscountPool> FindAll();

        DiscountPool Create(DiscountPool discountPool);

        DiscountPool CreateCompleteDiscountPool(DiscountPool discountPool);
        void DeleteAll();
    }
}