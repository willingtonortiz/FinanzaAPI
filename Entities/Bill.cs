using System;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class Bill
	{
		[Key]
		public int BillId { get; set; }

		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }

		[DataType(DataType.Text)]
		public string Currency { get; set; }

		[DataType(DataType.Currency)]
		public double Amount { get; set; }

		[DataType(DataType.Text)]
		public string BillType { get; set; }

		public int DrawerId { get; set; }
		public Pyme Drawer { get; set; }

		public int DraweeId { get; set; }
	}
}