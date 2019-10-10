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

		// POR PAGAR 1, POR COBRAR 2, DESCONTADA 3
		[Range(1, 3)]
		public int BillType { get; set; }

		public string DrawerRuc { get; set; }

		public string DraweeRuc { get; set; }

		// Una pyme puede tener muchas letras asociadas
		// ya sea por cobra, por pagar o descontada
		public int PymeId { get; set; }
		public Pyme Pyme { get; set; }
	}
}