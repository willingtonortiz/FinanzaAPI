using FinanzasBE.Entities;

namespace FinanzasBE.DTOs
{
	public class BankDTO
	{
		public int BankId { get; set; }
		public string Ruc { get; set; }
		public string BusinessName { get; set; }
		public double TEASoles { get; set; }
		public double TEADolares { get; set; }


		public BankDTO() { }

		public BankDTO(Bank bank)
		{
			BankId = bank.BankId;
			Ruc = bank.Ruc;
			BusinessName = bank.BusinessName;
			TEASoles = bank.TEASoles;
			TEADolares = bank.TEADolares;
		}

	}
}
