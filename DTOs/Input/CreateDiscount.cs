using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.DTOs.Input
{
    public class CreateDiscount
    {
        [Required] public double Retention { get; set; }
        [Required] public int DiscountDays { get; set; }
        [Required] public double Tep { get; set; }
        [Required] public double DiscountRate { get; set; }
        [Required] public double InitialCost { get; set; }
        [Required] public double FinalCost { get; set; }
        [Required] public double NetValue { get; set; }
        [Required] public double ReceivedValue { get; set; }
        [Required] public double DeliveredValue { get; set; }
        [Required] public double Tcea { get; set; }
        [Required] public int BillId { get; set; }
        public IEnumerable<CreateCost> Costs { get; set; }
    }
}