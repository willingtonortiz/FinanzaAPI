using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinanzasBE.Enums;

namespace FinanzasBE.Entities
{
    public class Cost
    {
        [Key] public int CostId { get; set; }

        [DataType(DataType.Text)] public string Reason { get; set; }

        public CostType CostType { get; set; }

        public double Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public CurrencyCode CurrencyCode { get; set; }

        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        public Cost()
        {
        }

        public override string ToString()
        {
            return $"Cost {{ CostId: {CostId}, Reason: {Reason}, CostType: {CostType}}}";
        }
    }
}