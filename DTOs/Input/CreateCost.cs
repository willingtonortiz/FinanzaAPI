using FinanzasBE.Enums;

namespace FinanzasBE.DTOs.Input
{
    public class CreateCost
    {
        public string Reason { get; set; }
        public CostType CostType { get; set; }
        public double Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
    }
}