using System;
using FinanzasBE.Entities;

namespace FinanzasBE.DTOs
{
	public class BillDTO
	{
		public int BillId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Currency { get; set; }
		public double Amount { get; set; }
		public int BillType { get; set; }
		public string DrawerRuc { get; set; }
		public string DraweeRuc { get; set; }

		public BillDTO()
		{
		}

		public BillDTO(Bill bill)
		{
			BillId = bill.BillId;
			StartDate = bill.StartDate;
			EndDate = bill.EndDate;
			Currency = bill.Currency;
			Amount = bill.Amount;
			BillType = bill.BillType;
			DrawerRuc = bill.DrawerRuc;
			DraweeRuc = bill.DraweeRuc;
		}
	}
}