namespace FinanzasBE.DTOs
{
	public class RegisterUserDto
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public string BusinessName { get; set; }
		public string Address { get; set; }
	}
}