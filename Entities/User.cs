using System.ComponentModel.DataAnnotations;

namespace FinanzasBE.Entities
{
	public class User
	{
		[Key]
		public long Username { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Text)]
		public string Role { get; set; }

		public Pyme Pyme { get; set; }

		public User()
		{
		}
	}
}