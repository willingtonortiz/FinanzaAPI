using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
    public class DiscountCost
    {
        // Attribute Properties
        [Key] public int DiscountCostId { get; set; }

        [DataType(DataType.Currency)] public double Amount { get; set; }

        [DataType(DataType.Text)] public string ValueType { get; set; }


        // Navigation Properties
        // public int DiscountId { get; set; }
        // public Discount Discount { get; set; }


        // public int CostId { get; set; }
        // public Cost Cost { get; set; }


        public DiscountCost()
        {
        }
        // public DiscountCost() { }

        public override string ToString()
        {
            return $"DiscountCost {{ DiscountCostId: {DiscountCostId}, Amount: {Amount}, ValueType: {ValueType} }}";
        }
    }
}