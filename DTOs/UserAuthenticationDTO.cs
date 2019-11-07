namespace FinanzasBE.DTOs
{
	public class UserAuthenticationDTO
	{
		public int Id { get; set; }
		public string Token { get; set; }
		public string Role { get; set; }
	}
}