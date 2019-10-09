namespace FinanzasBE.DTOs
{
	public class UserAuthentication
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Token { get; set; }
		public string Role { get; set; }
	}
}