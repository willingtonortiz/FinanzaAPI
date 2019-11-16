using System;
using System.Collections.Generic;
using System.Linq;
using FinanzasBE.DTOs.Input;
using FinanzasBE.Entities;

namespace FinanzasBE.Converters
{
    public class CreateDiscountPoolConverter : IConverter<DiscountPool, CreateDiscountPool>
    {
        public DiscountPool FromDto(CreateDiscountPool dto)
        {
            DiscountPool newDiscountPool = new DiscountPool
            {
                DeliveredValue = dto.DeliveredValue,
                ReceivedValue = dto.ReceivedValue,
                TCEA = dto.Tcea,
                DiscountDate = dto.DiscountDate,
                CurrencyCode = dto.CurrencyCode,
                PymeId = dto.PymeId
            };
            if (dto.BankId < 0)
                newDiscountPool.BankId = null;

            List<Discount> newDiscounts = new List<Discount>();
            foreach (CreateDiscount discountItem in dto.Discounts)
            {
                Discount newDiscount = new Discount
                {
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
                    NetValue = discountItem.NetValue,
                    DiscountPool = newDiscountPool
                };

                List<Cost> costs = new List<Cost>();
                foreach (CreateCost costItem in discountItem.Costs)
                {
                    Cost cost = new Cost
                    {
                        Amount = costItem.Amount,
                        Reason = costItem.Reason,
                        CostType = costItem.CostType,
                        CurrencyCode = costItem.CurrencyCode,
                        PaymentType = costItem.PaymentType,
                        Discount = newDiscount
                    };

                    costs.Add(cost);
                }

                newDiscount.Costs = costs;
                newDiscounts.Add(newDiscount);
            }

            newDiscountPool.Discounts = newDiscounts;

            return newDiscountPool;
        }

        public CreateDiscountPool FromEntity(DiscountPool entity)
        {
            throw new System.NotImplementedException();
        }
    }
}