using System.Collections.Generic;

namespace FinanzasBE.DTOs.Output
{
    public class DiscountOutput
    {
        public int Id { get; set; }
        public double Retention { get; set; }
        public int DiscountDays { get; set; }
        public double Tep { get; set; }
        public double DiscountRate { get; set; }
        public double InitialCost { get; set; }
        public double FinalCost { get; set; }
        public double NetValue { get; set; }
        public double ReceivedValue { get; set; }
        public double DeliveredValue { get; set; }
        public double Tcea { get; set; }
        
        public BillOutput Bill { get; set; }
        public List<CostOutput> Costs { get; set; }
    }
}