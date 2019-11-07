using System;
using FinanzasBE.Enums;

namespace FinanzasBE.DTOs.Input
{
    public class CreateBill
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public double Amount { get; set; }
        public BillType Type { get; set; }
        public BillStatus Status { get; set; }
        public string DrawerRuc { get; set; }
        public string DraweeRuc { get; set; }
        public int PymeId { get; set; }
    }
}