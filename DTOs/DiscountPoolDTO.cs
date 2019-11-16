using System;
using FinanzasBE.Enums;

namespace FinanzasBE.DTOs
{
	public class DiscountPoolDTO
	{
		public int Id { get; set; }
		public double ReceivedValue { get; set; }
		public double DeliveredValue { get; set; }
		public double TCEA { get; set; }
		public DateTime DiscountDate { get; set; }
		public CurrencyCode CurrencyCode { get; set; }
	}
}