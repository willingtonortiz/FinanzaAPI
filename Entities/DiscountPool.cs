using System;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class DiscountPool
	{
		[Key]
		public int DiscountPoolId { get; set; }

		public double TCEA { get; set; }

		[DataType(DataType.Date)]
		public DateTime DiscountDate { get; set; }



		public int PymeId { get; set; }
		public Pyme Pyme { get; set; }



		public int BankId { get; set; }
		public Bank Bank { get; set; }


		public DiscountPool() { }

		// public DiscountPool() { }


		public override string ToString()
		{
			return $"DiscountPool {{ DiscountPoolId: {DiscountPoolId}, TCEA: {TCEA}, DiscountDate: {DiscountDate} }}";
		}
	}
}