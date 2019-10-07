using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class Pyme
	{
		[Key]
		public int Ruc { get; set; }

		[DataType(DataType.Text)]
		public string BusinessName { get; set; }

		[DataType(DataType.Text)]
		public string Address { get; set; }


		public long UserId { get; set; }
		public User User { get; set; }

        public List<Bill> Bills { get; set; }

		public Pyme()
		{
		}
	}
}