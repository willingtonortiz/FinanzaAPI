using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class Bank
	{
		[Key]
		public int Ruc { get; set; }

		[DataType(DataType.Text)]
		public string BusinessName { get; set; }

		[DataType(DataType.Currency)]
		public double TEASoles { get; set; }

		[DataType(DataType.Currency)]
		public double TEADolares { get; set; }

		public Bank() { }
	}
}