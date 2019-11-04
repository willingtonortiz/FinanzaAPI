using FinanzasBE.Entities;
using FinanzasBE.Enums;

namespace FinanzasBE.DTOs.Output
{
    public class CostOutput
    {
        public int Id { get; set; }

        public string Reason { get; set; }

        public CostType CostType { get; set; }

        public double Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public CurrencyCode CurrencyCode { get; set; }
    }
}