using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class Discount
	{
		[Key]
		public int DiscountId { get; set; }

		[DataType(DataType.Currency)]
		public double Retention { get; set; }

		public int DiscountDays { get; set; }

		public double Tea { get; set; }

		public double DiscountRate { get; set; }

		[DataType(DataType.Currency)]
		public double InitialCost { get; set; }

		[DataType(DataType.Currency)]
		public double FinalCost { get; set; }

		[DataType(DataType.Currency)]
		public double NetValue { get; set; }

		[DataType(DataType.Currency)]
		public double ReceivedValue { get; set; }

		public double Tcea { get; set; }



		public int BillId { get; set; }
		public Bill Bill { get; set; }



		public int DiscountPoolId { get; set; }
		public DiscountPool DiscountPool { get; set; }



		public List<DiscountCost> DiscountCosts { get; set; }



		public Discount() { }
		// public Discount() { }

		public override string ToString()
		{
			return $"Discount {{ DiscountId: {DiscountId}, Retention: {Retention}, DiscountDays: {DiscountDays}, Tea: {Tea}, DiscountRate: {DiscountRate}, InitialCost: {InitialCost}, FinalCost: {FinalCost}, NetValue: {NetValue}, ReceivedValue: {ReceivedValue}, Tcea: {Tcea} }}";
		}
	}
}