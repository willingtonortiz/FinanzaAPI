using System.Collections.Generic;
using FinanzasBE.DTOs.Input;
using FinanzasBE.Entities;

namespace FinanzasBE.Services
{
    public interface IDiscountPoolService
    {
        IEnumerable<DiscountPool> FindAll();
        IEnumerable<DiscountPool> FindAllByPymeId(int pymeId);
        DiscountPool FindById(int discontPoolId);
        DiscountPool Create(DiscountPool discountPool);
        DiscountPool CreateCompleteDiscountPool(DiscountPool discountPool);
        void DeleteAll();
    }
}