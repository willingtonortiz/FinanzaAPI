using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class Cost
	{
		[Key]
		public int CostId { get; set; }

		[DataType(DataType.Text)]
		public string Reason { get; set; }

		// Gasto inicial o final
		[DataType(DataType.Text)]
		public string CostType { get; set; }



		public List<DiscountCost> DiscountCosts { get; set; }



		public Cost() { }
		// public Cost(){}

		public override string ToString()
		{
			return $"Cost {{ CostId: {CostId}, Reason: {Reason}, CostType: {CostType}}}";
		}
	}
}