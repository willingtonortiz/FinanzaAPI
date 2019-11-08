using System;
using FinanzasBE.Entities;
using FinanzasBE.Enums;

namespace FinanzasBE.DTOs
{
    public class BillDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public double Amount { get; set; }
        public BillType Type { get; set; }
        public BillStatus Status { get; set; }
        public string DrawerRuc { get; set; }
        public string DraweeRuc { get; set; }
        public string PaymentPlace { get; set; }
        public string SignPlace { get; set; }
    }
}