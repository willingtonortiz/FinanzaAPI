using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class DiscountPool
	{
		// Entity properties
		[Key]
		public int DiscountPoolId { get; set; }

		[DataType(DataType.Currency)]
		public double ReceivedValue { get; set; }

		[DataType(DataType.Currency)]
		public double DeliveredValue { get; set; }
		public double TCEA { get; set; }

		[DataType(DataType.Date)]
		public DateTime DiscountDate { get; set; }


		// Navigation properties
		public int PymeId { get; set; }
		public Pyme Pyme { get; set; }

		public int? BankId { get; set; }
		public Bank Bank { get; set; }

		public List<Discount> Discounts { get; set; } = new List<Discount>();

		public DiscountPool() { }

		// public DiscountPool() { }


		public override string ToString()
		{
			return $"DiscountPool {{ DiscountPoolId: {DiscountPoolId}, TCEA: {TCEA}, DiscountDate: {DiscountDate} }}";
		}
	}
}