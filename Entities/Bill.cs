using System;
using System.ComponentModel.DataAnnotations;
using FinanzasBE.DTOs;
using FinanzasBE.Enums;

namespace FinanzasBE.Entities
{
    public class Bill
    {
        [Key] public int BillId { get; set; }
        [DataType(DataType.Date)] public DateTime StartDate { get; set; }
        [DataType(DataType.Date)] public DateTime EndDate { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        [DataType(DataType.Currency)] public double Amount { get; set; }
        [EnumDataType(typeof(BillType))]
        public BillType Type { get; set; }
        [EnumDataType(typeof(BillStatus))]
        public BillStatus Status { get; set; }
        public string DrawerRuc { get; set; }
        public string DraweeRuc { get; set; }
        public string PaymentPlace { get; set; }
        public string SignPlace { get; set; }

        public int PymeId { get; set; }
        public Pyme Pyme { get; set; }


        public Discount Discount { get; set; }


        public Bill()
        {
        }
    }
}