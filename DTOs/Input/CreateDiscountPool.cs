using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.DTOs.Input
{
	public class CreateDiscountPool
	{
		[Required]
		public double ReceivedValue { get; set; }
		[Required]
		public double DeliveredValue { get; set; }
		[Required]
		public double Tcea { get; set; }
		[Required]
		public DateTime DiscountDate { get; set; }

		[Required]
		public int PymeId { get; set; }
		
		public int BankId { get; set; }

		[Required]
		public IEnumerable<CreateDiscount> Discounts { get; set; }
	}
}