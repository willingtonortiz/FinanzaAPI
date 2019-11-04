using System.Collections.Generic;
using FinanzasBE.DTOs.Input;
using FinanzasBE.DTOs.Output;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
    public class DiscountPoolOutputConverter : IConverter<DiscountPool, DiscountPoolOutput>
    {
        public DiscountPool FromDto(DiscountPoolOutput dto)
        {
            throw new System.NotImplementedException();
        }

        public DiscountPoolOutput FromEntity(DiscountPool entity)
        {
            DiscountPoolOutput newDiscountPool = new DiscountPoolOutput
            {
                Id = entity.DiscountPoolId,
                DeliveredValue = entity.DeliveredValue,
                ReceivedValue = entity.ReceivedValue,
                Tcea = entity.TCEA,
                DiscountDate = entity.DiscountDate,
                PymeId = entity.PymeId
            };

            List<DiscountOutput> newDiscounts = new List<DiscountOutput>();
            foreach (Discount discountItem in entity.Discounts)
            {
                DiscountOutput newDiscount = new DiscountOutput
                {
                    Id = discountItem.DiscountId,
                    Retention = discountItem.Retention,
                    BillId = discountItem.BillId,
                    Tcea = discountItem.Tcea,
                    Tep = discountItem.Tep,
                    DeliveredValue = discountItem.DeliveredValue,
                    ReceivedValue = discountItem.ReceivedValue,
                    DiscountDays = discountItem.DiscountDays,
                    DiscountRate = discountItem.DiscountRate,
                    FinalCost = discountItem.FinalCost,
                    InitialCost = discountItem.InitialCost,
                    NetValue = discountItem.NetValue
                };

                List<CostOutput> costs = new List<CostOutput>();

                foreach (Cost costItem in discountItem.Costs)
                {
                    CostOutput cost = new CostOutput
                    {
                        Id = costItem.CostId,
                        Amount = costItem.Amount,
                        Reason = costItem.Reason,
                        CostType = costItem.CostType,
                        CurrencyCode = costItem.CurrencyCode,
                        PaymentType = costItem.PaymentType
                    };
                    costs.Add(cost);
                }

                newDiscount.Costs = costs;
                newDiscounts.Add(newDiscount);
            }

            newDiscountPool.Discounts = newDiscounts;

            return newDiscountPool;
        }
    }
}