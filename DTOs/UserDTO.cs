using FinanzasBE.Entities;

namespace FinanzasBE.DTOs
{
	public class UserDTO
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }

		public UserDTO() { }
	}
}